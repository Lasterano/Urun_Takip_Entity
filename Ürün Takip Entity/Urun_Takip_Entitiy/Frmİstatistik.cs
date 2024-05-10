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
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        DbUrunEntities db = new DbUrunEntities();

        private void Frmİstatistik_Load(object sender, EventArgs e)
        {
            DateTime bugun=DateTime.Today;
            LblMusteriSayisi.Text= db.TBLMUSTERI.Count().ToString();
            LblKategoriSayisi.Text=db.TBLKATEGORI.Count().ToString();
            LblUrunSayisi.Text=db.TBLURUNLER.Count().ToString();
            LblBeyazEsya.Text = db.TBLURUNLER.Count(x=>x.Kategori==1).ToString();
            LblToplamStok.Text= db.TBLURUNLER.Sum(x=>x.Stok).ToString();
            LblBugunSatisAdedi.Text=db.TBLSATISLAR.Count(x=>x.Tarih==bugun).ToString();
            LblToplamKasa.Text= db.TBLSATISLAR.Sum(x => x.Toplam).ToString()+" ₺";
            LblBugunkuKasa.Text = db.TBLSATISLAR.Where(x=>x.Tarih==bugun).Sum(x=>x.Toplam).ToString()+" ₺";
            LblenYuksekFiyatliUrun.Text=(from x in db.TBLURUNLER orderby x.SatisFiyat descending 
                                         select x.UrunAd).FirstOrDefault();
            LblEnDusukFiyatliUrun.Text=(from x in db.TBLURUNLER orderby x.SatisFiyat ascending
                                        select x.UrunAd).FirstOrDefault();
            LblEnFazlaStok.Text = (from x in db.TBLURUNLER
                                   orderby x.Stok descending
                                   select x.UrunAd).FirstOrDefault();
            LblEnAzStok.Text=(from x in db.TBLURUNLER orderby x.Stok ascending
                              select x.UrunAd).FirstOrDefault();
        }
    }
}
