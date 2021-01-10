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
    public class SQLKategoriDal : KategoriDal
    {
        private static SQLKategoriDal _sqlKategoriDal;

        private static object _kilit = new object();

        private SQLKategoriDal() { }

        public static SQLKategoriDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlKategoriDal == null)
                {
                    _sqlKategoriDal = new SQLKategoriDal();
                }
            }
            return _sqlKategoriDal;
        }
        

        public override void Ekle(Kategori veri)
        {
            string commandText =
                "insert Kategoriler values(@KategoriAdi)";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
          


            _sqlCommand.Parameters.AddWithValue("@KategoriAdi", veri.KategoriAdi);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(Kategori veri)
        {
            string commandText =
                "update Kategoriler set KategoriAdi = @KategoriAdi where KategoriId = @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@KategoriAdi", veri.KategoriAdi);
            _sqlCommand.Parameters.AddWithValue("@KategoriId", veri.KategoriId);
           

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<Kategori> HepsiniGetir()
        {
            string commandText = "select * from Kategoriler";

            List<Kategori> kategoriler = new List<Kategori>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                kategoriler.Add(new Kategori
                {
                    KategoriAdi = reader["KategoriAdi"].ToString(),
                    KategoriId = Convert.ToInt32(reader["KategoriId"])
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return kategoriler;
        }

        public override Kategori IstekGetir(int id)
        {
            string commandText = "select * from Kategoriler where KategoriId = @id";

            Kategori kategori = new Kategori();

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
                kategori.KategoriId = Convert.ToInt32(reader["KategoriId"]);
                kategori.KategoriAdi = reader["KategoriAdi"].ToString();

            }

            reader.Close();
            _sqlConnection.Close();

            return kategori;
        }

        public override Kategori IstekGetir(string KategoriAdi)
        {
            string commandText = "select * from Kategoriler where KategoriAdi = @KategoriAdi";

            Kategori kategori = new Kategori();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
          


            _sqlCommand.Parameters.AddWithValue("@KategoriAdi", KategoriAdi);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                kategori.KategoriId = Convert.ToInt32(reader["KategoriId"]);
                kategori.KategoriAdi = reader["KategoriAdi"].ToString();

            }

            reader.Close();
            _sqlConnection.Close();

            return kategori;
        }

        public override void Sil(Kategori veri)
        {
            string commandText =
                "delete from Kategoriler where KategoriId = @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@id", veri.KategoriId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
    }
}
