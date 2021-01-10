using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.Veriler.Concrete;

namespace SozlukForum.VeriErisim.Concrete.Sql
{
    public class SQLYorumResmiDal : YorumResmiDal
    {
        private static SQLYorumResmiDal _sqlYorumResmiDal;

        private static object _kilit = new object();

        private SQLYorumResmiDal() { }

        public static SQLYorumResmiDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlYorumResmiDal == null)
                {
                    _sqlYorumResmiDal = new SQLYorumResmiDal();
                }
            }
            return _sqlYorumResmiDal;
        }

        
        public override void Ekle(YorumResmi veri)
        {
            string commandText =
                "exec sp_YorumResmiEkle @ResimAdi, @ResimYolu, @YorumId,@PaylasimId, @KullaniciId,@YapilmaZamani";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           

            _sqlCommand.Parameters.AddWithValue("@ResimAdi", veri.Resim.ResimAdi);
            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.Resim.ResimYolu);
            _sqlCommand.Parameters.AddWithValue("@YorumId", veri.YorumId);
            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);
            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@YapilmaZamani", veri.YapilmaZamani);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Sil(YorumResmi veri)
        {
            string commandText =
                "exec sp_YorumResmiSil @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@id", veri.Resim.ResimId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override void Guncelle(YorumResmi veri)
        {
            string commandText =
                "exec sp_YorumResmiGuncelle @ResimId, @ResimYolu ";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@ResimId", veri.Resim.ResimId);
            _sqlCommand.Parameters.AddWithValue("@ResimYolu", veri.Resim.ResimYolu);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override List<YorumResmi> IstekGetir(string YorumId)
        {
            string commandText = "Exec sp_YorumResmiIstekGetir @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            List<YorumResmi> yorumResimleri = new List<YorumResmi>();

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            


            _sqlCommand.Parameters.AddWithValue("@id", YorumId);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                yorumResimleri.Add(new YorumResmi
                {
                    PaylasimId = reader["PaylasimId"].ToString(),
                    Resim = ResimGetir(Convert.ToInt32(reader["ResimId"])),
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    YapilmaZamani = reader["YapilmaZamani"].ToString(),
                    YorumId = reader["YorumId"].ToString()
                });

            }

            reader.Close();
            _sqlConnection.Close();

            return yorumResimleri;
        }

        private Resim ResimGetir(int id)
        {
            ResimDal resimDal = SQlResimDal.NesneUret();
            return resimDal.IstekGetir(id);

        }
    }
}
