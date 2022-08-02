using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<List<Product>> GetList();
        IDataResult<Product> GetByCategory(int categoryId);
        IDataResult<Product> Get(int id);
        IDataResult<Product> GetByBarcodeNumber(string barcodeNumber);
    }
}
