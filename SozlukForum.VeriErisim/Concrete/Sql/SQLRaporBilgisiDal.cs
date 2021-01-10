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
    public class SQLRaporBilgisiDal:RaporBilgiDal
    {
        private static SQLRaporBilgisiDal _sqlRaporBilgisiDal;

        private static object _kilit = new object();

        private SQLRaporBilgisiDal() { }

        public static SQLRaporBilgisiDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlRaporBilgisiDal == null)
                {
                    _sqlRaporBilgisiDal = new SQLRaporBilgisiDal();
                }
            }
            return _sqlRaporBilgisiDal;
        }
        
        public override void Ekle(RaporBilgisi veri)
        {
            string commandText = "insert RaporBilgileri values(@KullaniciId, @RaporId)";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);
            _sqlCommand.Parameters.AddWithValue("@RaporId", veri.RaporId);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

        public override int PaylasiminRaporSayisi(string PaylasimId)
        {
            string commandText = "exec sp_PaylasiminRaporSayisi @PaylasimId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            int raporSayisi = 0;
             
            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@KullaniciId", PaylasimId);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                raporSayisi = Convert.ToInt32(reader["Sayi"]);
            }

            reader.Close();
            _sqlConnection.Close();

            return raporSayisi;

        }

        public override void Sil(RaporBilgisi veri)
        {
            string commandText = "delete from RaporBilgileri where RaporBilgiId = @RaporBilgiId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);
           


            _sqlCommand.Parameters.AddWithValue("@RaporBilgiId", veri.RaporBilgid);

            _sqlCommand.ExecuteNonQuery();

            _sqlConnection.Close();
        }

         
    }
}
