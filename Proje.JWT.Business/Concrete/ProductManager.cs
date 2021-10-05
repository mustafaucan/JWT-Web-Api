using Proje.JWT.Business.Interfaces;
using Proje.JWT.DataAccess.Interfaces;
using Proje.JWT.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.JWT.Business.Concrete
{
   public  class ProductManager : GenericManager<Product>,IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IGenericDal<Product> genericDal, IProductDal productDal):base(genericDal)
        {
            _productDal = productDal;
        }
    }
}
