using Monitor.Domain.ViewModel;
using System.Collections.Generic;

namespace Monitor.Business.Contract
{
    public interface ICategoryRepository
    {
        List<CategoryVm> List();
    }
}