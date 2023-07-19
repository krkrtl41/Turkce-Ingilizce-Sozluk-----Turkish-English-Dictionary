namespace sozluk_son_hal
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            turkce = new TextBox();
            english = new TextBox();
            ekle = new Button();
            guncelle = new Button();
            sil = new Button();
            sozcuk_kutusu = new ListView();
            turkce_check = new CheckBox();
            english_check = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(90, 60);
            label1.Name = "label1";
            label1.Size = new Size(202, 20);
            label1.TabIndex = 0;
            label1.Text = "Türkçe Sözcük / Turkish Word";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(90, 142);
            label2.Name = "label2";
            label2.Size = new Size(215, 20);
            label2.TabIndex = 1;
            label2.Text = "İngilizce Sözcük / Englsih Word";
            // 
            // turkce
            // 
            turkce.Location = new Point(328, 53);
            turkce.Name = "turkce";
            turkce.Size = new Size(253, 27);
            turkce.TabIndex = 2;
            turkce.TextChanged += turkce_TextChanged;
            turkce.KeyPress += turkce_KeyPress;
            // 
            // english
            // 
            english.Location = new Point(328, 135);
            english.Name = "english";
            english.Size = new Size(253, 27);
            english.TabIndex = 3;
            english.TextChanged += english_TextChanged;
            english.KeyPress += turkce_KeyPress;
            // 
            // ekle
            // 
            ekle.Location = new Point(373, 219);
            ekle.Name = "ekle";
            ekle.Size = new Size(165, 62);
            ekle.TabIndex = 4;
            ekle.Text = "EKLE - INSERT";
            ekle.UseVisualStyleBackColor = true;
            ekle.Click += ekle_Click;
            // 
            // guncelle
            // 
            guncelle.Location = new Point(373, 301);
            guncelle.Name = "guncelle";
            guncelle.Size = new Size(165, 62);
            guncelle.TabIndex = 4;
            guncelle.Text = "GÜNCELLE - UPDATE";
            guncelle.UseVisualStyleBackColor = true;
            guncelle.Click += guncelle_Click;
            // 
            // sil
            // 
            sil.Location = new Point(373, 387);
            sil.Name = "sil";
            sil.Size = new Size(165, 62);
            sil.TabIndex = 4;
            sil.Text = "SİL - DELETE";
            sil.UseVisualStyleBackColor = true;
            sil.Click += sil_Click;
            // 
            // sozcuk_kutusu
            // 
            sozcuk_kutusu.BackColor = Color.PeachPuff;
            sozcuk_kutusu.GridLines = true;
            sozcuk_kutusu.Location = new Point(649, 53);
            sozcuk_kutusu.Name = "sozcuk_kutusu";
            sozcuk_kutusu.Size = new Size(400, 396);
            sozcuk_kutusu.TabIndex = 5;
            sozcuk_kutusu.UseCompatibleStateImageBehavior = false;
            // 
            // turkce_check
            // 
            turkce_check.AutoSize = true;
            turkce_check.Location = new Point(596, 60);
            turkce_check.Name = "turkce_check";
            turkce_check.Size = new Size(18, 17);
            turkce_check.TabIndex = 6;
            turkce_check.UseVisualStyleBackColor = true;
            turkce_check.CheckedChanged += turkce_check_CheckedChanged;
            // 
            // english_check
            // 
            english_check.AutoSize = true;
            english_check.Location = new Point(596, 141);
            english_check.Name = "english_check";
            english_check.Size = new Size(18, 17);
            english_check.TabIndex = 7;
            english_check.UseVisualStyleBackColor = true;
            english_check.CheckedChanged += turkce_check_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1113, 494);
            Controls.Add(english_check);
            Controls.Add(turkce_check);
            Controls.Add(sozcuk_kutusu);
            Controls.Add(sil);
            Controls.Add(guncelle);
            Controls.Add(ekle);
            Controls.Add(english);
            Controls.Add(turkce);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Türkçe - İngilizce Sözcük / Turkish - English Dictionary";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox turkce;
        private TextBox english;
        private Button ekle;
        private Button guncelle;
        private Button sil;
        private ListView sozcuk_kutusu;
        private CheckBox turkce_check;
        private CheckBox english_check;
    }
}