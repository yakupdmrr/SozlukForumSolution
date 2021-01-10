using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;
using SozlukForum.VeriErisim.Concrete.Sql;

namespace SozlukForum.İs.Concrete.Secimler.Fabrikalar
{
   public class SQLFabrikasi:IVeritabaniFabrikasi
    {
        public BlokBilgisiDal BlokBilgisiDalOlustur()
        {
            return SQLBlokBilgisiDal.NesneUret();
        }

        public BlokPaylasimDal BlokPaylasimDalOlustur()
        {
            return SQLBlokPaylasimDal.NesneUret();
        }

        public EtkilesimDal EtkilesimDalOlustur()
        {
            return SQLEtkilesimDal.NesneUret();
        }

        public EtkilesimDislikeDal EtkilesimDislikeDalOlustur()
        {
           return SQLEtkilesimDislikeDal.NesneUret();
        }

        public EtkilesimLikeDal EtkilesimLikeDalOlustur()
        {
            return SQLEtkilesimLikeDal.NesneUret();
        }

        public KategoriDal KategoriDalOlustur()
        {
            return SQLKategoriDal.NesneUret();
        }

        public KullaniciDal KullaniciDalOlustur()
        {
            return SQLKullaniciDal.NesneUret();
        }

        public PaylasimDal PaylasimDalOlustur()
        {
            return SQLPaylasimDal.NesneUret();
        }

        public PaylasimMetniDal PaylasimMetniDalOlustur()
        {
          return SQLPaylasimMetniDal.NesneUret();
        }

        public PaylasimResmiDal PaylasimResmiDalOlustur()
        {
           return SQLPaylasimResmiDal.NesneUret();
        }

        public ProfilResmiDal ProfilResmiDalOlustur()
        {
            return SQLProfilResmiDal.NesneUret();
        }

        public RaporBilgiDal RaporBilgiDalOlustur()
        {
            return SQLRaporBilgisiDal.NesneUret();
        }

        public RaporlananPaylasimDal RaporlananPaylasimDalOlustur()
        {
          return SQLRaporlananPaylasimDal.NesneUret();
        }

        public ResimDal ResimDalOlustur()
        {
           return SQlResimDal.NesneUret();
        }

        public YorumDal YorumDalOlustur()
        {
            return SQLYorumDal.NesneUret();
        }

        public YorumMetniDal YorumMetniDalOlustur()
        {
            return SQLYorumMetniDal.NesneUret();
        }

        public YorumResmiDal YorumResmiDalOlustur()
        {
          return SQLYorumResmiDal.NesneUret();
        }
    }
}
