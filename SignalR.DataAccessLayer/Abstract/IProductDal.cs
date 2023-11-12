using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {

        /// <summary>
        /// Kategorileriyle birlikte ürünlerin bir listesini alır.
        /// </summary>
        List<Product> GetProductsWithCategories();
    }
}
