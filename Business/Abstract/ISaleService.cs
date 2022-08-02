using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISaleService
    {
        IResult Add(Sale sale);
        IResult Update(Sale sale);
        IResult Delete(Sale sale);
        IDataResult<Sale> Get(int id);
        IDataResult<List<Sale>> GetList();
        IResult AddSaleWithBarcode(Sale sale,string barcodeNumber);
    }
}
