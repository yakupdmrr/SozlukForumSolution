using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Concrete.Sql
{
    public class SQLKullaniciDal : KullaniciDal
    {
        private static SQLKullaniciDal _sqlKullaniciDal;

        private static object _kilit = new object();

        private SQLKullaniciDal() { }

        public static SQLKullaniciDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlKullaniciDal == null)
                {
                    _sqlKullaniciDal = new SQLKullaniciDal();
                }
            }
            return _sqlKullaniciDal;
        }

        
        public override void Ekle(Kullanici veri)
        {
            string commandText =
                "insert Kullanicilar values(@Ad,@Soyad,@KullaniciAdi,@Eposta,@Parola,@Yetki)";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@Ad", veri.Ad);
            _sqlCommand.Parameters.AddWithValue("@Soyad", veri.Soyad);
            _sqlCommand.Parameters.AddWithValue("@KullaniciAdi", veri.KullaniciAdi);
            _sqlCommand.Parameters.AddWithValue("@Eposta", veri.Eposta);
            _sqlCommand.Parameters.AddWithValue("@Parola", veri.Parola);
            _sqlCommand.Parameters.AddWithValue("@Yetki", veri.Yetki.ToString());

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(Kullanici veri)
        {
            string commandText =
                "update Kullanicilar set Ad=@Ad, Soyad=@Soyad, KullaniciAdi=@KullaniciAdi, Eposta=@Eposta, Parola=@Parola, Yetki=@Yetki where KullaniciId=@KullaniciId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@Ad", veri.Ad);
            _sqlCommand.Parameters.AddWithValue("@Soyad", veri.Soyad);
            _sqlCommand.Parameters.AddWithValue("@KullaniciAdi", veri.KullaniciAdi);
            _sqlCommand.Parameters.AddWithValue("@Eposta", veri.Eposta);
            _sqlCommand.Parameters.AddWithValue("@Parola", veri.Parola);
            _sqlCommand.Parameters.AddWithValue("@Yetki", veri.Yetki.ToString());

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<Kullanici> HepsiniGetir()
        {
            string commandText = "select * from Kullanicilar";

            List<Kullanici> kullanicilar = new List<Kullanici>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                kullanicilar.Add(new Kullanici
                {
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    KullaniciAdi = reader["KullaniciAdi"].ToString(),
                    Ad = reader["Ad"].ToString(),
                    Soyad = reader["Soyad"].ToString(),
                    Yetki = Convert.ToBoolean(reader["Yetki"]),
                    Eposta = reader["Eposta"].ToString(),
                    Parola = reader["Parola"].ToString(),
                    TakipEttikleri = TakipEttikleri(Convert.ToInt32(reader["KullaniciId"])),
                    TakipEdildikleri = TakipEdildikleri(Convert.ToInt32(reader["KullaniciId"]))
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return kullanicilar;

        }

        public override Kullanici IstekGetir(int id)
        {
            string commandText = "select * from Kullanicilar where KullaniciId = @id";

            Kullanici kullanici = new Kullanici();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            _sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                kullanici.KullaniciId = Convert.ToInt32(reader["KullaniciId"]);
                kullanici.KullaniciAdi = reader["KullaniciAdi"].ToString();
                kullanici.Ad = reader["Ad"].ToString();
                kullanici.Soyad = reader["Soyad"].ToString();
                kullanici.Yetki = Convert.ToBoolean(reader["Yetki"]);
                kullanici.Eposta = reader["Eposta"].ToString();
                kullanici.Parola = reader["Parola"].ToString();
                kullanici.TakipEttikleri = TakipEttikleri(Convert.ToInt32(reader["KullaniciId"]));
                kullanici.TakipEdildikleri = TakipEdildikleri(Convert.ToInt32(reader["KullaniciId"]));
            }

            reader.Close();
            _sqlConnection.Close();

            return kullanici;
        }

        public override void Sil(Kullanici veri)
        {
            string commandText = "delete from Kullanicilar where KullaniciId = @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            _sqlCommand.Parameters.AddWithValue("@id", veri.KullaniciId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
            
        }

        public List<int> TakipEttikleri(int id)
        {
            string commandText =
                "select teb.KullaniciId from Kullanicilar k inner join TakipEdenler te on k.KullaniciId = te.KullaniciId " +
                "inner join TakipEtmeBilgileri teb on teb.TakipEtId = te.TakipEtId where te.KullaniciId = @id";

            List<int> takipEttikleri = new List<int>();

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            _sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                takipEttikleri.Add(Convert.ToInt32(reader["KullaniciId"]));
            }

            reader.Close();
            _sqlConnection.Close();

            return takipEttikleri;

        }

        public List<int> TakipEdildikleri(int id)
        {
            string commandText =
                "select teb.KullaniciId from Kullanicilar k inner join TakipEdilenler te on k.KullaniciId = te.KullaniciId " +
                "inner join TakipEdilenBilgileri teb on teb.TakipEdilenId = te.TakipEdilenId where te.KullaniciId = @id";

            List<int> takipEdildikleri = new List<int>();

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            _sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                takipEdildikleri.Add(Convert.ToInt32(reader["KullaniciId"]));
            }

            reader.Close();
            _sqlConnection.Close();

            return takipEdildikleri;
        }


        public override void TakipEt(Kullanici takipEden, int kimi)
        {
            
            string commandText = "Exec sp_TakipEt @takipEden, @kimi";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            _sqlCommand.Parameters.AddWithValue("@takipEden", takipEden.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@kimi", kimi);

            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();

           
        }

        public override void TakiptenCikar(Kullanici takiptenCikaran, int kimi)
        {
            string commandText = "Exec sp_TakiptenCikar @takiptenCikaran, @kimi";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            _sqlCommand.Parameters.AddWithValue("@takiptenCikaran", takiptenCikaran.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@kimi", kimi);

            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public override Kullanici EpostaIleGetir(string email)
        {

            string commandText = "select * from Kullanicilar where Eposta = @email";

            Kullanici kullanici = new Kullanici();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            _sqlCommand.Parameters.AddWithValue("@email", email);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                kullanici.KullaniciId = Convert.ToInt32(reader["KullaniciId"]);
                kullanici.KullaniciAdi = reader["KullaniciAdi"].ToString();
                kullanici.Ad = reader["Ad"].ToString();
                kullanici.Soyad = reader["Soyad"].ToString();
                kullanici.Yetki = Convert.ToBoolean(reader["Yetki"]);
                kullanici.Eposta = reader["Eposta"].ToString();
                kullanici.Parola = reader["Parola"].ToString();
                kullanici.TakipEttikleri = TakipEttikleri(Convert.ToInt32(reader["KullaniciId"]));
                kullanici.TakipEdildikleri = TakipEdildikleri(Convert.ToInt32(reader["KullaniciId"]));
            }

            reader.Close();
            _sqlConnection.Close();

            return kullanici;
        }

        public override Kullanici IstekGetir(string KullaniciAdi)
        {
            string commandText = "select * from Kullanicilar where KullaniciAdi = @KullaniciAdi";

            Kullanici kullanici = new Kullanici();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);



            _sqlCommand.Parameters.AddWithValue("@KullaniciAdi", KullaniciAdi);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                kullanici.KullaniciId = Convert.ToInt32(reader["KullaniciId"]);
                kullanici.KullaniciAdi = reader["KullaniciAdi"].ToString();
                kullanici.Ad = reader["Ad"].ToString();
                kullanici.Soyad = reader["Soyad"].ToString();
                kullanici.Yetki = Convert.ToBoolean(reader["Yetki"]);
                kullanici.Eposta = reader["Eposta"].ToString();
                kullanici.Parola = reader["Parola"].ToString();
                kullanici.TakipEttikleri = TakipEttikleri(Convert.ToInt32(reader["KullaniciId"]));
                kullanici.TakipEdildikleri = TakipEdildikleri(Convert.ToInt32(reader["KullaniciId"]));
            }

            reader.Close();
            _sqlConnection.Close();

            return kullanici;
        }
    }
}
