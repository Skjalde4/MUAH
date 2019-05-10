using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MUAH.ViewModel;

namespace MUAH.Handler
{
    class BasketHandler
    {
        //TODO
        public BasketViewModel ProductViewModel { get; set; }

        public BasketHandler(BasketViewModel pvm)
        {
            ProductViewModel = pvm;
        }

        public void AddProducts()
        {
            ProductViewModel.CsSingleton.AddProductsToBasket();
        }

        //public void DeleteProduct()
        //{
        //    ProductViewModel.ProductSingleton.DeleteProduct(ProductViewModel.SelectedProduct);
        //}

        //public void CreateProduct()
        //{
        //    ProductViewModel.ProductSingleton.PostProduct(ProductViewModel.Name, ProductViewModel.Description, ProductViewModel.Price);
        //}

        //public void SetSelectedProduct(Product product)
        //{
        //    ProductViewModel.SelectedProduct = product;
        //}
    }
}
