using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels.ViewModels
{
    public class PagingModel<TModel> where TModel : class
    {
        public IEnumerable<TModel> DataSource { get; set; }
        public int PageSize { get; set; }
        public int TotalRows { get; set; }

    }
}
