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
    public class SQLEtkilesimDislikeDal:EtkilesimDislikeDal
    {
        private static SQLEtkilesimDislikeDal _sqlEtkilesimDislikeDal;

        private static object _kilit = new object();

        private SQLEtkilesimDislikeDal() { }

        public static SQLEtkilesimDislikeDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlEtkilesimDislikeDal == null)
                {
                    _sqlEtkilesimDislikeDal = new SQLEtkilesimDislikeDal();
                }
            }
            return _sqlEtkilesimDislikeDal;
        }
        
        public override void Ekle(EtkilesimDislike veri)
        {
            string commandText =
                "exec sp_EtkilesimDislikeEkle @PaylasimId, @BegenmeyenKullaniciId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           

            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);
            _sqlCommand.Parameters.AddWithValue("@BegenmeyenKullaniciId", veri.BegenmeyenKullaniciId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Sil(EtkilesimDislike veri)
        {
            string commandText =
                "Exec sp_EtkilesimDislikeSil @dislikeKaldıranKullanici, @PaylasimId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            

            _sqlCommand.Parameters.AddWithValue("@dislikeKaldıranKullanici", veri.BegenmeyenKullaniciId);
            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<EtkilesimDislike> IstekGetir(string PaylasimId)
        {
            string commandText = "exec sp_EtkilesimDislikeIstekGetir @PaylasimId";

            List<EtkilesimDislike> etkilesimDislikelar = new List<EtkilesimDislike>();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
          


            _sqlCommand.Parameters.AddWithValue("@PaylasimId", PaylasimId);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                etkilesimDislikelar.Add(new EtkilesimDislike
                {
                    BegenmeyenKullaniciId = Convert.ToInt32(reader["BegenmeyenKullaniciId"]),
                    EtkilesimId = Convert.ToInt32(reader["EtkilesimId"]),
                    PaylasimId = reader["PaylasimId"].ToString()
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return etkilesimDislikelar;
        }
    }
}
