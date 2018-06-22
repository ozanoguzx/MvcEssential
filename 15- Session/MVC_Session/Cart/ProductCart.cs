using MVC_Session.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Session.Cart
{
    public class ProductCart
    {
        private Dictionary<int, ProductVM> _chart = null;
        public List<ProductVM> ChartProductList
        {
            get
            {
                return _chart.Values.ToList();
            }
        }
        public ProductCart()
        {
            _chart = new Dictionary<int, ProductVM>();
        }

        #region Sepete Ekle
        public void AddCart(ProductVM item)
        {
            if (!_chart.ContainsKey(item.Id))
            {
                _chart.Add(item.Id, item);
            }
            else
            {
                _chart[item.Id].Quantity++;
            }
        }
        #endregion

        #region Sepetten Sil
        public void RemoveChart(int id)
        {
            _chart.Remove(id);
        }
        #endregion

        #region Sepetten Adet Azalt
        public void DecreaseCart(int id)
        {
            _chart[id].Quantity--;

            if (_chart[id].Quantity <= 0)
                _chart.Remove(id);
        }
        #endregion

        #region Sepetten Adet Arttır
        public void IncreaseCart(int id)
        {
            _chart[id].Quantity++;
        }
        #endregion
    }
}