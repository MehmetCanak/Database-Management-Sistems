using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane
{
    public partial class AramaYapmaSinifi : Form
    {
        public string kutup;
        public string aranan;
        public string kategori;
        public AramaYapmaSinifi()
        {
            InitializeComponent();
        }

        private void AramaYapmaSinifi_Load(object sender, EventArgs e)
        {
            
            using(DataClasses1DataContext dt=new DataClasses1DataContext())
            {
                if (kutup == "Tümü")
                {
                    if (kategori == "Eser Adı")
                    {
                        //var ara = dt.kitap.Where(s => s.ad.Contains(aranan)
                        //                         ).Select(s => new { s.ad, s.isbn, s.yazarAdi, s.yayinevi });
                        var eserAra = (from i in dt.kitap
                                    join j in dt.yazar on i.yazarAdi equals j.ad

                                    join k in dt.yayinevi on i.yayıneviID equals k.id
                                    join l in dt.kategori on i.kategoriID equals l.id
                                    join yb in dt.yerbilgisi on i.id equals yb.kitapID
                                    //join oduncc in dt.odunc on i.id equals oduncc.kitapID
                                    where i.ad.Contains(aranan) 
                                    select new { isim=i.ad,yazar_adi=i.yazarAdi,i.isbn, yer_bilgisi = yb.yerNo,
                                                kitap_durumu =yb.durum,//kitap_teslim_tarihi=oduncc.son_teslim_tarihi,
                                                   yayinevi_adı =k.ad,kategori_adı=l.ad});
                                    dataGridView1.DataSource = eserAra;
                       
                    }
                    if (kategori == "Yazar Adı")
                    {
                        var yazarAra = (from i in dt.yazar
                                        join j in dt.kitap on i.ad equals j.yazarAdi
                                        join y in dt.yayinevi on j.yayıneviID equals y.id
                                        join yb in dt.yerbilgisi on j.id equals yb.kitapID
                                        join ktg in dt.kategori on j.kategoriID equals ktg.id
                                        where j.yazarAdi.Contains(aranan)
                                        select new
                                        {
                                            isim = j.ad,
                                            yazar_adi = j.yazarAdi,
                                            j.isbn,
                                            yer_bilgisi = yb.yerNo,
                                            kitap_durumu = yb.durum,
                                            yayinevi_adı = y.ad,
                                            kategori_adı = ktg.ad
                                        });
                                    dataGridView1.DataSource = yazarAra;


                    }
                    if (kategori== "Yayınlayan")
                    {
                        var yayinEviAra= (from i in dt.yazar
                                        join j in dt.kitap on i.ad equals j.yazarAdi
                                        join y in dt.yayinevi on j.yayıneviID equals y.id
                                        join yb in dt.yerbilgisi on j.id equals yb.kitapID
                                        join ktg in dt.kategori on j.kategoriID equals ktg.id
                                        where y.ad.Contains(aranan)
                                        select new
                                        {
                                            isim = j.ad,
                                            yazar_adi = j.yazarAdi,
                                            j.isbn,
                                            yer_bilgisi = yb.yerNo,
                                            kitap_durumu = yb.durum,
                                            yayinevi_adı = y.ad,
                                            kategori_adı = ktg.ad
                                        });
                        dataGridView1.DataSource = yayinEviAra;
                    }
                    if (kategori == "Isbn")
                    {
                        var isbnAra = (from i in dt.yazar
                                           join j in dt.kitap on i.ad equals j.yazarAdi
                                           join y in dt.yayinevi on j.yayıneviID equals y.id
                                           join yb in dt.yerbilgisi on j.id equals yb.kitapID
                                           join ktg in dt.kategori on j.kategoriID equals ktg.id
                                           where j.isbn.Contains(aranan)
                                           select new
                                           {
                                               isim = j.ad,
                                               yazar_adi = j.yazarAdi,
                                               j.isbn,
                                               yer_bilgisi = yb.yerNo,
                                               kitap_durumu = yb.durum,
                                               yayinevi_adı = y.ad,
                                               kategori_adı = ktg.ad
                                           });
                        dataGridView1.DataSource = isbnAra;
                    }



                }

            }



        }

    }

}

