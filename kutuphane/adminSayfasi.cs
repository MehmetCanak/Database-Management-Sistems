﻿using System;
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
    public partial class adminSayfasi : Form
    {
        string ad1;
        string soyad1;
        string sifre1;
        int tc1;
        string email1;
        int id1;
        string tel1;
       private int yonetici;
       private string ysifre;
        public int yntc { get { return yonetici; }
                        set
                        {
                yonetici = value;
                         } }
        public string sfr
        { get { return ysifre; } set { ysifre = value; }
        }

        int oduncUye;
        string oduncKitap;
        public adminSayfasi()
        {
            InitializeComponent();
        }

        private void ekleKullanici_Click(object sender, EventArgs e)
        {
            ad1 = textBox1.Text;
            soyad1 = textBox2.Text;
            tc1 = int.Parse(textBox3.Text);
            email1 = textBox4.Text;
            Random rm = new Random();
            sifre1 = (rm.Next(123456, 989789).ToString());
            tel1 = rm.Next(1111111, 9999999).ToString();
            //DateTime time = DateTime.Now;
            using (DataClasses1DataContext dcdc=new DataClasses1DataContext())
            {
                var idbul = dcdc.uye.Max(k=>k.id);
                var ybul = (from i in dcdc.admin
                            join j in dcdc.kutuphane on i.kutuphaneID equals j.id
                            where i.kutuphaneID==j.id && i.id == yonetici && i.sifre == ysifre
                            select j.id).FirstOrDefault();
                id1 = idbul;
                id1 = id1 + 1;
                uye uyeSinifi = new uye()
                {
                    id = id1,
                    ad = ad1,
                    soyad = soyad1,
                    tc = tc1,
                    email = email1,
                    sifre = sifre1,
                    tel = tel1,
                    
    
                };
                kayıt kyt = new kayıt()
                {
                    //kayit_tarihi = time.Date,
                    kutuphaneID = 1,
                    uyeID = id1,
                    

                };


                dcdc.uye.InsertOnSubmit(uyeSinifi);
                dcdc.kayıt.InsertOnSubmit(kyt);
                dcdc.SubmitChanges();
               
            }
            textBox1.Text = "";textBox2.Text = "";textBox3.Text="";
            textBox4.Text = "";
            
        }

        private void listeleKullanici_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataClasses1DataContext dkct=new DataClasses1DataContext())
                {
                    var uyeyazdir = dkct.uye.Select(s => s);
                    dataGridView1.DataSource = uyeyazdir;
                }
            }
            catch (Exception hata)
            {
                label12.Text = hata.ToString();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void kullaniciSil_Click(object sender, EventArgs e)
        {
            int sil;
            sil = int.Parse(textBox3.Text);
            
            try
            {
                using(var dkkls=new DataClasses1DataContext())
                {

                    var sill = (from i in dkkls.uye
                                where i.tc == sil
                                select i).FirstOrDefault();
                   
                    if (sill != null)
                    {
                        dkkls.uye.DeleteOnSubmit(sill);
                    };
                    dkkls.SubmitChanges();
                    
                }
            }
            catch
            {

            }
            textBox3.Text = "";
        }

        private void oduncVer_Click(object sender, EventArgs e)
        {
            oduncKitap = textBox5.Text;
            if(textBox6.Text.Length==9)
            {
                oduncUye = int.Parse(textBox6.Text);
            }
            else
            {
                MessageBox.Show("lütfen tekrar tc numaranızı girin : ");
            }
            using(DataClasses1DataContext dc=new DataClasses1DataContext())
            {
                var varmi = dc.uye.Where(s => s.tc == oduncUye).Select(s => s.ad).Any();
                var varmiKitap = dc.kitap.Where(s => s.isbn == oduncKitap).Select(s => s.ad).Any();
                if (varmi == true || varmiKitap==true)
                {

                    //var uyeBul = (from od in dc.odunc
                    //          join k in dc.kutuphane on od.kutuphaneID equals k.id
                    //          join i in dc.uye on od.uyeID equals i.id
                    //          join ktp in dc.kitap on od.kitapID equals ktp.id
                    //          where  i.tc==oduncUye && ktp.isbn==oduncKitap
                    //          select new {
                    //                      k.});
                    //var uyeId = (from i in dc.uye
                    //             where i.tc==oduncUye
                    //             select i.id
                    //             );
                    //var kitapId = (from k in dc.kitap
                    //               where k.isbn==oduncKitap
                    //               select k.id);

                    //odunc odc = new odunc()
                    //{
                    //    kutuphaneID = 1,
                    //    uyeID = uyeId.FirstOrDefault(),
                    //    kitapID = kitapId.FirstOrDefault(),
                    //    //odunc_alma_tarihi=DateTime.Now

                    //};

                    //dc.odunc.InsertOnSubmit(odc);
                    //dc.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("böyle bir uye yoktur ");
                }
            }
            
            
        }
    }
}
