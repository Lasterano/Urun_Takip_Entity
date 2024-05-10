using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Urun_Takip_Entitiy
{
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DbUrunEntities db =new DbUrunEntities();
        //SqlConnection baglanti = new SqlConnection(@"Data Source=BORAPC;
           //Initial Catalog=DbUrun;Integrated Security=True");
           void urunListesi()
        {
            var degerler = from x in db.TBLURUNLER
                           select new
                           {
                               x.UrunId,
                               x.UrunAd,
                               x.Stok,
                               x.AlisFiyat,
                               x.SatisFiyat,
                               x.TBLKATEGORI.Ad

                           };
            dataGridView1.DataSource = degerler.ToList();
        }
        void temizle()
        {
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";
            TxtStok.Text = "";
            TxtID.Text = "";
            TxtUrunAd.Text = "";
        }

        private void FrmUrun_Load(object sender, EventArgs e)
        {
            urunListesi();
            comboBox1.DataSource= db.TBLKATEGORI.ToList();
            comboBox1.ValueMember = "ID";
            comboBox1.DisplayMember = "Ad";
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            urunListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLURUNLER t=new TBLURUNLER();
            //t.UrunId = int.Parse(TxtID.Text);
            t.UrunAd=TxtUrunAd.Text;
            t.Stok = short.Parse(TxtStok.Text);
            t.AlisFiyat=decimal.Parse(TxtAlisFiyat.Text);
            t.SatisFiyat=decimal.Parse (TxtSatisFiyat.Text);
            t.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            db.TBLURUNLER.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Kaydı Başarıyla Eklendi!","Kayıt",MessageBoxButtons.OK, MessageBoxIcon.Information);
            urunListesi();
            temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text != "")
            {
                int Urunid = int.Parse(TxtID.Text);
                var x = db.TBLURUNLER.Find(Urunid);
                db.TBLURUNLER.Remove(x);
                db.SaveChanges();

                MessageBox.Show("Ürün Başarılı Bir Şekilde Silindi","Silme",
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen Silmek İstediğiniz Kaydı Seçiniz!", "Uyarı",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            urunListesi();
            temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id=int.Parse(TxtID.Text);
            var x = db.TBLURUNLER.Find(id);
            x.UrunAd=TxtUrunAd.Text;
            x.Stok = short.Parse(TxtStok.Text);
            x.AlisFiyat = decimal.Parse(TxtAlisFiyat.Text);
            x.SatisFiyat=decimal.Parse(TxtSatisFiyat.Text);
            x.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();

            MessageBox.Show("Ürün Başarıyla Güncellendi!","Güncelleme",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            urunListesi();
            temizle();

        }
    }
}
