using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwaggerBySwashbuckle.Model;

namespace SwaggerBySwashbuckle.Controllers
{
    /// <summary>
    /// 自动生成Controller
    /// </summary>
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static List<Product> Products = new List<Product>{
                new Product { ID = 1, Code = "0001", Name = "product_1" },
                new Product { ID = 2, Code = "0002", Name = "product_2" },
                new Product { ID = 3, Code = "0003", Name = "product_3" },
                new Product { ID = 4, Code = "0004", Name = "product_4" }
            };

        /// <summary>
        /// 获取所有的Product信息
        /// </summary>
        /// <returns>Return</returns>
        [HttpGet]
        public List<Product> Get()
        {
            return Products;
        }

        /// <summary>
        /// 获取指定ID的商品信息
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(String), 400)]
        public Product Get(int id)
        {
            return Products.Where(x => x.ID == id).FirstOrDefault();
        }

        /// <summary>
        ///新增一个Product
        /// </summary>
        /// <param name="product">Product对象</param>
        [HttpPost]
        public Product Post([FromBody]Product product)
        {
            int newID = Products.Max(x => x.ID) + 1;
            product.ID = newID;
            Products.Add(product);
            return product;
        }

        /// <summary>
        /// 更新一个product
        /// </summary>
        /// <param name="id">用于更新的productId</param>
        /// <param name="product">Product对象</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(string), 500)]
        public Product Put([FromQuery]int id, [FromBody]Product product)
        {
            var stockProduct = Products.FirstOrDefault(x => x.ID == id);
            if (stockProduct != null)
            {
                stockProduct.Code = product.Code ?? stockProduct.Code;
                stockProduct.Name = product.Name ?? stockProduct.Name;
                stockProduct.Image = product.Image ?? stockProduct.Image;
                return stockProduct;
            }
            else
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// 删除指定的Product
        /// </summary>
        /// <param name="id">id</param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = Products.FirstOrDefault(x => x.ID == id);
            if (product != null)
            {
                Products.Remove(product);
            }
        }
    }
}
