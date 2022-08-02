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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult addCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.AddedCustomer);
        }

        public IDataResult<List<Customer>> GetList()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }
    }
}
