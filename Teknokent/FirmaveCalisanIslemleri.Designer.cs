namespace Teknokent
{
    partial class FirmaveCalisanIslemleri
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
            this.lbFirmalar = new System.Windows.Forms.ListBox();
            this.txtFirmaAdi = new System.Windows.Forms.TextBox();
            this.btnEkleFirma = new System.Windows.Forms.Button();
            this.btnGuncelleFirma = new System.Windows.Forms.Button();
            this.btnSilFirma = new System.Windows.Forms.Button();
            this.lbCalisanlar = new System.Windows.Forms.ListBox();
            this.cbFirmalar = new System.Windows.Forms.ComboBox();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.txtTcNo = new System.Windows.Forms.TextBox();
            this.btnSilCalisan = new System.Windows.Forms.Button();
            this.btnGuncelleCalisan = new System.Windows.Forms.Button();
            this.btnEkleCalisan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbFirmalar
            // 
            this.lbFirmalar.FormattingEnabled = true;
            this.lbFirmalar.ItemHeight = 16;
            this.lbFirmalar.Location = new System.Drawing.Point(85, 12);
            this.lbFirmalar.Name = "lbFirmalar";
            this.lbFirmalar.Size = new System.Drawing.Size(156, 132);
            this.lbFirmalar.TabIndex = 0;
            // 
            // txtFirmaAdi
            // 
            this.txtFirmaAdi.Location = new System.Drawing.Point(128, 177);
            this.txtFirmaAdi.Name = "txtFirmaAdi";
            this.txtFirmaAdi.Size = new System.Drawing.Size(113, 22);
            this.txtFirmaAdi.TabIndex = 1;
            // 
            // btnEkleFirma
            // 
            this.btnEkleFirma.Location = new System.Drawing.Point(128, 225);
            this.btnEkleFirma.Name = "btnEkleFirma";
            this.btnEkleFirma.Size = new System.Drawing.Size(86, 39);
            this.btnEkleFirma.TabIndex = 2;
            this.btnEkleFirma.Text = "Firma Ekle";
            this.btnEkleFirma.UseVisualStyleBackColor = true;
            this.btnEkleFirma.Click += new System.EventHandler(this.btnEkleFirma_Click_1);
            // 
            // btnGuncelleFirma
            // 
            this.btnGuncelleFirma.Location = new System.Drawing.Point(128, 344);
            this.btnGuncelleFirma.Name = "btnGuncelleFirma";
            this.btnGuncelleFirma.Size = new System.Drawing.Size(86, 47);
            this.btnGuncelleFirma.TabIndex = 3;
            this.btnGuncelleFirma.Text = "Firmayı Güncelle";
            this.btnGuncelleFirma.UseVisualStyleBackColor = true;
            this.btnGuncelleFirma.Click += new System.EventHandler(this.btnGuncelleFirma_Click);
            // 
            // btnSilFirma
            // 
            this.btnSilFirma.Location = new System.Drawing.Point(128, 292);
            this.btnSilFirma.Name = "btnSilFirma";
            this.btnSilFirma.Size = new System.Drawing.Size(86, 37);
            this.btnSilFirma.TabIndex = 4;
            this.btnSilFirma.Text = "Firmayı Sil";
            this.btnSilFirma.UseVisualStyleBackColor = true;
            this.btnSilFirma.Click += new System.EventHandler(this.btnSilFirma_Click);
            // 
            // lbCalisanlar
            // 
            this.lbCalisanlar.FormattingEnabled = true;
            this.lbCalisanlar.ItemHeight = 16;
            this.lbCalisanlar.Location = new System.Drawing.Point(464, 12);
            this.lbCalisanlar.Name = "lbCalisanlar";
            this.lbCalisanlar.Size = new System.Drawing.Size(156, 132);
            this.lbCalisanlar.TabIndex = 5;
            // 
            // cbFirmalar
            // 
            this.cbFirmalar.FormattingEnabled = true;
            this.cbFirmalar.Location = new System.Drawing.Point(499, 185);
            this.cbFirmalar.Name = "cbFirmalar";
            this.cbFirmalar.Size = new System.Drawing.Size(121, 24);
            this.cbFirmalar.TabIndex = 6;
            this.cbFirmalar.SelectedIndexChanged += new System.EventHandler(this.cbFirmalar_SelectedIndexChanged_1);
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.Location = new System.Drawing.Point(497, 237);
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(123, 22);
            this.txtAdSoyad.TabIndex = 7;
            // 
            // txtTcNo
            // 
            this.txtTcNo.Location = new System.Drawing.Point(499, 286);
            this.txtTcNo.Name = "txtTcNo";
            this.txtTcNo.Size = new System.Drawing.Size(121, 22);
            this.txtTcNo.TabIndex = 8;
            // 
            // btnSilCalisan
            // 
            this.btnSilCalisan.Location = new System.Drawing.Point(501, 345);
            this.btnSilCalisan.Name = "btnSilCalisan";
            this.btnSilCalisan.Size = new System.Drawing.Size(100, 46);
            this.btnSilCalisan.TabIndex = 11;
            this.btnSilCalisan.Text = "Çalışanı Sil";
            this.btnSilCalisan.UseVisualStyleBackColor = true;
            this.btnSilCalisan.Click += new System.EventHandler(this.btnSilCalisan_Click);
            // 
            // btnGuncelleCalisan
            // 
            this.btnGuncelleCalisan.Location = new System.Drawing.Point(607, 345);
            this.btnGuncelleCalisan.Name = "btnGuncelleCalisan";
            this.btnGuncelleCalisan.Size = new System.Drawing.Size(100, 47);
            this.btnGuncelleCalisan.TabIndex = 10;
            this.btnGuncelleCalisan.Text = "Çalışanı Güncelle";
            this.btnGuncelleCalisan.UseVisualStyleBackColor = true;
            this.btnGuncelleCalisan.Click += new System.EventHandler(this.btnGuncelleCalisan_Click);
            // 
            // btnEkleCalisan
            // 
            this.btnEkleCalisan.Location = new System.Drawing.Point(399, 344);
            this.btnEkleCalisan.Name = "btnEkleCalisan";
            this.btnEkleCalisan.Size = new System.Drawing.Size(96, 46);
            this.btnEkleCalisan.TabIndex = 9;
            this.btnEkleCalisan.Text = "Çalışan Ekle";
            this.btnEkleCalisan.UseVisualStyleBackColor = true;
            this.btnEkleCalisan.Click += new System.EventHandler(this.btnEkleCalisan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Firma Adı Gir";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(375, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Çalışanın Firması";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Çalışan Ad Soyad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(413, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Çalışan Tc";
            // 
            // FirmaveCalisanIslemleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSilCalisan);
            this.Controls.Add(this.btnGuncelleCalisan);
            this.Controls.Add(this.btnEkleCalisan);
            this.Controls.Add(this.txtTcNo);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.cbFirmalar);
            this.Controls.Add(this.lbCalisanlar);
            this.Controls.Add(this.btnSilFirma);
            this.Controls.Add(this.btnGuncelleFirma);
            this.Controls.Add(this.btnEkleFirma);
            this.Controls.Add(this.txtFirmaAdi);
            this.Controls.Add(this.lbFirmalar);
            this.Name = "FirmaveCalisanIslemleri";
            this.Text = "FirmaveCalisanİslemleri";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbFirmalar;
        private System.Windows.Forms.TextBox txtFirmaAdi;
        private System.Windows.Forms.Button btnEkleFirma;
        private System.Windows.Forms.Button btnGuncelleFirma;
        private System.Windows.Forms.Button btnSilFirma;
        private System.Windows.Forms.ListBox lbCalisanlar;
        private System.Windows.Forms.ComboBox cbFirmalar;
        private System.Windows.Forms.TextBox txtAdSoyad;
        private System.Windows.Forms.TextBox txtTcNo;
        private System.Windows.Forms.Button btnSilCalisan;
        private System.Windows.Forms.Button btnGuncelleCalisan;
        private System.Windows.Forms.Button btnEkleCalisan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}