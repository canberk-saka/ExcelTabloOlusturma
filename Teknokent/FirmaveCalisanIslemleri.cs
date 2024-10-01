using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Teknokent
{
    public partial class FirmaveCalisanIslemleri : Form
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=DESKTOP-BAP4RDU\\SQLEXPRESS02;Initial Catalog=FirmaCalisanBilgileri;Integrated Security=True;";

        public FirmaveCalisanIslemleri()
        {
            InitializeComponent();
            LoadFirmalarListBox();
            LoadCalisanlarListBox();
            LoadFirmalarComboBox();
            cbFirmalar.SelectedIndex = -1;
        }

        // SQL Non-Query işlemleri (INSERT, UPDATE, DELETE) için ortak metod
        private void ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        // SQL Query işlemleri (SELECT) için ortak metod
        private DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }

        private void LoadFirmalarListBox()
        {
            DataTable dt = ExecuteQuery("SELECT * FROM Firmalar");
            lbFirmalar.DataSource = dt;
            lbFirmalar.DisplayMember = "FirmaAdı";
            lbFirmalar.ValueMember = "id";
        }

        private void LoadCalisanlarListBox()
        {
            if (cbFirmalar.SelectedValue != null)
            {
                string query = "SELECT * FROM Calisanlar WHERE FirmaID = @firmaID";
                SqlParameter[] parameters = {
                    new SqlParameter("@firmaID", cbFirmalar.SelectedValue)
                };

                DataTable dt = ExecuteQuery(query, parameters);
                lbCalisanlar.DataSource = dt;
                lbCalisanlar.DisplayMember = "AdSoyad";
                lbCalisanlar.ValueMember = "id";
            }
        }


        private void LoadFirmalarComboBox()
        {
            DataTable dt = ExecuteQuery("SELECT id, FirmaAdı FROM Firmalar");
            cbFirmalar.DataSource = dt;
            cbFirmalar.DisplayMember = "FirmaAdı"; // Gösterilecek olan sütun
            cbFirmalar.ValueMember = "id"; // Seçildiğinde tutulacak olan değer
        }

        // Firma ekleme
        private void btnEkleFirma_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirmaAdi.Text))
            {
                MessageBox.Show("Lütfen firma adını girin.");
                return;
            }

            try
            {
                string query = "INSERT INTO Firmalar (FirmaAdı) VALUES (@firmaAdı)";
                SqlParameter[] parameters = {
                    new SqlParameter("@firmaAdı", txtFirmaAdi.Text)
                };

                ExecuteNonQuery(query, parameters);
                LoadFirmalarListBox();
                LoadFirmalarComboBox();
                LoadCalisanlarListBox();
                txtFirmaAdi.Clear();
                MessageBox.Show("Firma başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        // Çalışan ekleme
        private void btnEkleCalisan_Click(object sender, EventArgs e)
        {
            if (cbFirmalar.SelectedValue == null || string.IsNullOrWhiteSpace(txtAdSoyad.Text) || string.IsNullOrWhiteSpace(txtTcNo.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            try
            {
                string query = "INSERT INTO Calisanlar (FirmaID, AdSoyad, TcNo) VALUES (@firmaID, @adSoyad, @tcNo)";
                SqlParameter[] parameters = {
                    new SqlParameter("@firmaID", cbFirmalar.SelectedValue),
                    new SqlParameter("@adSoyad", txtAdSoyad.Text),
                    new SqlParameter("@tcNo", txtTcNo.Text)
                };

                ExecuteNonQuery(query, parameters);
                LoadCalisanlarListBox();
                txtAdSoyad.Clear();
                txtTcNo.Clear();
                MessageBox.Show("Çalışan başarıyla eklendi.");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        // Çalışan silme
        private void btnSilCalisan_Click(object sender, EventArgs e)
        {
            if (lbCalisanlar.SelectedValue == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz çalışanı seçin.");
                return;
            }

            try
            {
                string query = "DELETE FROM Calisanlar WHERE id = @id";
                SqlParameter[] parameters = {
                    new SqlParameter("@id", lbCalisanlar.SelectedValue)
                };

                ExecuteNonQuery(query, parameters);
                LoadCalisanlarListBox();
                MessageBox.Show("Çalışan başarıyla silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        // Çalışan güncelleme
        private void btnGuncelleCalisan_Click(object sender, EventArgs e)
        {
            if (lbCalisanlar.SelectedValue == null)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz çalışanı seçin.");
                return;
            }

            try
            {
                string query = "UPDATE Calisanlar SET FirmaID = @firmaID, AdSoyad = @adSoyad, TcNo = @tcNo WHERE id = @id";
                SqlParameter[] parameters = {
                    new SqlParameter("@firmaID", cbFirmalar.SelectedValue),
                    new SqlParameter("@adSoyad", txtAdSoyad.Text),
                    new SqlParameter("@tcNo", txtTcNo.Text),
                    new SqlParameter("@id", lbCalisanlar.SelectedValue)
                };

                ExecuteNonQuery(query, parameters);
                LoadCalisanlarListBox();
                txtAdSoyad.Clear();
                txtTcNo.Clear();
                MessageBox.Show("Çalışan başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        // Firma silme
        private void btnSilFirma_Click(object sender, EventArgs e)
        {
            if (lbFirmalar.SelectedValue == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz firmayı seçin.");
                return;
            }

            try
            {
                string query = "DELETE FROM Firmalar WHERE id = @id";
                SqlParameter[] parameters = {
                    new SqlParameter("@id", lbFirmalar.SelectedValue)
                };

                ExecuteNonQuery(query, parameters);
                LoadFirmalarListBox();
                LoadFirmalarComboBox();
                MessageBox.Show("Firma başarıyla silindi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }

        // Firma güncelleme
        private void btnGuncelleFirma_Click(object sender, EventArgs e)
        {
            if (lbFirmalar.SelectedValue == null)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz firmayı seçin.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFirmaAdi.Text))
            {
                MessageBox.Show("Lütfen firma adını girin.");
                return;
            }

            try
            {
                string query = "UPDATE Firmalar SET FirmaAdı = @firmaAdı WHERE id = @id";
                SqlParameter[] parameters = {
                    new SqlParameter("@firmaAdı", txtFirmaAdi.Text),
                    new SqlParameter("@id", lbFirmalar.SelectedValue)
                };

                ExecuteNonQuery(query, parameters);
                LoadFirmalarListBox();
                LoadFirmalarComboBox();
                txtFirmaAdi.Clear();
                MessageBox.Show("Firma başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
        }


        private void cbFirmalar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbFirmalar.SelectedValue != null)
            {
                string query = "SELECT * FROM Calisanlar WHERE FirmaID = @firmaID";
                SqlParameter[] parameters = {
                    new SqlParameter("@firmaID", cbFirmalar.SelectedValue)
                };

                DataTable dt = ExecuteQuery(query, parameters);
                lbCalisanlar.DataSource = dt;
                lbCalisanlar.DisplayMember = "AdSoyad";
                lbCalisanlar.ValueMember = "id";
            }
        }
    }
}
