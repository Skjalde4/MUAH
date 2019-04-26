using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUAH.Model
{
    public class CustomerSession
    {
        public Guid SessionId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int NoOfProduct { get; set; }

        public override string ToString()
        {
            return $"{nameof(SessionId)}: {SessionId}, {nameof(ProductId)}: {ProductId}, {nameof(ProductName)}: {ProductName}, {nameof(ProductPrice)}: {ProductPrice}, {nameof(NoOfProduct)}: {NoOfProduct}";
        }
    }
}
