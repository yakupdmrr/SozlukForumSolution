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
   public class SQLYorumMetniDal:YorumMetniDal
    {
        private static SQLYorumMetniDal _sqlYorumMetniDal;

        private static object _kilit = new object();

        private SQLYorumMetniDal() { }

        public static SQLYorumMetniDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlYorumMetniDal == null)
                {
                    _sqlYorumMetniDal = new SQLYorumMetniDal();
                }
            }
            return _sqlYorumMetniDal;
        }
        

        public override void Ekle(YorumMetni veri)
        {
            string commandText =
                "exec sp_YorumMetniEkle @YorumId, @PaylasimId, @KullaniciId, @GirilenMetin,@YapilmaZamani";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            


            _sqlCommand.Parameters.AddWithValue("@YorumId", veri.YorumId);
            _sqlCommand.Parameters.AddWithValue("@PaylasimId", veri.PaylasimId);
            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@GirilenMetin", veri.GirilenMetin);
            _sqlCommand.Parameters.AddWithValue("@YapilmaZamani", veri.YapilmaZamani);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        
    }

        public override void Sil(YorumMetni veri)
        {
            string commandText =
                "exec sp_YorumMetniSil @YorumId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
          

            _sqlCommand.Parameters.AddWithValue("@YorumId", veri.YorumId);
            
            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
        
        public override YorumMetni IstekGetir(string YorumId)
        {
            string commandText = "Exec sp_YorumMetniIstekGetir @id";

            YorumMetni yorumMetni = new YorumMetni();

            SqlConnection _sqlConnection = new SqlConnection(yol);


            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            


            _sqlCommand.Parameters.AddWithValue("@id", YorumId);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                yorumMetni.YorumId = reader["YorumId"].ToString();
                yorumMetni.PaylasimId = reader["PaylasimId"].ToString();
                yorumMetni.KullaniciId = Convert.ToInt32(reader["KullaniciId"]);
                yorumMetni.GirilenMetin = reader["YorumMetni"].ToString();
                yorumMetni.YapilmaZamani = reader["YapilmaZamani"].ToString();

            }

            reader.Close();
            _sqlConnection.Close();

            return yorumMetni;
        }

        public override void Guncelle(YorumMetni veri)
        {
            string commandText =
                "exec sp_YorumMetniGuncelle @YorumId, @GirilenMetin ";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
            


            _sqlCommand.Parameters.AddWithValue("@YorumId", veri.YorumId);
            _sqlCommand.Parameters.AddWithValue("@GirilenMetin", veri.GirilenMetin);


            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }
    }
}
