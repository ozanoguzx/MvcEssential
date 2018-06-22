using MVC_Caching.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Caching.Controllers
{
    public class OutputCacheController : Controller
    {
        // GET: Category
        NorthwindEntities _northwindService;
        public OutputCacheController()
        {
            _northwindService = new NorthwindEntities();
        }

        // [OutputCache(CacheProfile = "Category")]
        public ActionResult Index()
        {
            return View();
        }

        // Duration     : Saniye cinsinden sizden değer ister 

        // VaryByParam  : Cache QueryString veya RouteValue üzerinden gönderdiğiniz parametre ile bozulmasını isterseniz belirtmeniz gerekmektedir. Birden fazla parametre sözkonusu ise ilgili alan içerisindeki parametreleri ";" işareti ile ayırarak kullanabilirsiniz ya da ilgili alana "*" koyarak tüm parametreleri geçerli kılabilirsiniz

        // CacheProfile : WebConfig' de   <system.web> içerisinde  ;
        // <caching>
        // <outputCacheSettings>
        // <outputCacheProfiles>
        // <add name = "BirSaat" duration="3600" varyByParam="none"/>
        // </outputCacheProfiles>
        // </outputCacheSettings>
        // </caching>
        // Birden fazla profil oluşturarak kullanabilirsiniz. NOT : Action için kullanılır.

        // Client bazlı Caching : OutputCache ile yapılabilecek olan Cache işlemlerinin lokasyonunu yani baz alınacak olan referans yerini belirleyebilirsiniz. Kullanıcıya ait Cache'lemeniz gereken verileri kişi tarafında Cache'leme işlemi (ClientSide Caching) kullanarak çözebilirsiniz. Bunun için kullanmanız gereken parametre ; " Location = System.Web.UI.OutputCacheLocation.Client "  Sadece Client tarafta tuttuğunuz gibi her iki tarafta'da bu işlemi gerçekleştirebilirsiniz. " NoStore = true " parametresi ise; Performans kaybını engellemek için Render bilgilerini kalıcı olarak saklanmasını engellemiş olursunuz.
        //

        // [OutputCache(Duration = 1000, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Client, NoStore = true)]

        [OutputCache(Duration = 1000, VaryByParam = "none")]
        public PartialViewResult _CategoryPartial()
        {
            var CategoryList = _northwindService.Categories.ToList();
            return PartialView(CategoryList);
        }


        [OutputCache(Duration = 1000, VaryByParam = "id")]
        public PartialViewResult _CategoryPartialParam(int? id)
        {
            var CategoryList = _northwindService.Categories.ToList();
            return PartialView(CategoryList);
        }
    }
}