using MVC_Session.Cart;
using MVC_Session.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVC_Session.Controllers
{
    public class CartController : Controller
    {
        NorthwindEntities _northwindService;
        public CartController()
        {
            _northwindService = new NorthwindEntities();
        }

        public ActionResult Index()
        {
            return View();
        }

        #region Sepet Listesi
        public JsonResult List()
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                List<ProductVM> productList = cart.ChartProductList.Select(x => new ProductVM
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    UnitPrice = x.UnitPrice,
                    UnitsInstock = x.UnitsInstock,
                    Quantity = x.Quantity
                }).ToList();

                return Json(productList, JsonRequestBehavior.AllowGet);
            }

            return Json("Empty", JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Sepete Ekleme
        [HttpPost]
        public JsonResult Add(int id)
        {
            Product product = _northwindService.Products.Find(id);
            ProductVM vm = new ProductVM
            {
                Id = product.ProductID,
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                UnitsInstock = product.UnitsInStock,
                Quantity = 1
            };

            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.AddCart(vm);
                Session["sepet"] = cart;
            }
            else
            {
                ProductCart cart = new ProductCart();
                cart.AddCart(vm);
                Session.Add("sepet", cart);
            }
            return Json("");
        }
        #endregion

        #region Ürün Azaltma
        public JsonResult DecreaseCart(int id)
        {
            if (Session["sepet"] != null)
            {
                ProductCart cart = Session["sepet"] as ProductCart;
                cart.DecreaseCart(id);
                Session["sepet"] = cart;
            }
            return Json("");
        }
        #endregion

        #region Ürün Arttırma
        public JsonResult IncreaseCart(int id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.IncreaseCart(id);
            Session["sepet"] = cart;
            return Json("");
        }
        #endregion

        #region Sepetten Ürün Silme
        public JsonResult Remove(int id)
        {
            ProductCart cart = Session["sepet"] as ProductCart;
            cart.RemoveChart(id);
            Session["sepet"] = cart;
            return Json("");
        }
        #endregion
    }
}