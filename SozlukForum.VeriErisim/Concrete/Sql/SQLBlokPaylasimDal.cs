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
    public class SQLBlokPaylasimDal:BlokPaylasimDal
    {
        private static SQLBlokPaylasimDal _sqlBlokPaylasimDal;
        
        private static object _kilit = new object();

        private SQLBlokPaylasimDal() { }

        public static SQLBlokPaylasimDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlBlokPaylasimDal == null)
                {
                    _sqlBlokPaylasimDal = new SQLBlokPaylasimDal();
                }
            }
            return _sqlBlokPaylasimDal;
        }

        
        public override void Ekle(BlokPaylasim veri)
        {
            string commandText =
                "insert BloklananPaylasimlar values(@PaylasimId)";

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

        public override void Sil(BlokPaylasim veri)
        {
            string commandText =
                "delete from BloklananPaylasimlar where PaylasimId = @id";

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

       
        public override List<BlokPaylasim> HepsiniGetir()
        {
            string commandText = "select * from BloklananPaylasimlar";

            List<BlokPaylasim> bloklananPaylasimlar = new List<BlokPaylasim>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                bloklananPaylasimlar.Add(new BlokPaylasim
                {
                    BlokPaylasimId = Convert.ToInt32(reader["BlokPaylasimId"]),
                    PaylasimId =reader["PaylasimId"].ToString(),
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return bloklananPaylasimlar;
        }

        public override BlokPaylasim IstekGetir(int id)
        {
            string commandText = "select * from BloklananPaylasimlar where BlokPaylasimId = @id";

            BlokPaylasim blokEntry = new BlokPaylasim();

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
                blokEntry.BlokPaylasimId = Convert.ToInt32(reader["BlokPaylasimId"]);
                blokEntry.PaylasimId = reader["PaylasimId"].ToString();
            }

            reader.Close();
            _sqlConnection.Close();

            return blokEntry;
        }
    }
}
