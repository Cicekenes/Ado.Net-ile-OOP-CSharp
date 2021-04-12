using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OOP_İle_CRUD_işlemleri
{
    public class Sqlbaglantisi
    {
        
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-VBLQGME\SQLEXPRESS;Initial Catalog=OOPDB;Integrated Security=True");
            
            
        

        public List<Eleman> Listele()
        {
            List<Eleman> eleman = new List<Eleman>();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From T_ELEMAN",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Eleman e = new Eleman();
                e.ID = short.Parse(dr[0].ToString());
                e.AD = dr[1].ToString();
                e.SOYAD = dr[2].ToString();
                e.MESLEK = dr[3].ToString();
                e.MAAS = short.Parse(dr[4].ToString());
                e.SEHIR = dr[5].ToString();
                e.UNIVERSITE = dr[6].ToString();

                eleman.Add(e);
            }
            baglanti.Close();
            return eleman;
            
        }

        public void KitapEkle(Eleman el)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into T_ELEMAN (AD,SOYAD,MESLEK,MAAS,SEHIR,UNIVERSITE) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1",el.AD);
            komut.Parameters.AddWithValue("@p2",el.SOYAD);
            komut.Parameters.AddWithValue("@p3",el.MESLEK);
            komut.Parameters.AddWithValue("@p4",short.Parse(el.MAAS.ToString()));
            komut.Parameters.AddWithValue("@p5",el.SEHIR);
            komut.Parameters.AddWithValue("@p6",el.UNIVERSITE);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();

        }

        public void KitapSil(Eleman el2)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("delete from T_ELEMAN where ID=@p1",baglanti);
            komutSil.Parameters.AddWithValue("@p1",short.Parse(el2.ID.ToString()));
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            Listele();
        }

        public void KitapGuncelle(Eleman el3)
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("update T_ELEMAN set AD=@p1,SOYAD=@p2,MESLEK=@p3,MAAS=@p4,SEHIR=@p5,UNIVERSITE=@p6 where ID=@p7",baglanti);
            komutGuncelle.Parameters.AddWithValue("@p1",el3.AD);
            komutGuncelle.Parameters.AddWithValue("@p2",el3.SOYAD);
            komutGuncelle.Parameters.AddWithValue("@p3",el3.MESLEK);
            komutGuncelle.Parameters.AddWithValue("@p4",short.Parse(el3.MAAS.ToString()));
            komutGuncelle.Parameters.AddWithValue("@p5",el3.SEHIR);
            komutGuncelle.Parameters.AddWithValue("@p6",el3.UNIVERSITE);
            komutGuncelle.Parameters.AddWithValue("@p7",short.Parse(el3.ID.ToString()));
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
