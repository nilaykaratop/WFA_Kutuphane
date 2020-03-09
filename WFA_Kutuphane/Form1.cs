using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace WFA_Kutuphane
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        void Temizle()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Text = string.Empty;

                }
            }
        }

        void Kontrol()
        {
            foreach (Control ctrl in groupBox1.Controls)
            {
                if (ctrl.Text == "")
                {
                    provider.SetError(ctrl, "bu alan boş geçilemez");

                }
            }
        }
        string[] kitapturleri = { "KORKU", "BİLİM KURGU", "TARİH", "ROMAN", "HİKAYE" };
        ErrorProvider provider = new ErrorProvider();
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbTur.Items.AddRange(kitapturleri);
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {

            Kutuphane kutuphane = new Kutuphane();

            kutuphane.kitapadi = txtKitapAdi.Text;
            kutuphane.yazaradi = txtYazarAdi.Text;
            kutuphane.yayinevi = txtYayinEvi.Text;
            kutuphane.isbnNo = int.Parse(txtISBNNo.Text);
            lstKitaplar.Items.Add(kutuphane);

            Kontrol();
            Temizle();



        }

        private void tsmSil_Click(object sender, EventArgs e)
        {
            if (lstKitaplar.SelectedItems.Count==0)
            {
                MessageBox.Show("lütfen bir eleman seçiniz");
                return;
            }
            DialogResult dr = MessageBox.Show("Kayıt kalıcı olarak silinecek!\nİşleme Devam Etmek İstiyormusunuz?", "Kayıt Silme Bildirimi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                lstKitaplar.Items.Remove(lstKitaplar.SelectedItem);
            }
        }
        Kutuphane guncellenecek;
        int index = 0;
        private void tsmDuzenle_Click(object sender, EventArgs e)
        {
            if(lstKitaplar.SelectedItems.Count==0)
            {
                MessageBox.Show("lütfen eleman seçiniz");
                return;
               
            }
            index = lstKitaplar.SelectedIndex;
            guncellenecek = (Kutuphane)lstKitaplar.SelectedItem;
            txtISBNNo.Text = guncellenecek.isbnNo.ToString();
            txtKitapAdi.Text = guncellenecek.kitapadi;
            txtYayinEvi.Text = guncellenecek.yayinevi;
            txtYazarAdi.Text = guncellenecek.yazaradi;

        }
        
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncellenecek.yazaradi = txtYazarAdi.Text;
            guncellenecek.kitapadi = txtKitapAdi.Text;
            guncellenecek.isbnNo = int.Parse(txtISBNNo.Text);
            guncellenecek.yayinevi = txtYayinEvi.Text;
            Temizle();
            lstKitaplar.Items.Remove(index);
            lstKitaplar.Items.Insert(index, guncellenecek);
            
        }
    }
}
