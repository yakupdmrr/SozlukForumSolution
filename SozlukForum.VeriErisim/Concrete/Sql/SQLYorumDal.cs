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
    public class SQLYorumDal : YorumDal
    {
        private static SQLYorumDal _yorumDal;

        private static object _kilit = new object();

        private SQLYorumDal() { }

        public static SQLYorumDal NesneUret()
        {
            lock (_kilit)
            {
                if (_yorumDal == null)
                {
                    _yorumDal = new SQLYorumDal();
                }
            }
            return _yorumDal;
        }
        

        public override void Ekle(Yorum veri)
        {
            string commandText =
                "insert Yorumlar values(@YorumId, @EtkilesimId, @KullaniciId,@YapilmaZamani)";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            


            _sqlCommand.Parameters.AddWithValue("@YorumId", veri.PaylasimId);
            _sqlCommand.Parameters.AddWithValue("@EtkilesimId", veri.EtkilesimId);
            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@YapilmaZamani", veri.YapilmaZamani);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<Yorum> IstekGetir(string PaylasimId)
        {
            string commandText = "exec sp_YorumIstekGetir @PaylasimId";

            List<Yorum> yorumlar = new List<Yorum>();

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText,_sqlConnection);
          


            _sqlCommand.Parameters.AddWithValue("@PaylasimId", PaylasimId);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                yorumlar.Add(new Yorum
                {
                    PaylasimId = reader["PaylasimId"].ToString(),
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    EtkilesimId = Convert.ToInt32(reader["KullaniciId"]),
                    YorumId = reader["YorumId"].ToString(),
                    YapilmaZamani = reader["YapilmaZamani"].ToString(),
                    YorumTipi = Convert.ToInt32(reader["YorumTipi"])
                });
            }

            reader.Close();
            _sqlConnection.Close();

            return yorumlar;
        }

        public override void Sil(Yorum veri)
        {
            string commandText =
                "delete from Yorumlar where YorumId = @id";

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
    }
}
