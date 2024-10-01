namespace Teknokent
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.clbAdSoyad = new System.Windows.Forms.CheckedListBox();
            this.cmbFirma = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.button5 = new System.Windows.Forms.Button();
            this.dtpGirisSaati = new System.Windows.Forms.DateTimePicker();
            this.dtpCikisSaati = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDonem = new System.Windows.Forms.ComboBox();
            this.nudDonem = new System.Windows.Forms.NumericUpDown();
            this.cbHaftaIci = new System.Windows.Forms.CheckBox();
            this.cbHaftaSonuDahil = new System.Windows.Forms.CheckBox();
            this.btnSetSaveLocation = new System.Windows.Forms.Button();
            this.btnFirmaveCalisan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonem)).BeginInit();
            this.SuspendLayout();
            // 
            // clbAdSoyad
            // 
            this.clbAdSoyad.FormattingEnabled = true;
            this.clbAdSoyad.Location = new System.Drawing.Point(45, 172);
            this.clbAdSoyad.Name = "clbAdSoyad";
            this.clbAdSoyad.Size = new System.Drawing.Size(232, 327);
            this.clbAdSoyad.TabIndex = 0;
            this.clbAdSoyad.SelectedIndexChanged += new System.EventHandler(this.clbAdSoyad_SelectedIndexChanged);
            // 
            // cmbFirma
            // 
            this.cmbFirma.FormattingEnabled = true;
            this.cmbFirma.Location = new System.Drawing.Point(145, 100);
            this.cmbFirma.Name = "cmbFirma";
            this.cmbFirma.Size = new System.Drawing.Size(121, 24);
            this.cmbFirma.TabIndex = 1;
            this.cmbFirma.SelectedIndexChanged += new System.EventHandler(this.cmbFirma_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(45, 133);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Hepsini Seç";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(154, 133);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(112, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Seçimi Kaldır";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Firma Seçin:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(405, 232);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowToday = false;
            this.monthCalendar1.TabIndex = 5;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(474, 437);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(103, 34);
            this.button5.TabIndex = 6;
            this.button5.Text = "Tablo Oluştur";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dtpGirisSaati
            // 
            this.dtpGirisSaati.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpGirisSaati.Location = new System.Drawing.Point(456, 78);
            this.dtpGirisSaati.Name = "dtpGirisSaati";
            this.dtpGirisSaati.ShowUpDown = true;
            this.dtpGirisSaati.Size = new System.Drawing.Size(200, 22);
            this.dtpGirisSaati.TabIndex = 7;
            this.dtpGirisSaati.Value = new System.DateTime(2024, 9, 17, 8, 30, 0, 0);
            // 
            // dtpCikisSaati
            // 
            this.dtpCikisSaati.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCikisSaati.Location = new System.Drawing.Point(456, 118);
            this.dtpCikisSaati.Name = "dtpCikisSaati";
            this.dtpCikisSaati.ShowUpDown = true;
            this.dtpCikisSaati.Size = new System.Drawing.Size(200, 22);
            this.dtpCikisSaati.TabIndex = 8;
            this.dtpCikisSaati.Value = new System.DateTime(2024, 9, 17, 17, 30, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Giriş Saati:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Çıkış Saati:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(359, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Dönem Seçin:";
            // 
            // cmbDonem
            // 
            this.cmbDonem.FormattingEnabled = true;
            this.cmbDonem.Items.AddRange(new object[] {
            "OCAK",
            "ŞUBAT",
            "MART",
            "NİSAN",
            "MAYIS",
            "HAZİRAN",
            "TEMMUZ",
            "AĞUSTOS",
            "EYLÜL",
            "EKİM",
            "KASIM",
            "ARALIK"});
            this.cmbDonem.Location = new System.Drawing.Point(456, 36);
            this.cmbDonem.Name = "cmbDonem";
            this.cmbDonem.Size = new System.Drawing.Size(121, 24);
            this.cmbDonem.TabIndex = 12;
            this.cmbDonem.SelectedIndexChanged += new System.EventHandler(this.cmbDonem_SelectedIndexChanged);
            // 
            // nudDonem
            // 
            this.nudDonem.Location = new System.Drawing.Point(589, 37);
            this.nudDonem.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.nudDonem.Name = "nudDonem";
            this.nudDonem.Size = new System.Drawing.Size(67, 22);
            this.nudDonem.TabIndex = 13;
            this.nudDonem.ValueChanged += new System.EventHandler(this.nudDonem_ValueChanged);
            // 
            // cbHaftaIci
            // 
            this.cbHaftaIci.AutoSize = true;
            this.cbHaftaIci.Location = new System.Drawing.Point(456, 163);
            this.cbHaftaIci.Name = "cbHaftaIci";
            this.cbHaftaIci.Size = new System.Drawing.Size(149, 20);
            this.cbHaftaIci.TabIndex = 14;
            this.cbHaftaIci.Text = "Hafta içi Günleri Seç";
            this.cbHaftaIci.UseVisualStyleBackColor = true;
            this.cbHaftaIci.CheckedChanged += new System.EventHandler(this.cbHaftaIci_CheckedChanged);
            // 
            // cbHaftaSonuDahil
            // 
            this.cbHaftaSonuDahil.AutoSize = true;
            this.cbHaftaSonuDahil.Location = new System.Drawing.Point(456, 189);
            this.cbHaftaSonuDahil.Name = "cbHaftaSonuDahil";
            this.cbHaftaSonuDahil.Size = new System.Drawing.Size(184, 20);
            this.cbHaftaSonuDahil.TabIndex = 15;
            this.cbHaftaSonuDahil.Text = "Hafta Sonlarını da Dahil Et";
            this.cbHaftaSonuDahil.UseVisualStyleBackColor = true;
            this.cbHaftaSonuDahil.CheckedChanged += new System.EventHandler(this.cbHaftaSonuDahil_CheckedChanged);
            // 
            // btnSetSaveLocation
            // 
            this.btnSetSaveLocation.Location = new System.Drawing.Point(121, 7);
            this.btnSetSaveLocation.Name = "btnSetSaveLocation";
            this.btnSetSaveLocation.Size = new System.Drawing.Size(82, 63);
            this.btnSetSaveLocation.TabIndex = 18;
            this.btnSetSaveLocation.Text = "Kaydetme Yeri Seç";
            this.btnSetSaveLocation.UseVisualStyleBackColor = true;
            this.btnSetSaveLocation.Click += new System.EventHandler(this.btnSetSaveLocation_Click);
            // 
            // btnFirmaveCalisan
            // 
            this.btnFirmaveCalisan.Location = new System.Drawing.Point(26, 7);
            this.btnFirmaveCalisan.Name = "btnFirmaveCalisan";
            this.btnFirmaveCalisan.Size = new System.Drawing.Size(75, 58);
            this.btnFirmaveCalisan.TabIndex = 19;
            this.btnFirmaveCalisan.Text = "Firma ve Çalışan İşlemleri";
            this.btnFirmaveCalisan.UseVisualStyleBackColor = true;
            this.btnFirmaveCalisan.Click += new System.EventHandler(this.btnFirmaveCalisan_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(788, 517);
            this.Controls.Add(this.btnFirmaveCalisan);
            this.Controls.Add(this.btnSetSaveLocation);
            this.Controls.Add(this.cbHaftaSonuDahil);
            this.Controls.Add(this.cbHaftaIci);
            this.Controls.Add(this.nudDonem);
            this.Controls.Add(this.cmbDonem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpCikisSaati);
            this.Controls.Add(this.dtpGirisSaati);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cmbFirma);
            this.Controls.Add(this.clbAdSoyad);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.nudDonem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbFirmaAdi;
        private System.Windows.Forms.Label lblFirmaAdi;
        private System.Windows.Forms.TextBox txtDonem;
        private System.Windows.Forms.Label lblDonem;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckedListBox clbAdSoyad;
        private System.Windows.Forms.ComboBox cmbFirma;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.DateTimePicker dtpGirisSaati;
        private System.Windows.Forms.DateTimePicker dtpCikisSaati;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDonem;
        private System.Windows.Forms.NumericUpDown nudDonem;
        private System.Windows.Forms.CheckBox cbHaftaIci;
        private System.Windows.Forms.CheckBox cbHaftaSonuDahil;
        private System.Windows.Forms.Button btnSetSaveLocation;
        private System.Windows.Forms.Button btnFirmaveCalisan;
    }
}

