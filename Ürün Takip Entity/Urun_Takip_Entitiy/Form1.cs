using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Entitiy
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }
        DbUrunEntities db = new DbUrunEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.TBLMUSTERI.ToList();
            var degerler = from x in db.TBLMUSTERI
                           select new
                           {
                               x.MusteriID, x.Ad,x.Soyad,x.Sehir,x.Bakiye
                           };
          dataGridView1.DataSource=degerler.ToList();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TBLMUSTERI t = new TBLMUSTERI();
            t.Ad=TxtAd.Text;
            t.Bakiye=decimal.Parse(TxtBakiye.Text);
            t.Sehir=TxtSehir.Text;
            t.Soyad=TxtSoyad.Text;
            db.TBLMUSTERI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Müşteri Kaydı Yapıldı!","Kayıt",MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id=int.Parse(TxtID.Text);
            var x=db.TBLMUSTERI.Find(id);
            db.TBLMUSTERI.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Müşteri Sistemden Silindi!","Silme",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtBakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtSehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id= int.Parse(TxtID.Text);
            var x = db.TBLMUSTERI.Find(id);
            x.Ad=TxtAd.Text;
            x.Soyad=TxtSoyad.Text;
            x.Sehir=TxtSehir.Text;
            x.Bakiye = decimal.Parse(TxtBakiye.Text);
            db.SaveChanges();
            MessageBox.Show("Müşteri Bilgisi Güncellendi!","Güncelleme",MessageBoxButtons.OK,MessageBoxIcon.Information );
        }

       
    }
}
