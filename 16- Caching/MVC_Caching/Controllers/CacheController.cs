using MVC_Caching.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace MVC_Caching.Controllers
{
    public class CacheController : Controller
    {
        // GET: DataCache

        NorthwindEntities _northwindService;
        public CacheController()
        {
            _northwindService = new NorthwindEntities();
        }
        public ActionResult Index()
        {
            List<Category> categories;
            if (HttpContext.Cache["kategori"] == null)
            {

                categories = _northwindService.Categories.ToList();
                HttpContext.Cache.Insert("kategori", categories);


                // Sliding Expiration => Onbellege atilan nesnenin otelemeli olarak yasamasini istiyorsaniz bu bitis tipini secebilirsiniz. TimeSpan tipinde sizden oteleme miktarini isteyecektir. Asagidaki ornekte ise, cache'in yasam suresi icerisinde bir istek gelmesi durumunda nesnenin omrunun 2 dakika daha uzatilmasi istenmistir!

                /*
                
                categories = _northwindService.Categories.ToList();
                HttpContext.Cache.Insert("kategori", categories, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(10));

                */


                // Absolute Expiration => Kesin zamanli olarak bir Cache'in onbellekte ne zaman bozulacagini belirtirsiniz. Genellikle new DateTime() diyip yeni bir tarih uretmektense, o anki tarihe ekleme yapan DateTime'in Add metotlarini kullanabilirsiniz. Asagidaki ornekte bu tip kullanilmakla beraber, ne olursa olsun ilgili cache'in 20 saniye yasayacagi belirtilmistir...

                /*
                 * 
                categories = _northwindService.Categories.ToList();
                HttpContext.Cache.Insert("kategori", categories, null, DateTime.Now.AddMinutes(2), System.Web.Caching.Cache.NoSlidingExpiration);

                */


                                 //        HttpContext.Cache.Insert(
                                 //"kategori",
                                 //categories,
                                 //null,
                                 //DateTime.Now.AddSeconds(50),
                                 //Cache.NoSlidingExpiration,
                                 //CacheItemPriority.High,
                                 //null
                                 //);



            }
            else
            {
                categories = HttpContext.Cache["kategori"] as List<Category>;
            }

            return View(categories);
        }
        
        //DEPENDENCY
        //Cache'teki nesnenizin harici bir fiziksel dosyaya bagimli olmasini saglamaktadir. Bagimli olmaktan kasit, ilgili dosya uzerinde bir degisiklik gerceklestigi takdirde, Cache'in imha edip tekrar olusturulmasini saglamaktir. Bir cache'i XML'e bagimli hale getirdiginiz takdirde ilgili XML uzerindeki tum degisiklikleri Cache mekanizmasi kontrol altinda tutacaktir. Ancak XML'e bagimli diye, verilerinizi o XML'den cekmek zorunda degilsiniz. Tabii bunun tek sarti, diger data kaynagindaki degisikligi es zamanli olarak XML'e de uyarlamanizdir; ki XML degissin ve Cache kendini yenilesin...


        public ActionResult XML()
        {
            List<Kategori> categories = _northwindService.Categories.Select(x => new Kategori
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).ToList();

            XmlSerializer xmlser = new XmlSerializer(typeof(List<Kategori>));
            StreamWriter swtr = new StreamWriter(Server.MapPath("../App_Data/Categories.xml"));
            xmlser.Serialize(swtr, categories);
            swtr.Close();

            return RedirectToAction("XMLDependency");
        }


        public ActionResult XMLDependency()
        {
            if (HttpContext.Cache["categories"] == null)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Kategori>));
                StreamReader str = new StreamReader(Server.MapPath("../App_Data/Categories.xml"));
                List<Kategori> categories = (List<Kategori>)xmlSerializer.Deserialize(str);
                str.Close();

                HttpContext.Cache.Insert("categories", categories, new System.Web.Caching.CacheDependency(Server.MapPath("../App_Data/categories.xml")));
            }

            List<Kategori> kategoriler = HttpContext.Cache["categories"] as List<Kategori>;
            return View(kategoriler);
        }
    }
}