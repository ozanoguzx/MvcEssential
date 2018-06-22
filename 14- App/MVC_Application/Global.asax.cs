using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Xml;

namespace MVC_Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Application => Anahtar - deger ikilisi mantigiyla calisan bir koleksiyon olarak karsimiza cikmaktadir. Bu koleksiyon icerisinde uygulamaniza ozgu anahtarlari ve o anahtarlarin tasimis oldugu degerleri muhafaza edebilirsiniz...
            Application.Add("onlineUser", 0);

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //Eger Session_Start eventi tetiklenmis ise, kullanici siteye bir istekte bulunmus demektir. Bu istek durumunda, online kullanici sayisini bir arttirmaliyiz...

            //Her ne kadar mantik cercevesinde, birden fazla kullanicin ayni anda (milisaniye cinsiden dahi olsa) girmesi cok mumkun gozukmese de bizler her ihtimali goze alarak bu durumu da cozum uretmeliyiz. Ayni anda kullanicilarin giris yapmasi durumunda bile, once koleksiyonu kilitler, daha sonra icerideki degeri degistirir ve koleksiyonu tekrar kullanima acariz. Bir nevi turnike sistemi de denilebilir...
            Application.Lock();
            Application["onlineUser"] = ((int)Application["onlineUser"]) + 1;
            Application.UnLock();
        }
        //Uygulamadaki herhangi bir dosyaya talep(request) geldiğinde tetiklenir
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }
        //FormsAuthentication kullanıldığında kullanıcının sisteme başarılı şekilde giriş yapması durumunda tetiklenecek olan olaydır. 
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //Uygulamanin herhangi bir noktasında bir hata meydana geldigi zaman, hatanin islenmesi icin tetiklenen event'tir...
            Exception sonHata = Server.GetLastError();

            //Aldigimiz son hata icerisinde bir detay mesaji varsa, o mesaji; yoksa genel mesaji atama yapiyoruz!
            string hataMesaji = sonHata.InnerException != null ? sonHata.InnerException.Message : sonHata.Message;
            DateTime hataZamani = DateTime.Now;
            //NOT: Server degiskenlerini http://www.w3schools.com/asp/coll_servervariables.asp adresinden temin edebilirsiniz. Asagidaki degisken size istekte bulunan makinanın IP'sini teslim eder...(diğeri:SERVER_NAME)
            string kullaniciIP = Request.ServerVariables["REMOTE_ADDR"];

            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("../App_Data/ErrorLog.xml"));

            XmlElement eleman = doc.CreateElement("Hata");

            XmlNode node_mesaj = doc.CreateNode(XmlNodeType.Element, "HataMesaji", null);
            node_mesaj.InnerText = hataMesaji;

            XmlNode node_tarih = doc.CreateNode(XmlNodeType.Element, "HataTarihi", null);
            node_tarih.InnerText = hataZamani.ToString();

            XmlNode node_IP = doc.CreateNode(XmlNodeType.Element, "MakineIP", null);
            node_IP.InnerText = kullaniciIP;

            eleman.AppendChild(node_mesaj);
            eleman.AppendChild(node_tarih);
            eleman.AppendChild(node_IP);

            doc.DocumentElement.AppendChild(eleman);

            doc.Save(Server.MapPath("../App_Data/ErrorLog.xml"));
        }

        protected void Session_End(object sender, EventArgs e)
        {
            //Eger Session_End eventi tetiklenmis ise, bir kullanicin oturumunun sunucu tarafta sonlandigi anlamina gelir. Dogal olarak o kullaniciya ait veriler silinecegi icin, kullanici sayisini bir azaltabiliriz...
            Application.Lock();
            Application["onlineUser"] = ((int)Application["onlineUser"]) - 1;
            Application.UnLock();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
