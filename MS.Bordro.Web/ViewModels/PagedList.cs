using System.Collections.Generic;

namespace MS.Bordro.Web.ViewModels
{
    public class PagedList<T> : IPagedList<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int TotalRecords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}