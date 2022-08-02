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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator))]
        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.AddedCategory);
        }

        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }
    }
}
