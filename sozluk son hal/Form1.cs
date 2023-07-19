using System.Data.OleDb;

namespace sozluk_son_hal
{
    public partial class Form1 : Form
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=C:\\Users\\Hp\\Documents\\Sozluk.accdb");
        //Data Source=C:\\Users\\Hp\\Documents\\Sozluk.accdb <= Bu projemi MS Acess ile yaptým ve bu benim Access kaynaðým. Eðer siz de projenizi Access ile yapýyorsanýz, kendi veri tabanýnýza göre düzenleyebilirsiniz. ///// I have created my project with MS Access and this is my Access source. If you are doing your project with Access, you can edit your project according to your database.
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
            this.CenterToScreen();

            sozcuk_kutusu.FullRowSelect = false;
            sozcuk_kutusu.CheckBoxes = false;
            sozcuk_kutusu.GridLines = true;
            sozcuk_kutusu.AllowColumnReorder = false;
            sozcuk_kutusu.MultiSelect = true;
            sozcuk_kutusu.View = View.Details;
            sozcuk_kutusu.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            sozcuk_kutusu.Sorting = SortOrder.Ascending;

            sozcuk_kutusu.Columns.Add("Türkçe / Turkish", 200);
            sozcuk_kutusu.Columns.Add("Ýngilizce / English", 200);

            baglanti.Open();
            OleDbCommand ara = new OleDbCommand("SELECT * FROM sozluk", baglanti);
            OleDbDataReader oku = ara.ExecuteReader();
            while (oku.Read())
            {
                string[] kayit = { (string)oku["turkce"], (string)oku["english"] };
                ListViewItem kaydetme = new ListViewItem(kayit);
                sozcuk_kutusu.Items.Add(kaydetme);
            }
            baglanti.Close();
        }

        private void turkce_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (turkce.Text.Trim() == "" || english.Text.Trim() == "")
                {
                    MessageBox.Show("Her iki alanýn da dolu olduðundan emin olunuz.", "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    baglanti.Open();
                    OleDbCommand ekleme = new OleDbCommand("INSERT INTO sozluk VALUES ('" + turkce.Text.ToLower() + "', '" + english.Text.ToLower() + "')", baglanti);
                    ekleme.ExecuteNonQuery();
                    Arama();
                    baglanti.Close();
                    MessageBox.Show("Kelimeler eklendi.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    turkce.Clear();
                    english.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluþtu." + "\n" + ex.Message, "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (turkce.Text.Trim() == "" || english.Text.Trim() == "")
                {
                    MessageBox.Show("Her iki alanýn da dolu olduðundan emin olunuz.", "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    baglanti.Open();
                    OleDbCommand guncelleme = new OleDbCommand("UPDATE sozluk SET english = '" + english.Text.ToLower() + "' WHERE turkce = '" + turkce.Text.ToLower() + "'", baglanti);
                    int kayit = guncelleme.ExecuteNonQuery();
                    if (kayit == 0)
                    {
                        MessageBox.Show("Böyle bir kayýt bulunamadý. Türkçe kýsmýnda harf hatasý yapmadýðýnýzdan ve böyle bir kayýt olduðundan emin olunuz.", "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Arama();
                        MessageBox.Show("Kayýt güncellendi.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        turkce.Clear();
                        english.Clear();
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluþtu." + "\n" + ex.Message, "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sil_Click(object sender, EventArgs e)
        {
            try
            {
                if (turkce.Text.Trim() == "")
                {
                    MessageBox.Show("Türkçe kýsmýný doldurunuz.", "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    baglanti.Open();
                    OleDbCommand silme = new OleDbCommand("DELETE FROM sozluk WHERE turkce = '" + turkce.Text.ToLower() + "'", baglanti);
                    int kayit = silme.ExecuteNonQuery();
                    if (kayit == 0)
                    {
                        MessageBox.Show("Böyle bir kayýt bulunamadý. Türkçe kýsmýnda harf hatasý yapmadýðýnýzdan ve böyle bir kayýt olduðundan emin olunuz.", "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Arama();
                        MessageBox.Show("Kayýt silindi.", "BÝLGÝ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        turkce.Clear();
                        english.Clear();
                    }
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluþtu." + "\n" + ex.Message, "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void turkce_check_CheckedChanged(object sender, EventArgs e)
        {
            if (turkce_check.Checked == true && english_check.Checked == true)
            {
                turkce.Enabled = false;
                english.Enabled = false;
            }
            else if (turkce_check.Checked == true)
            {
                english.Enabled = false;
                turkce.Enabled = true;
            }
            else if (english_check.Checked)
            {
                turkce.Enabled = false;
                english.Enabled = true;
            }
            else
            {
                turkce.Enabled = true;
                english.Enabled = true;
            }
        }

        private void turkce_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (turkce_check.Checked == true)
                {
                    sozcuk_kutusu.Items.Clear();
                    baglanti.Open();
                    OleDbCommand arama = new OleDbCommand("SELECT * FROM sozluk WHERE turkce LIKE '" + turkce.Text + "%'", baglanti);
                    OleDbDataReader okuma = arama.ExecuteReader();
                    while (okuma.Read())
                    {
                        object a = okuma["turkce"];
                        object b = okuma["english"];
                        string turkce_kelime = (string)a;
                        string ingilizce_kelime = (string)b;
                        string[] kayit = { turkce_kelime, ingilizce_kelime };
                        ListViewItem kaydetme = new ListViewItem(kayit);
                        sozcuk_kutusu.Items.Add(kaydetme);
                    }
                    baglanti.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata oluþtu." + "\n" + ex.Message, "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void english_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (english_check.Checked)
                {
                    sozcuk_kutusu.Items.Clear();
                    baglanti.Open();
                    OleDbCommand arama = new OleDbCommand("SELECT * FROM sozluk WHERE english LIKE '" + english.Text + "%'", baglanti);
                    OleDbDataReader okuma = arama.ExecuteReader();
                    while (okuma.Read())
                    {
                        object a = okuma["turkce"];
                        object b = okuma["english"];
                        string turkce_kelime = (string)a;
                        string ingilizce_kelime = (string)b;
                        string[] kayit = {turkce_kelime, ingilizce_kelime };
                        ListViewItem kaydetme = new ListViewItem(kayit);
                        sozcuk_kutusu.Items.Add(kaydetme);
                    }
                    baglanti.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata oluþtu." + "\n" + ex.Message, "UYARI !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Arama()
        {
            sozcuk_kutusu.Items.Clear();
            OleDbCommand ara = new OleDbCommand("SELECT * FROM sozluk", baglanti);
            OleDbDataReader oku = ara.ExecuteReader();
            while(oku.Read())
            {
                string[] kayit = { (string)oku["turkce"], (string)oku["english"] };
                ListViewItem kaydet = new ListViewItem(kayit);
                sozcuk_kutusu.Items.Add(kaydet);
            }
        }
    }
}