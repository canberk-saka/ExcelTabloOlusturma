using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Teknokent
{
    public partial class Form1 : Form
    {
        private DataTable firmalarData;    // Firma bilgilerini tutar
        private DataTable calisanlarData;  // Çalışan bilgilerini tutar
        private List<DateTime> selectedDates = new List<DateTime>();  // Seçilen tarihleri tutar
        private Dictionary<string, List<DateTime>> userWorkDays = new Dictionary<string, List<DateTime>>();
        private string firmaFilePath;
        private string saveLocationPath;
        private string connectionString = "Data Source=DESKTOP-BAP4RDU\\SQLEXPRESS02;Initial Catalog=FirmaCalisanBilgileri;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            LoadFirmaData();
            LoadSaveLocation();

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(firmaFilePath))
            {
              
                UpdateFirmaComboBox();
                UpdateFirmaCheckedListBox();
            }

            nudDonem.Value = DateTime.Now.Year;

            cmbDonem.SelectedIndexChanged += cmbDonem_SelectedIndexChanged;
            nudDonem.ValueChanged += nudDonem_ValueChanged;
        }
        private void LoadFirmaData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Firmalar tablosundan verileri çek
                    string queryFirmalar = "SELECT id, FirmaAdı FROM Firmalar";
                    SqlDataAdapter firmalarAdapter = new SqlDataAdapter(queryFirmalar, conn);
                    firmalarData = new DataTable();
                    firmalarAdapter.Fill(firmalarData);

                    // Çalışanlar tablosundan verileri çek
                    string queryCalisanlar = "SELECT id, FirmaID, AdSoyad, TcNo FROM Calisanlar";
                    SqlDataAdapter calisanlarAdapter = new SqlDataAdapter(queryCalisanlar, conn);
                    calisanlarData = new DataTable();
                    calisanlarAdapter.Fill(calisanlarData);

                    // Firmaların adlarını güncelle
                    UpdateFirmaComboBox();
                    UpdateFirmaCheckedListBox();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanından veri alınırken hata oluştu: " + ex.Message);
                }
            }
        }
        private void UpdateFirmaCheckedListBox()
        {
            // CheckedListBox'ı temizle
            cmbFirma.Items.Clear();

            // Firma adlarını saklamak için bir HashSet kullanarak eşsiz değerleri sakla
            HashSet<string> firmalar = new HashSet<string>();

            // Eğer firmalarData mevcutsa işlemleri yap
            if (firmalarData != null)
            {
                foreach (DataRow row in firmalarData.Rows)
                {
                    string firmaAdı = row["FirmaAdı"].ToString();
                    if (!string.IsNullOrEmpty(firmaAdı))
                    {
                        firmalar.Add(firmaAdı);
                    }
                }

                // Firma adlarını CheckedListBox'a ekle
                cmbFirma.Items.AddRange(firmalar.ToArray());
            }
        }

        private void SaveSaveLocation(string locationPath)
        {
            Properties.Settings.Default.SaveLocationPath = locationPath;
            Properties.Settings.Default.Save();
        }

        private string GetSavedSaveLocation()
        {
            return Properties.Settings.Default.SaveLocationPath;
        }

        private void LoadSaveLocation()
        {
            saveLocationPath = Properties.Settings.Default.SaveLocationPath;
        }

        private void UpdateFirmaComboBox()
        {
            // ComboBox'ı temizle
            cmbFirma.Items.Clear();

            // Firma adlarını saklamak için bir HashSet kullanarak eşsiz değerleri sakla
            HashSet<string> firmalar = new HashSet<string>();

            // Eğer firmalarData mevcutsa işlemleri yap
            if (firmalarData != null)
            {
                foreach (DataRow row in firmalarData.Rows)
                {
                    string firmaAdı = row["FirmaAdı"].ToString();
                    if (!string.IsNullOrEmpty(firmaAdı))
                    {
                        firmalar.Add(firmaAdı);
                    }
                }

                // Firma adlarını ComboBox'a ekle
                cmbFirma.Items.AddRange(firmalar.ToArray());
            }
        }

        private void cmbFirma_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Seçili firma
            string seciliFirma = cmbFirma.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(seciliFirma))
                return;

            // Seçilen firmaya göre çalışanları filtreleme
            List<string> calisanlar = new List<string>();

            foreach (DataRow row in calisanlarData.Rows)
            {
                // Firmalar tablosundaki FirmaAdı ile çalışanların FirmaID'si eşleşmeli
                DataRow firmaRow = firmalarData.AsEnumerable()
                                               .FirstOrDefault(r => r["FirmaAdı"].ToString() == seciliFirma);
                if (firmaRow != null && row["FirmaID"].ToString() == firmaRow["id"].ToString())
                {
                    calisanlar.Add(row["AdSoyad"].ToString());
                }
            }

            // CheckedListBox'a çalışanları ekleme
            clbAdSoyad.Items.Clear();  // Önceki verileri temizle
            clbAdSoyad.Items.AddRange(calisanlar.ToArray());  // Yeni verileri ekle
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Seçili günleri alın
            DateTime selectedDate = e.Start;

            // Seçili kullanıcıları kontrol et
            foreach (var item in clbAdSoyad.CheckedItems)
            {
                string selectedUser = item.ToString();

                // Kullanıcı için tarih listesi oluşturulmuş mu kontrol edin
                if (!userWorkDays.ContainsKey(selectedUser))
                {
                    userWorkDays[selectedUser] = new List<DateTime>();
                }

                // Tarih zaten varsa, listeden çıkar ve boldedDates'ten kaldır
                if (userWorkDays[selectedUser].Contains(selectedDate))
                {
                    userWorkDays[selectedUser].Remove(selectedDate);
                    monthCalendar1.RemoveBoldedDate(selectedDate);  // Bold efekti kaldır
                }
                else
                {
                    // Tarih yoksa listeye ekle ve bold efekti ekle
                    userWorkDays[selectedUser].Add(selectedDate);
                    userWorkDays[selectedUser] = userWorkDays[selectedUser].OrderBy(d => d).ToList();
                    monthCalendar1.AddBoldedDate(selectedDate);  // Tarihi kalın yap
                }

                // Takvimi güncelle
                monthCalendar1.UpdateBoldedDates();
            }
        }


        private void cmbDonem_SelectedIndexChanged(object sender, EventArgs e)
        {
            GuncelleTakvim();
        }

        private void nudDonem_ValueChanged(object sender, EventArgs e)
        {
            GuncelleTakvim();
        }

        private void cbHaftaIci_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHaftaIci.Checked)
            {
                SecHaftaIciGunleri();
            }
            else
            {
                TemizleHaftaIciGunleri();
            }
        }

        private void cbHaftaSonuDahil_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHaftaSonuDahil.Checked)
            {
                // Seçilen ay ve yıl için hafta sonu günlerini de dahil et
                SecHaftaSonuGunleri();
            }
            else
            {
                // Hafta sonu günlerinin seçimlerini kaldır
                TemizleHaftaSonuGunleri();
            }
        }

        private void SecHaftaIciGunleri()
        {
            if (cmbDonem.SelectedItem != null)
            {
                int secilenAy = DateTime.ParseExact(cmbDonem.SelectedItem.ToString(), "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                int secilenYil = (int)nudDonem.Value;

                DateTime baslangicTarihi = new DateTime(secilenYil, secilenAy, 1);
                DateTime bitisTarihi = baslangicTarihi.AddMonths(1).AddDays(-1);

                // Seçilen hafta içi günlerini takvime ekle ve kullanıcılara aktar
                foreach (DateTime tarih in Enumerable.Range(0, (bitisTarihi - baslangicTarihi).Days + 1)
                    .Select(d => baslangicTarihi.AddDays(d))
                    .Where(t => t.DayOfWeek != DayOfWeek.Saturday && t.DayOfWeek != DayOfWeek.Sunday))
                {
                    monthCalendar1.AddBoldedDate(tarih); // Takvimde kalın göster

                    // Seçili kullanıcıları kontrol et
                    foreach (var item in clbAdSoyad.CheckedItems)
                    {
                        string selectedUser = item.ToString();

                        // Kullanıcı için tarih listesi oluşturulmuş mu kontrol edin
                        if (!userWorkDays.ContainsKey(selectedUser))
                        {
                            userWorkDays[selectedUser] = new List<DateTime>();
                        }

                        // Tarih yoksa listeye ekle
                        if (!userWorkDays[selectedUser].Contains(tarih))
                        {
                            userWorkDays[selectedUser].Add(tarih);
                        }
                    }
                }

                monthCalendar1.UpdateBoldedDates();
            }
            else
            {
                MessageBox.Show("Lütfen bir dönem seçin.");
            }
        }


        private void SecHaftaSonuGunleri()
        {
            if (cmbDonem.SelectedItem != null) // Null kontrolü ekleniyor
            {
                int secilenAy = DateTime.ParseExact(cmbDonem.SelectedItem.ToString(), "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                int secilenYil = (int)nudDonem.Value;

                DateTime baslangicTarihi = new DateTime(secilenYil, secilenAy, 1);
                DateTime bitisTarihi = baslangicTarihi.AddMonths(1).AddDays(-1);

                // Seçilen hafta sonu günlerini takvime ekle ve kullanıcılara aktar
                foreach (DateTime tarih in Enumerable.Range(0, (bitisTarihi - baslangicTarihi).Days + 1)
                    .Select(d => baslangicTarihi.AddDays(d))
                    .Where(t => t.DayOfWeek == DayOfWeek.Saturday || t.DayOfWeek == DayOfWeek.Sunday))
                {
                    monthCalendar1.AddBoldedDate(tarih); // Takvimde kalın göster

                    // Seçili kullanıcıları kontrol et
                    foreach (var item in clbAdSoyad.CheckedItems)
                    {
                        string selectedUser = item.ToString();

                        // Kullanıcı için tarih listesi oluşturulmuş mu kontrol edin
                        if (!userWorkDays.ContainsKey(selectedUser))
                        {
                            userWorkDays[selectedUser] = new List<DateTime>();
                        }

                        // Tarih yoksa listeye ekle
                        if (!userWorkDays[selectedUser].Contains(tarih))
                        {
                            userWorkDays[selectedUser].Add(tarih);
                        }
                    }
                }

                monthCalendar1.UpdateBoldedDates();
            }
            else
            {
                MessageBox.Show("Lütfen bir dönem seçin.");
            }
        }


        private void TemizleHaftaIciGunleri()
        {
            if (cmbDonem.SelectedItem != null)
            {
                int secilenAy = DateTime.ParseExact(cmbDonem.SelectedItem.ToString(), "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                int secilenYil = (int)nudDonem.Value;

                DateTime baslangicTarihi = new DateTime(secilenYil, secilenAy, 1);
                DateTime bitisTarihi = baslangicTarihi.AddMonths(1).AddDays(-1);

                // Seçilen hafta içi günlerini takvimden kaldır
                for (DateTime tarih = baslangicTarihi; tarih <= bitisTarihi; tarih = tarih.AddDays(1))
                {
                    if (tarih.DayOfWeek != DayOfWeek.Saturday && tarih.DayOfWeek != DayOfWeek.Sunday)
                    {
                        selectedDates.Remove(tarih);
                        monthCalendar1.RemoveBoldedDate(tarih);
                    }
                }
                monthCalendar1.UpdateBoldedDates();
            }
        }

        private void TemizleHaftaSonuGunleri()
        {
            if (cmbDonem.SelectedItem != null)
            {
                int secilenAy = DateTime.ParseExact(cmbDonem.SelectedItem.ToString(), "MMMM", System.Globalization.CultureInfo.CurrentCulture).Month;
                int secilenYil = (int)nudDonem.Value;

                DateTime baslangicTarihi = new DateTime(secilenYil, secilenAy, 1);
                DateTime bitisTarihi = baslangicTarihi.AddMonths(1).AddDays(-1);

                for (DateTime tarih = baslangicTarihi; tarih <= bitisTarihi; tarih = tarih.AddDays(1))
                {
                    if (tarih.DayOfWeek == DayOfWeek.Saturday || tarih.DayOfWeek == DayOfWeek.Sunday)
                    {
                        selectedDates.Remove(tarih);
                        monthCalendar1.RemoveBoldedDate(tarih);
                    }
                }
                monthCalendar1.UpdateBoldedDates();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbAdSoyad.Items.Count; i++)
            {
                clbAdSoyad.SetItemChecked(i, true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbAdSoyad.Items.Count; i++)
            {
                clbAdSoyad.SetItemChecked(i, false);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Dosya adı oluştur
            string dosyaAdi = $"{cmbDonem.SelectedItem} {nudDonem.Text}.xlsx";

            // Kayıt yerini kontrol et
            string locationPath = GetSavedSaveLocation();
            if (string.IsNullOrEmpty(locationPath) || !Directory.Exists(locationPath))
            {
                MessageBox.Show("Lütfen kaydetme yerini seçin.", "Kayıt Yeri Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seçilen kullanıcıları kontrol et
            List<string> selectedUsers = clbAdSoyad.CheckedItems.Cast<string>().ToList();
            if (!selectedUsers.Any())
            {
                MessageBox.Show("Lütfen en az bir çalışan seçin.", "Kullanıcı Seçimi Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dosya yolu oluştur
            string fullPath = Path.Combine(locationPath, dosyaAdi);

            // SaveToExcel metodunu çağır ve verileri kaydet
            SaveToExcel(fullPath, userWorkDays);
            SecimleriTemizle();

            // Kaydedilen dosyayı önizle
            ShowExcelPreview(fullPath);
        }

        private void SaveToExcel(string filePath, Dictionary<string, List<DateTime>> userWorkDays)
        {
            DateTime girisSaati = dtpGirisSaati.Value;
            DateTime cikisSaati = dtpCikisSaati.Value;

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Çalışma Günleri");
                worksheet.Cell(1, 1).Value = "TcNo";
                worksheet.Cell(1, 2).Value = "Tarih";
                worksheet.Cell(1, 3).Value = "Hareket";

                // Sütun başlıklarını ortala
                worksheet.Range("A1:C1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                int row = 2;

                // Kullanıcılar ve çalışma günleri için döngü
                foreach (var user in userWorkDays.Keys)
                {
                    var userRow = calisanlarData.AsEnumerable()
                                                 .FirstOrDefault(r => r["AdSoyad"].ToString() == user);

                    if (userRow != null)
                    {
                        string tcNo = userRow["TcNo"].ToString();

                        // Kullanıcının çalışma günlerini al
                        if (userWorkDays.TryGetValue(user, out var workDays))
                        {
                            foreach (var date in workDays)
                            {
                                // Giriş ve çıkış saatlerini gün ile birleştir
                                DateTime girisTarihi = new DateTime(date.Year, date.Month, date.Day, girisSaati.Hour, girisSaati.Minute, girisSaati.Second);
                                DateTime cikisTarihi = new DateTime(date.Year, date.Month, date.Day, cikisSaati.Hour, cikisSaati.Minute, cikisSaati.Second);

                                // Giriş bilgilerini yaz
                                worksheet.Cell(row, 1).Value = tcNo;
                                worksheet.Cell(row, 2).Value = girisTarihi;
                                worksheet.Cell(row, 3).Value = "G";
                                AlignCells(worksheet, row);
                                row++;

                                // Çıkış bilgilerini yaz
                                worksheet.Cell(row, 1).Value = tcNo;
                                worksheet.Cell(row, 2).Value = cikisTarihi;
                                worksheet.Cell(row, 3).Value = "C";
                                AlignCells(worksheet, row);
                                row++;
                            }
                        }
                    }
                }

                workbook.SaveAs(filePath);
            }
        }

        private void AlignCells(IXLWorksheet worksheet, int row)
        {
            worksheet.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }


        private void ShowExcelPreview(string filePath)
        {
            try
            {
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Excel dosyası açılamadı: {ex.Message}");
            }
        }

        private void btnSetSaveLocation_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Lütfen dosya kaydetme yerini seçin";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    saveLocationPath = folderBrowserDialog.SelectedPath;
                    SaveSaveLocation(saveLocationPath);
                    MessageBox.Show($"Kayıt yeri seçildi: {saveLocationPath}", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void GuncelleTakvim()
        {
            // ComboBox'tan seçilen ayı al
            string secilenAy = cmbDonem.SelectedItem?.ToString();
            int secilenYil = (int)nudDonem.Value;

            if (string.IsNullOrEmpty(secilenAy))
            {
                return; // Ay seçilmediyse çık
            }

            // Seçilen ayı numaraya çevir
            int ayNumarasi;
            switch (secilenAy)
            {
                case "OCAK":
                    ayNumarasi = 1;
                    break;
                case "ŞUBAT":
                    ayNumarasi = 2;
                    break;
                case "MART":
                    ayNumarasi = 3;
                    break;
                case "NİSAN":
                    ayNumarasi = 4;
                    break;
                case "MAYIS":
                    ayNumarasi = 5;
                    break;
                case "HAZİRAN":
                    ayNumarasi = 6;
                    break;
                case "TEMMUZ":
                    ayNumarasi = 7;
                    break;
                case "AĞUSTOS":
                    ayNumarasi = 8;
                    break;
                case "EYLÜL":
                    ayNumarasi = 9;
                    break;
                case "EKİM":
                    ayNumarasi = 10;
                    break;
                case "KASIM":
                    ayNumarasi = 11;
                    break;
                case "ARALIK":
                    ayNumarasi = 12;
                    break;
                default:
                    return; // Geçersiz ay
            }

            // Ayın ilk gününü seçili yıl ve ay ile oluştur
            DateTime secilenTarih = new DateTime(secilenYil, ayNumarasi, 1);

            // MonthCalendar'ı bu tarihe ayarla
            monthCalendar1.SetDate(secilenTarih);
        }

        private void clbAdSoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            monthCalendar1.RemoveAllBoldedDates();
            monthCalendar1.UpdateBoldedDates();
        }

        private void SecimleriTemizle()
        {
            // Kullanıcıların seçimlerini kaldır
            for (int i = 0; i < clbAdSoyad.Items.Count; i++)
            {
                clbAdSoyad.SetItemChecked(i, false);
            }

            // Firmayı seçmeyi temizle
            cmbFirma.SelectedIndex = -1; // veya boş bırakmak için null

            // Dönemi temizle
            cmbDonem.SelectedIndex = -1; // veya boş bırakmak için null

            cbHaftaIci.Checked = false;
            cbHaftaSonuDahil.Checked = false;

            // Kullanıcı çalışma günlerini temizle
            userWorkDays.Clear();

            // Takvimdeki bold tarihleri kaldır
            monthCalendar1.RemoveAllBoldedDates();
            monthCalendar1.UpdateBoldedDates(); // Değişiklikleri güncelle
        }

        private void btnFirmaveCalisan_Click(object sender, EventArgs e)
        {
            FirmaveCalisanIslemleri form = new FirmaveCalisanIslemleri();
            form.FormClosed += (s, args) =>
            {
                LoadFirmaData(); 
            };
            form.Show();
        }
    }
}