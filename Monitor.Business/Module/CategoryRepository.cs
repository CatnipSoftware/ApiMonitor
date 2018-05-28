using Monitor.Business.Contract;
using Monitor.Domain.Model;
using Monitor.Domain.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Business.Module
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MonitorContext _context;

        public CategoryRepository(MonitorContext context)
        {
            _context = context;
        }

        public List<CategoryVm> List()
        {
            return _context.Set<Category>()
                    .Select(x => new CategoryVm
                    {
                        Id = x.Id,
                        Name = x.Name
                    })
                    .OrderBy(x => x.Name)
                    .ToList();
        }
    }
}