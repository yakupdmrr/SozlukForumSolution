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
    public class SQLPaylasimDal : PaylasimDal
    {

        private static SQLPaylasimDal _sqlPaylasimDal;

        private static object _kilit = new object();

        private SQLPaylasimDal() { }

        public static SQLPaylasimDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlPaylasimDal == null)
                {
                    _sqlPaylasimDal = new SQLPaylasimDal();
                }
            }
            return _sqlPaylasimDal;
        }

        
        public override void Ekle(Paylasim veri)
        {
            string commandText =
                "insert Paylasimlar values(@PaylasimId, @KategoriId, @KullaniciId,@PaylasimTipi,@GirilmeZamani)";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
          

            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);
            _sqlCommand.Parameters.AddWithValue("@KategoriId", veri.KategoriId);
            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@PaylasimTipi", veri.PaylasimTipi);
            _sqlCommand.Parameters.AddWithValue("@GirilmeZamani", veri.GirilmeZamani);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Sil(Paylasim veri)
        {
            string commandText =
                "delete from Paylasimlar where PaylasimId = @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
          

            _sqlCommand.Parameters.AddWithValue("@id", veri.PaylasimId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }


        public override List<Paylasim> HepsiniGetir()
        {
            string commandText = "select * from Paylasimlar";

            List<Paylasim> paylasimlar = new List<Paylasim>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
         

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                paylasimlar.Add(new Paylasim
                {
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    PaylasimId = reader["PaylasimId"].ToString(),
                    KategoriId = Convert.ToInt32(reader["KategoriId"]),
                    PaylasimTipi = Convert.ToInt32(reader["PaylasimTipi"]),
                    GirilmeZamani = reader["GirilmeZamani"].ToString()
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return paylasimlar;

        }
        
    }
}
