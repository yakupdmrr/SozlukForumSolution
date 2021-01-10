using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SozlukForum.VeriErisim.Abstracts.VeriErisimBaseleri;


namespace SozlukForum.İs.Concrete.Secimler
{
    public interface IVeritabaniFabrikasi
    {
        BlokBilgisiDal BlokBilgisiDalOlustur();
        BlokPaylasimDal BlokPaylasimDalOlustur();
        EtkilesimDal EtkilesimDalOlustur();
        EtkilesimDislikeDal EtkilesimDislikeDalOlustur();
        EtkilesimLikeDal EtkilesimLikeDalOlustur();
        KategoriDal KategoriDalOlustur();
        KullaniciDal KullaniciDalOlustur();
        PaylasimDal PaylasimDalOlustur();
        PaylasimMetniDal PaylasimMetniDalOlustur();
        PaylasimResmiDal PaylasimResmiDalOlustur();
        ProfilResmiDal ProfilResmiDalOlustur();
        RaporBilgiDal RaporBilgiDalOlustur();
        RaporlananPaylasimDal RaporlananPaylasimDalOlustur();
        ResimDal ResimDalOlustur();
        YorumDal YorumDalOlustur();
        YorumMetniDal YorumMetniDalOlustur();
        YorumResmiDal YorumResmiDalOlustur();
    }
}
