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
    public class SQLEtkilesimDal : EtkilesimDal
    {
        private static SQLEtkilesimDal _sqlEtkilesimDal;

        private static object _kilit = new object();

        private SQLEtkilesimDal() { }

        public static SQLEtkilesimDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlEtkilesimDal == null)
                {
                    _sqlEtkilesimDal = new SQLEtkilesimDal();
                }
            }
            return _sqlEtkilesimDal;
        }

        

        public override void Ekle(Etkilesim veri)
        {
            string commandText =
                "insert Etkilesimler values(@PaylasimId)";

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

        public override List<Etkilesim> HepsiniGetir()
        {
            string commandText = "select * from Etkilesimler";

            List<Etkilesim> etkilesimler = new List<Etkilesim>();

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                etkilesimler.Add(new Etkilesim
                {
                    PaylasimId = reader["PaylasimId"].ToString(),
                    EtkilesimId = Convert.ToInt32(reader["EtkilesimId"])

                });
            }

            reader.Close();

            _sqlConnection.Close();

            return etkilesimler;
        }
        
        public override void Sil(Etkilesim veri)
        {
            string commandText =
                "delete from Etkilesimler where EtkilesimId = @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            
            _sqlCommand.Parameters.AddWithValue("@id", veri.EtkilesimId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
    }
}
