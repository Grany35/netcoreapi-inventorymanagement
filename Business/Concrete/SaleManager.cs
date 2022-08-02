using Business.Abstract;
using Business.Constans;
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
    public class SaleManager : ISaleService
    {
        private readonly ISaleDal _saleDal;
        private readonly IProductService _productService;
        


        public SaleManager(ISaleDal saleDal, IProductService productService)
        {
            _saleDal = saleDal;
            _productService = productService;
        }

        public IResult Add(Sale sale)
        {
            var product = _productService.Get(sale.ProductId).Data;
            if (sale.Price == 0)
            {
                sale.Price = product.Price * sale.Quantity;
            }
            _saleDal.Add(sale);
            product.Stock = product.Stock - sale.Quantity;
            _productService.Update(product);
            return new SuccessResult(Messages.AddedSale);
        }

        public IResult AddSaleWithBarcode(Sale sale, string barcodeNumber)
        {
            var product = _productService.GetByBarcodeNumber(barcodeNumber).Data;
            if (sale.Price == 0 && sale.ProductId == 0)
            {
                var totalPrice = product.Price * sale.Quantity;
                sale.Price = totalPrice;

                sale.ProductId = product.ProductId;
            }
            _saleDal.Add(sale);
            return new SuccessResult(Messages.AddedSale);
        }

        public IResult Delete(Sale sale)
        {
            _saleDal.Delete(sale);
            return new SuccessResult(Messages.SaleDeleted);
        }

        public IDataResult<Sale> Get(int id)
        {
            return new SuccessDataResult<Sale>(_saleDal.Get(p => p.SaleId == id));
        }

        public IDataResult<List<Sale>> GetList()
        {
            return new SuccessDataResult<List<Sale>>(_saleDal.GetAll());
        }

        public IResult Update(Sale sale)
        {
            _saleDal.Update(sale);
            return new SuccessResult(Messages.SaleUpdated);
        }
    }
}
