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
    public class SQLPaylasimResmiDal : PaylasimResmiDal
    {
        private static SQLPaylasimResmiDal _sqlPaylasimResmiDal;

        private static object _kilit = new object();

        private SQLPaylasimResmiDal() { }

        public static SQLPaylasimResmiDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlPaylasimResmiDal == null)
                {
                    _sqlPaylasimResmiDal = new SQLPaylasimResmiDal();
                }
            }
            return _sqlPaylasimResmiDal;
        }

        

        public override void Ekle(PaylasimResmi veri)
        {
            string commandText =
                "Exec sp_PaylasimResmiEkle @ResimAdi, @ResimYolu, @PaylasimId,@KategoriId,@KullaniciId,@GirilmeZamani";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@ResimAdi", veri.Resim.ResimAdi);
            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.Resim.ResimYolu);
            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);
            _sqlCommand.Parameters.AddWithValue("@KategoriId", veri.KategoriId);
            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@GirilmeZamani", veri.GirilmeZamani);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(PaylasimResmi veri)
        {
            string commandText =
                "exec sp_PaylasimResmiGuncelle @ResimId, @ResimYolu";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            

            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.Resim.ResimYolu);
            _sqlCommand.Parameters.AddWithValue("@ResimId", veri.Resim.ResimId);
            

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<PaylasimResmi> HepsiniGetir()
        {
            string commandText = "exec sp_PaylasimResmiHepsiniGetir";

            List<PaylasimResmi> entryResimleri = new List<PaylasimResmi>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
          


            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                entryResimleri.Add(new PaylasimResmi
                {
                    PaylasimId = reader["PaylasimId"].ToString(),
                    Resim = ResimGetir(Convert.ToInt32(reader["ResimId"])),
                    KategoriId = Convert.ToInt32(reader["KategoriId"]),
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    GirilmeZamani = reader["GirilmeZamani"].ToString()
                    
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return entryResimleri;
        }

        public override List<PaylasimResmi> IstekGetir(string PaylasimId)
        {
            string commandText = "exec sp_PaylasimResmiIstekGetir @id";

            List<PaylasimResmi> entryResimleri = new List<PaylasimResmi>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
          


            _sqlCommand.Parameters.AddWithValue("@id", PaylasimId);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                entryResimleri.Add(new PaylasimResmi
                {
                    PaylasimId = reader["PaylasimId"].ToString(),
                    Resim = ResimGetir(Convert.ToInt32(reader["ResimId"])),
                    KategoriId = Convert.ToInt32(reader["KategoriId"]),
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    GirilmeZamani = reader["GirilmeZamani"].ToString()

                });
            }

            reader.Close();
            _sqlConnection.Close();

            return entryResimleri;
        }

        public override void Sil(PaylasimResmi veri)
        {
            string commandText =
                "exec sp_PaylasimResmiSil @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            

            _sqlCommand.Parameters.AddWithValue("@id", veri.Resim.ResimId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        private Resim ResimGetir(int id)
        {
            ResimDal resimDal = SQlResimDal.NesneUret();
            return resimDal.IstekGetir(id);

        }
    }
}
