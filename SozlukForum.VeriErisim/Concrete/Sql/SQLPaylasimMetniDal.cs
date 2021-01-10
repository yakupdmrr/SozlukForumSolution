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
    public class SQLPaylasimMetniDal:PaylasimMetniDal
    {
        private static SQLPaylasimMetniDal _sqlPaylasimMetniDal;

        private static object _kilit = new object();

        private SQLPaylasimMetniDal() { }

        public static SQLPaylasimMetniDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlPaylasimMetniDal == null)
                {
                    _sqlPaylasimMetniDal = new SQLPaylasimMetniDal();
                }
            }
            return _sqlPaylasimMetniDal;
        }
        

        public override void Ekle(PaylasimMetni veri)
        {
            string commandText =
                "exec sp_PaylasimMetniEkle  @PaylasimId, @KategoriId, @KullaniciId,@GirilenMetin, @GirilmeZamani";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           

            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);
            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@GirilenMetin", veri.GirilenMetin);
            _sqlCommand.Parameters.AddWithValue("@GirilmeZamani", veri.GirilmeZamani);
            _sqlCommand.Parameters.AddWithValue("@KategoriId", veri.KategoriId);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();

        }

        public override void Sil(PaylasimMetni veri)
        {
            string commandText =
                "exec sp_PaylasimMetniSil  @PaylasimId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           

            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);
           

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<PaylasimMetni> HepsiniGetir()
        {
            string commandText = "exec sp_PaylasimMetniHepsiniGetir";

            List<PaylasimMetni> entryMetinleri = new List<PaylasimMetni>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                entryMetinleri.Add(new PaylasimMetni
                {
                  
                    GirilenMetin = reader["YorumMetni"].ToString(),
                    PaylasimId = reader["PaylasimId"].ToString(),
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    KategoriId = Convert.ToInt32(reader["KategoriId"]),
                    GirilmeZamani = reader["GirilmeZamani"].ToString()

                });
            }

            reader.Close();
            _sqlConnection.Close();

            return entryMetinleri;
        }

        public override void Guncelle(PaylasimMetni veri)
        {
            string commandText =
                "exec sp_PaylasimMetniGuncelle @PaylasimId, @GuncellenecekMetin ";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);
            _sqlCommand.Parameters.AddWithValue("@GuncellenecekMetin", veri.GirilenMetin);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override PaylasimMetni IstekGetir(string paylasimId)
        {
            string commandText = "exec sp_PaylasimMetniIstekGetir @id";

            PaylasimMetni paylasimMetni = new PaylasimMetni();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);

            _sqlCommand.Parameters.AddWithValue("@id", paylasimId);


            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                paylasimMetni.GirilenMetin = reader["GirilenMetin"].ToString();
                paylasimMetni.PaylasimId = reader["PaylasimId"].ToString();
                paylasimMetni.KullaniciId = Convert.ToInt32(reader["KullaniciId"]);
                paylasimMetni.KategoriId = Convert.ToInt32(reader["KategoriId"]);
                paylasimMetni.GirilmeZamani = reader["GirilmeZamani"].ToString();
            }

            reader.Close();
            _sqlConnection.Close();

            return paylasimMetni;
        }
    }
}
