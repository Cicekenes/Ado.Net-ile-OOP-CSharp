using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_İle_CRUD_işlemleri
{
    public partial class Form1 : Form
    {
        
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Eleman elmn = new Eleman();
            elmn.AD = txtAd.Text;
            elmn.SOYAD = txtSoyad.Text;
            elmn.MESLEK = txtMeslek.Text;
            elmn.MAAS = short.Parse(txtMaas.Text);
            elmn.SEHIR = txtSehir.Text;
            elmn.UNIVERSITE = txtMezuniyet.Text;
            bgl.KitapEkle(elmn);
            MessageBox.Show("Eleman Kaydedildi!");
            dataGridView1.DataSource = bgl.Listele();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bgl.Listele();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Eleman el = new Eleman();
            el.ID = short.Parse(txtID.Text);
            bgl.KitapSil(el);
            MessageBox.Show("Eleman Silindi!");
            dataGridView1.DataSource = bgl.Listele();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bgl.Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Eleman elmn = new Eleman();
            elmn.AD = txtAd.Text;
            elmn.SOYAD = txtSoyad.Text;
            elmn.MESLEK = txtMeslek.Text;
            elmn.MAAS = short.Parse(txtMaas.Text);
            elmn.SEHIR = txtSehir.Text;
            elmn.UNIVERSITE = txtMezuniyet.Text;
            elmn.ID = short.Parse(txtID.Text);
            bgl.KitapGuncelle(elmn);
            MessageBox.Show("Eleman Güncellendi!");
            dataGridView1.DataSource = bgl.Listele();

        }
    }
}
