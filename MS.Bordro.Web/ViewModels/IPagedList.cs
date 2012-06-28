using System.Collections.Generic;

namespace MS.Bordro.Web.ViewModels
{
    public interface IPagedList<T> 
    {
        IEnumerable<T> Items { get; set; }
        int TotalRecords { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
    }
}