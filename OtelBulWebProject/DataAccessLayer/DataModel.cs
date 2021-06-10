using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con;
        SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionString.ConStr);
            cmd = con.CreateCommand();
        }

        public List<OtelModel> OtelListele()
        {
            List<OtelModel> Oteller = new List<OtelModel>();
            try
            {
                cmd.CommandText = "Select O.ID, O.OtelAdi, O.Aciklama, O.Adres, O.YildizSayisi, O.KullaniciPuani, S.Sehir, I.Ilce, O.OnayDurumu, O.Ozet " +
                    "From Oteller as O Join Sehirler as S On O.SehirID = S.ID Join Ilceler as I On O.IlceID = I.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OtelModel o = new OtelModel();
                    o.ID = reader.GetInt32(0);
                    o.OtelAdi = reader.GetString(1);
                    o.Aciklama = reader.GetString(2);
                    o.Adres = reader.GetString(3);
                    o.YildizSayisi = reader.GetInt32(4);
                    o.KullaniciPuani = reader.GetDouble(5);
                    o.Sehir = reader.GetString(6);
                    o.ilce = reader.GetString(7);
                    o.OnayDurumu = reader.GetBoolean(8);
                    o.Ozet = reader.GetString(9);
                    Oteller.Add(o);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            try
            {
                foreach (OtelModel item in Oteller)
                {
                    cmd.CommandText = "Select FotografUzanti From OtelFotograflari Where OtelID=@otelID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@otelID", item.ID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        item.FotografUzati = reader.GetString(0);
                    }
                    if (string.IsNullOrEmpty(item.FotografUzati))
                    {
                        item.FotografUzati = "no-camera.png";
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return Oteller;
        }
        public List<OtelModel> OtelListele(string sorgu)
        {
            List<OtelModel> Oteller = new List<OtelModel>();
            int sorguCount = sorgu.Length;
            sorgu = sorgu.Remove(sorguCount - 4, 4);
            try
            {
                cmd.CommandText = "Select O.ID, O.OtelAdi, O.Aciklama, O.Adres, O.YildizSayisi, O.KullaniciPuani, S.Sehir, I.Ilce, O.OnayDurumu, O.Ozet " +
                    "From Oteller as O Join Sehirler as S On O.SehirID = S.ID Join Ilceler as I On O.IlceID = I.ID Where " + sorgu;
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OtelModel o = new OtelModel();
                    o.ID = reader.GetInt32(0);
                    o.OtelAdi = reader.GetString(1);
                    o.Aciklama = reader.GetString(2);
                    o.Adres = reader.GetString(3);
                    o.YildizSayisi = reader.GetInt32(4);
                    o.KullaniciPuani = reader.GetDouble(5);
                    o.Sehir = reader.GetString(6);
                    o.ilce = reader.GetString(7);
                    o.OnayDurumu = reader.GetBoolean(8);
                    o.Ozet = reader.GetString(9);
                    Oteller.Add(o);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            try
            {
                foreach (OtelModel item in Oteller)
                {
                    cmd.CommandText = "Select FotografUzanti From OtelFotograflari Where OtelID=@otelID";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@otelID", item.ID);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        item.FotografUzati = reader.GetString(0);
                    }
                    if (string.IsNullOrEmpty(item.FotografUzati))
                    {
                        item.FotografUzati = "no-camera.png";
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return Oteller;
        }
        public OtelModel OtelGetir(int id)
        {
            OtelModel o = new OtelModel();
            try
            {
                cmd.CommandText = "Select O.ID, O.OtelAdi, O.Aciklama, O.Adres, O.YildizSayisi, O.KullaniciPuani, S.Sehir, I.Ilce, O.OnayDurumu, O.Ozet, S.ID, I.ID " +
                    "From Oteller as O Join Sehirler as S On O.SehirID = S.ID Join Ilceler as I On O.IlceID = I.ID Where O.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    o.ID = reader.GetInt32(0);
                    o.OtelAdi = reader.GetString(1);
                    o.Aciklama = reader.GetString(2);
                    o.Adres = reader.GetString(3);
                    o.YildizSayisi = reader.GetInt32(4);
                    o.KullaniciPuani = reader.GetDouble(5);
                    o.Sehir = reader.GetString(6);
                    o.ilce = reader.GetString(7);
                    o.OnayDurumu = reader.GetBoolean(8);
                    o.Ozet = reader.GetString(9);
                    o.SehirID = reader.GetInt32(10);
                    o.ilceID = reader.GetInt32(11);
                }
                return o;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<OtelHizmetleri> OtelHizmetleriListele(int otelID)
        {
            try
            {
                List<OtelHizmetleri> hizmetler = new List<OtelHizmetleri>();
                cmd.CommandText = " Select oh.ID, oh.OtelID, h.Hizmet From OtelHizmetleri as oh  Join Hizmetler as h On h.ID = oh.HizmetID  " +
                    "Where OtelID = @otelId and HizmetDurumu = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@otelId", otelID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OtelHizmetleri oh = new OtelHizmetleri();
                    oh.ID = reader.GetInt32(0);
                    oh.OtelID = reader.GetInt32(1);
                    oh.HizmetAdi = reader.GetString(2);
                    hizmetler.Add(oh);
                }
                return hizmetler;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<OtelKategorileri> OtelKategorileriListele(int otelID)
        {
            try
            {
                List<OtelKategorileri> kategoriler = new List<OtelKategorileri>();
                cmd.CommandText = "Select ok.ID, ok.OtelID, ok.OtelKategoriID, k.Kategori  From OtelKategorileri as ok Join Kategoriler as k On k.ID = ok.OtelKategoriID " +
                    "Where ok.OtelID = @otelID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@otelID", otelID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OtelKategorileri ok = new OtelKategorileri();
                    ok.ID = reader.GetInt32(0);
                    ok.OtelID = reader.GetInt32(1);
                    ok.KategoriID = reader.GetInt32(2);
                    ok.Kategori = reader.GetString(3);
                    kategoriler.Add(ok);
                }
                return kategoriler;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public OtelFotograflari FotografGetir(int otelID)
        {
            try
            {
                OtelFotograflari f = new OtelFotograflari();
                cmd.CommandText = "Select OtelID, FotografUzanti From OtelFotograflari Where OtelID=@otelID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@otelID", otelID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    f.OtelID = reader.GetInt32(0);
                    f.FotografUzati = reader.GetString(1);
                }
                return f;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public int OtelEkle(OtelModel otel)
        {
            try
            {
                cmd.CommandText = "Insert Into Oteller(OtelAdi, Aciklama, Ozet, Adres, SehirID, IlceID, YildizSayisi, KullaniciPuani, OnayDurumu) " +
                    "VALUES(@otelAdi, @aciklama, @ozet, @adres, @sehirID, @ilceID, @yildizSayi, @kullaniciPuani, @onayDurumu); SET @prmYeniId = SCOPE_IDENTITY()";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@otelAdi", otel.OtelAdi);
                cmd.Parameters.AddWithValue("@aciklama", otel.Aciklama);
                cmd.Parameters.AddWithValue("@ozet", otel.Ozet);
                cmd.Parameters.AddWithValue("@adres", otel.Adres);
                cmd.Parameters.AddWithValue("@sehirID", otel.SehirID);
                cmd.Parameters.AddWithValue("@ilceID", otel.ilceID);
                cmd.Parameters.AddWithValue("@yildizSayi", otel.YildizSayisi);
                cmd.Parameters.AddWithValue("@kullaniciPuani", otel.KullaniciPuani);
                cmd.Parameters.AddWithValue("@onayDurumu", otel.OnayDurumu);
                cmd.Parameters.Add("@prmYeniId", SqlDbType.Int).Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteScalar();
                int ID = (int)cmd.Parameters["@prmYeniId"].Value;
                return ID;
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                con.Close();
            }

        }
        public bool OtelFotografEkle(OtelFotograflari foto)
        {
            try
            {
                cmd.CommandText = "Insert Into OtelFotograflari(FotografUzanti, OtelID) VALUES(@uzanti, @otelID)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uzanti", foto.FotografUzati);
                cmd.Parameters.AddWithValue("@otelID", foto.OtelID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool OtelHizmetiEkle(List<OtelHizmetleri> hizmetler)
        {
            try
            {
                foreach (OtelHizmetleri hizmet in hizmetler)
                {
                    cmd.CommandText = "Insert Into OtelHizmetleri(HizmetDurumu, OtelID, HizmetID) VALUES(@hizmetDrm, @oteiId, @HizmetId)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@hizmetDrm", hizmet.HizmetDurumu);
                    cmd.Parameters.AddWithValue("@oteiId", hizmet.OtelID);
                    cmd.Parameters.AddWithValue("@HizmetId", hizmet.HizmetID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool OtelKategorisiEkle(List<OtelKategorileri> kategoriler)
        {
            try
            {
                foreach (OtelKategorileri item in kategoriler)
                {
                    cmd.CommandText = "Insert Into OtelKategorileri(OtelID, OtelKategoriID) VALUES(@otelId, @KategoriId)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@otelId", item.OtelID);
                    cmd.Parameters.AddWithValue("@KategoriId", item.KategoriID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #region ListBox Verileri (Kategoriler ve Hizmetler)
        public List<OtelHizmetleri> HizmetListele()
        {
            try
            {
                List<OtelHizmetleri> hizmetler = new List<OtelHizmetleri>();
                cmd.CommandText = "Select ID, Hizmet From Hizmetler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OtelHizmetleri oh = new OtelHizmetleri();
                    oh.HizmetID = reader.GetInt32(0);
                    oh.HizmetAdi = reader.GetString(1);
                    hizmetler.Add(oh);
                }
                return hizmetler;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<OtelKategorileri> KategoriListele()
        {
            try
            {
                List<OtelKategorileri> kategoriler = new List<OtelKategorileri>();
                cmd.CommandText = "Select ID, Kategori From Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    OtelKategorileri k = new OtelKategorileri();
                    k.KategoriID = reader.GetInt32(0);
                    k.Kategori = reader.GetString(1);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region DropDown Liste Verileri
        public List<Sehirler> SehirListele()
        {
            List<Sehirler> sehirler = new List<Sehirler>();
            try
            {
                cmd.CommandText = "SELECT ID,Sehir FROM Sehirler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sehirler s = new Sehirler();
                    s.SehirID = reader.GetInt32(0);
                    s.Sehir = reader.GetString(1);
                    sehirler.Add(s);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return sehirler;
        }
        public List<Ilceler> IlceListele()
        {
            List<Ilceler> ilceler = new List<Ilceler>();
            try
            {
                cmd.CommandText = "SELECT ID, Ilce, SehirID FROM Ilceler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ilceler i = new Ilceler();
                    i.IlceID = reader.GetInt32(0);
                    i.Ilce = reader.GetString(1);
                    i.SehirID = reader.GetInt32(2);
                    ilceler.Add(i);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return ilceler;
        }
        public List<Ilceler> IlceListele(int SehirID)
        {
            List<Ilceler> ilceler = new List<Ilceler>();
            try
            {
                cmd.CommandText = "SELECT ID, Ilce, SehirID FROM Ilceler Where SehirID=@sehirid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@sehirid", SehirID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Ilceler i = new Ilceler();
                    i.IlceID = reader.GetInt32(0);
                    i.Ilce = reader.GetString(1);
                    i.SehirID = reader.GetInt32(2);
                    ilceler.Add(i);
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            return ilceler;
        }
        #endregion

        #region Üye İşlemleri
        public bool UyeKayit(Kullanicilar kullanici)
        {
            try
            {
                cmd.CommandText = "Insert into Kullanicilar(KullaniciAdi, Sifre, AdSoyad, Adres, Telefon, Email, YetkiID) " +
                                                 "VALUES(@kullaniciAdi, @sifre, @adsoyad, @adres, @telefon, @email, @yetkiId)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kullaniciAdi", kullanici.KullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", kullanici.Sifre);
                cmd.Parameters.AddWithValue("@adsoyad", kullanici.AdSoyad);
                cmd.Parameters.AddWithValue("@adres", kullanici.Adres);
                cmd.Parameters.AddWithValue("@telefon", kullanici.Telefon);
                cmd.Parameters.AddWithValue("@email", kullanici.Email);
                cmd.Parameters.AddWithValue("@yetkiId", kullanici.YetkiID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                con.Close();
            }
        }
        public Kullanicilar UyeGiris(string m, string s)
        {
            try
            {
                Kullanicilar k = new Kullanicilar();
                cmd.CommandText = "Select Count(*) From Kullanicilar Where (Email=@mail Or KullaniciAdi=@kullaniciAdi) And Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", m);
                cmd.Parameters.AddWithValue("@kullaniciAdi", m);
                cmd.Parameters.AddWithValue("@sifre", s);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi == 1)
                {
                    cmd.CommandText = "Select ID, KullaniciAdi, Sifre, AdSoyad, Email, YetkiID, OtelID From Kullanicilar Where (Email=@mail Or KullaniciAdi=@kullaniciAdi) And Sifre=@sifre";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", m);
                    cmd.Parameters.AddWithValue("@kullaniciAdi", m);
                    cmd.Parameters.AddWithValue("@sifre", s);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        k.KullaniciID = reader.GetInt32(0);
                        k.KullaniciAdi = reader.GetString(1);
                        k.Sifre = reader.GetString(2);
                        k.AdSoyad = reader.GetString(3);
                        k.Email = reader.GetString(4);
                        k.YetkiID = reader.GetInt32(5);
                        k.OtelID = reader["OtelID"] != DBNull.Value ? reader.GetInt32(6) : 0;
                    }
                }
                return k;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region Güncelleme
        public bool OtelGuncelle(OtelModel otel)
        {
            try
            {
                cmd.CommandText = "Update Oteller Set OtelAdi=@otelAdi, YildizSayisi=@yildiz, Adres=@adres, Aciklama=@aciklama, SehirID=@sehir, IlceID=@ilce, " +
                    "Ozet=@ozet Where ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@otelAdi", otel.OtelAdi);
                cmd.Parameters.AddWithValue("@yildiz", otel.YildizSayisi);
                cmd.Parameters.AddWithValue("@adres", otel.Adres);
                cmd.Parameters.AddWithValue("@aciklama", otel.Aciklama);
                cmd.Parameters.AddWithValue("@sehir", otel.SehirID);
                cmd.Parameters.AddWithValue("@ilce", otel.ilceID);
                cmd.Parameters.AddWithValue("@ozet", otel.Ozet);
                cmd.Parameters.AddWithValue("@id", otel.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool OtelFotograflariGuncelle(OtelFotograflari foto)
        {
            try
            {
                cmd.CommandText = "Select Count(ID) From OtelFotograflari Where OtelID=@otelId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@otelId", foto.OtelID);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                if (sayi > 0)
                {
                    cmd.CommandText = "Update OtelFotograflari Set FotografUzanti=@uzanti Where OtelID=@otelId";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@uzanti", foto.FotografUzati);
                    cmd.Parameters.AddWithValue("@otelId", foto.OtelID);
                    con.Open();
                }
                else
                {
                    cmd.CommandText = "Insert Into OtelFotograflari(FotografUzanti, OtelID) VALUES(@uzanti, @otelID)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@uzanti", foto.FotografUzati);
                    cmd.Parameters.AddWithValue("@otelID", foto.OtelID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool OtelHizmetlerGuncelle(List<OtelHizmetleri> hizmetler)
        {
            try
            {
                cmd.CommandText = "Delete From OtelHizmetleri  Where OtelID = @otelId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@otelId", hizmetler[0].OtelID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                foreach (OtelHizmetleri hizmet in hizmetler)
                {
                    cmd.CommandText = "Insert Into OtelHizmetleri(HizmetDurumu, OtelID, HizmetID) VALUES(@hizmetDrm, @oteiId, @HizmetId)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@hizmetDrm", hizmet.HizmetDurumu);
                    cmd.Parameters.AddWithValue("@oteiId", hizmet.OtelID);
                    cmd.Parameters.AddWithValue("@HizmetId", hizmet.HizmetID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool OtelKategorileriGuncelle(List<OtelKategorileri> kategoriler)
        {
            try
            {
                cmd.CommandText = "Delete From OtelKategorileri  Where OtelID = @otelId";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@otelId", kategoriler[0].OtelID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                foreach (OtelKategorileri item in kategoriler)
                {
                    cmd.CommandText = "Insert Into OtelKategorileri(OtelKategoriID, OtelID) VALUES(@kategoriId, @otelId)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@kategoriId", item.KategoriID);
                    cmd.Parameters.AddWithValue("@otelId", item.OtelID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        public bool YorumEkle(Yorumlar yorum)
        {
            try
            {
                cmd.CommandText = "Insert Into Yorumlar(Baslik, Yorum, YorumTarihi, OtelID, KullaniciID) VALUES(@baslik, @yorum, @tarih, @otelId, @kullanici)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@baslik", yorum.Baslik);
                cmd.Parameters.AddWithValue("@yorum", yorum.Yorum);
                cmd.Parameters.AddWithValue("@tarih", yorum.YorumTarihi);
                cmd.Parameters.AddWithValue("@otelId", yorum.OtelID);
                cmd.Parameters.AddWithValue("@kullanici", yorum.KullaniciID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorumlar> YorumListele(int OtelID)
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "Select y.Baslik, y.Yorum, y.YorumTarihi, y.OtelID, k.KullaniciAdi From Yorumlar as y Join Kullanicilar as k On k.ID=y.KullaniciID " +
                    "Where y.OtelID=@otelID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@otelID", OtelID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar y = new Yorumlar();
                    y.Baslik = reader.GetString(0);
                    y.Yorum = reader.GetString(1);
                    y.YorumTarihi = reader.GetDateTime(2);
                    y.OtelID = reader.GetInt32(3);
                    y.KullaniciAdi = reader.GetString(4);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

    }
}
