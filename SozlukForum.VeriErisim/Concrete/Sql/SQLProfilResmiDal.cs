using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Concrete.Sql
{
    public class SQLProfilResmiDal : ProfilResmiDal
    {
        private static SQLProfilResmiDal _profilResmiDal;

        private static object _kilit = new object();

        private SQLProfilResmiDal() { }

        public static SQLProfilResmiDal NesneUret()
        {
            lock (_kilit)
            {
                if (_profilResmiDal == null)
                {
                    _profilResmiDal = new SQLProfilResmiDal();
                }
            }
            return _profilResmiDal;
        }
        public override void Ekle(ProfilResmi veri)
        {
            string commandText =
                "exec sp_ProfilResmiEkle @ResimAdi, @ResimYolu, @KullaniciId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
          


            _sqlCommand.Parameters.AddWithValue("@ResimAdi", veri.ResimAdi);
            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.ResimYolu);
            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);

            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public override void Guncelle(ProfilResmi veri)
        {
            string commandText =
                "exec sp_ProfilResmiGuncelle @ResimId, @ResimYolu";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           

            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.ResimYolu);
            _sqlCommand.Parameters.AddWithValue("@ResimId", veri.ResimId);
            

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
        
        public override ProfilResmi IstekGetir(int kullaniciId)
        {
            string commandText = "sp_ProfilResmiIstekGetir @id";

            ProfilResmi profilResmi = new ProfilResmi();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@id", kullaniciId);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                profilResmi.ResimAdi = reader["ResimAdi"].ToString();
                profilResmi.KullaniciId = Convert.ToInt32(reader["KullaniciId"]);
                profilResmi.ResimId = Convert.ToInt32(reader["ResimId"]);
                profilResmi.ResimYolu = reader["ResimYolu"].ToString();

            }

            reader.Close();
            _sqlConnection.Close();

            return profilResmi;
        }

        public override void Sil(ProfilResmi veri)
        {
            string commandText =
                "exec sp_ProfilResmiSil @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@id", veri.ResimId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
    }
}
