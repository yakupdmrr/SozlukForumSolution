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
    public class SQlResimDal : ResimDal
    {
        private static SQlResimDal _sqlResimDal;

        private static object _kilit = new object();

        private SQlResimDal() { }

        public static SQlResimDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlResimDal == null)
                {
                    _sqlResimDal = new SQlResimDal();
                }
            }
            return _sqlResimDal;
        }
        
        public override void Ekle(Resim veri)
        {
            string commandText =
                "insert Resimler values(@ResimYolu, @ResimAdi)";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
         


            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.ResimYolu);
            _sqlCommand.Parameters.AddWithValue("@ResimAdi", veri.ResimAdi);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(Resim veri)
        {
            string commandText =
                "update Resimler set ResimYolu = @ResimYolu, ResimAdi = @ResimAdi where ResimId = @ResimId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            


            _sqlCommand.Parameters.AddWithValue("@ResimId", veri.ResimId);
            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.ResimYolu);
            _sqlCommand.Parameters.AddWithValue("@ResimAdi", veri.ResimAdi);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<Resim> HepsiniGetir()
        {
            string commandText = "select * from Resimler";

            List<Resim> resimler = new List<Resim>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
        


            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                resimler.Add(new Resim
                {
                    ResimId = Convert.ToInt32(reader["ResimId"]),
                    ResimAdi = reader["ResimAdi"].ToString(),
                    ResimYolu = reader["ResimYolu"].ToString()
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return resimler;
        }

        public override Resim IstekGetir(int id)
        {
            string commandText = "select * from Resimler where ResimId = @id";

            Resim resim = new Resim();

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
                resim.ResimId = Convert.ToInt32(reader["ResimId"]);
                resim.ResimAdi = reader["ResimAdi"].ToString();
                resim.ResimYolu = reader["ResimYolu"].ToString();
            }

            reader.Close();
            _sqlConnection.Close();

            return resim;
        }

        public override void Sil(Resim veri)
        {
            string commandText =
                "delete from Resimler where ResimId = @id";

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
