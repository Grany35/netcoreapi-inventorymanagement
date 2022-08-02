using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.AddedProduct);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.DeletedProduct);
        }

        public IDataResult<Product> GetByBarcodeNumber(string barcodeNumber)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.BarcodeNumber == barcodeNumber));
        }

        public IDataResult<Product> GetByCategory(int categoryId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductCategoryId == categoryId));
        }
        
        public IDataResult<Product> Get(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id));
        }

        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.UpdatedProduct);
        }
    }
}
