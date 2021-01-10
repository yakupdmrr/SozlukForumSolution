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
    public class SQLRaporlananPaylasimDal : RaporlananPaylasimDal
    {
        private static SQLRaporlananPaylasimDal _sqlRaporlananPaylasimDal;

        private static object _kilit = new object();

        private SQLRaporlananPaylasimDal() { }

        public static SQLRaporlananPaylasimDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlRaporlananPaylasimDal == null)
                {
                    _sqlRaporlananPaylasimDal = new SQLRaporlananPaylasimDal();
                }
            }
            return _sqlRaporlananPaylasimDal;
        }

        public override void Ekle(RaporlananPaylasim veri)
        {
            string commandText = "insert RaporlananPaylasimlar values(@PaylasimId)";

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

        public override List<RaporlananPaylasim> HepsiniGetir()
        {
            string commandText = "select * from RaporlananPaylasimlar";

            List<RaporlananPaylasim> raporlananPaylasimlar = new List<RaporlananPaylasim>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                raporlananPaylasimlar.Add(new RaporlananPaylasim
                {
                    PaylasimId = reader["PaylasimId"].ToString(),
                    RaporId = Convert.ToInt32(reader["RaporId"])
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return raporlananPaylasimlar;
        }

        public override void Sil(RaporlananPaylasim veri)
        {
            string commandText = "delete from RaporlananPaylasimlar where PaylasimId = @PaylasimId";

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
    }
}
