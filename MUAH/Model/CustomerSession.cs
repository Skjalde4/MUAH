using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAH.Model
{
    class CustomerSession
    {
        public Guid SessionId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int NoOfProduct { get; set; }

        //public CustomerSession(string sessionId, string productName, double productPrice, string productDescription, string productCategory, int noOfProduct)
        //{
        //    SessionId = sessionId;
        //    ProductName = productName;
        //    ProductPrice = productPrice;
        //    ProductDescription = productDescription;
        //    ProductCategory = productCategory;
        //    NoOfProduct = noOfProduct;
        //}

        //public override string ToString()
        //{
        //    return $"{nameof(SessionId)}: {SessionId}, {nameof(ProductName)}: {ProductName}, {nameof(ProductPrice)}: {ProductPrice}, {nameof(ProductDescription)}: {ProductDescription}, {nameof(ProductCategory)}: {ProductCategory}, {nameof(NoOfProduct)}: {NoOfProduct}";
        //}
    }
}
