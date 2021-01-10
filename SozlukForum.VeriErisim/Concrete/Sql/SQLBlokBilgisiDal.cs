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
    public class SQLBlokBilgisiDal:BlokBilgisiDal
    {

        private static SQLBlokBilgisiDal _sqlBlokBilgisiDal;

        private static object _kilit = new object();

       

        private SQLBlokBilgisiDal() { }

        public static SQLBlokBilgisiDal NesneUret()
        {
            lock (_kilit)
            {
                if (_sqlBlokBilgisiDal == null)
                {
                    _sqlBlokBilgisiDal = new SQLBlokBilgisiDal();
                }
            }
            return _sqlBlokBilgisiDal;
        }
        
        public override void Ekle(BlokBilgisi veri)
        {
            string commandText = "insert BlokBilgileri values(@BlokPaylasimId,@KullaniciId)";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText,_sqlConnection);
            

            _sqlCommand.Parameters.AddWithValue("@BlokPaylasimId", veri.BlokPaylasimId);
            _sqlCommand.Parameters.AddWithValue("@KullaniciId", veri.KullaniciId);

            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public override List<BlokBilgisi> IstekGetir(string paylasimId)
        {
            string commandText = "select bb.BlokBilgiId,bb.BlokPaylasimId,bb.KullaniciId from BlokBilgileri bb " +
                                 "inner join BloklananPaylasimlar bp on bp.BlokPaylasimId = bb.BlokPaylasimId where bp.PaylasimId = @paylasimId";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            List<BlokBilgisi> blokBilgileri = new List<BlokBilgisi>();

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);


            _sqlCommand.Parameters.AddWithValue("@paylasimId", paylasimId);

            SqlDataReader reader = _sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                blokBilgileri.Add(new BlokBilgisi
                {
                    KullaniciId = Convert.ToInt32(reader["KullaniciId"]),
                    BlokPaylasimId = Convert.ToInt32(reader["BlokPaylasimId"]),
                    BlokBilgiId = Convert.ToInt32(reader["BlokBilgiId"])
                });

            }
            reader.Close();
            _sqlConnection.Close();

            return blokBilgileri;
        }

        public override void Sil(BlokBilgisi veri)
        {
            string commandText = "delete from BlokBilgileri where BlokBilgiId = @id";

            SqlConnection _sqlConnection = new SqlConnection(yol);

            if (_sqlConnection.State == ConnectionState.Closed)
            {
                _sqlConnection.Open();
            }

            SqlCommand _sqlCommand = new SqlCommand(commandText, _sqlConnection);


            _sqlCommand.Parameters.AddWithValue("@BlokBilgiId", veri.BlokBilgiId);
           

            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }
    }
}
