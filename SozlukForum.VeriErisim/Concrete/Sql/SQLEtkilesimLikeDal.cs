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
    public class SQLEtkilesimLikeDal : EtkilesimLikeDal
    {
        private static SQLEtkilesimLikeDal _sqlEtkilesimLikeDal;

        private static object _kilit = new object();

        private SQLEtkilesimLikeDal() { }

        public static SQLEtkilesimLikeDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlEtkilesimLikeDal == null)
                {
                    _sqlEtkilesimLikeDal = new SQLEtkilesimLikeDal();
                }
            }
            return _sqlEtkilesimLikeDal;
        }
        

        public override void Ekle(EtkilesimLike veri)
        {
            string commandText =
                "exec sp_EtkilesimLikeEkle @PaylasimId, @BegenenKullaniciId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            

            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);
            _sqlCommand.Parameters.AddWithValue("@BegenenKullaniciId", veri.BegenenKullaniciId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
        
        public override List<EtkilesimLike> IstekGetir(string PaylasimId)
        {
            string commandText = "exec sp_EtkilesimLikeIstekGetir @PaylasimId";

            List<EtkilesimLike> etkilesimLikelar = new List<EtkilesimLike>();

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
                etkilesimLikelar.Add(new EtkilesimLike
                {
                    BegenenKullaniciId = Convert.ToInt32(reader["BegenenKullaniciId"]),
                    EtkilesimId = Convert.ToInt32(reader["EtkilesimId"]),
                    PaylasimId = reader["PaylasimId"].ToString()
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return etkilesimLikelar;
        }

        public override void Sil(EtkilesimLike veri)
        {
            string commandText =
                "exec sp_EtkilesimLikeSil @begeniyiKaldiranKullanici, @PaylasimId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            


            _sqlCommand.Parameters.AddWithValue("@begeniyiKaldiranKullanici", veri.BegenenKullaniciId);
            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
    }
}
