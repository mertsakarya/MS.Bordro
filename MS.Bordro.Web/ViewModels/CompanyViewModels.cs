using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MS.Bordro.Web.Models;

namespace MS.Bordro.Web.ViewModels
{
    public class CompanyIndexModel
    {
        public IEnumerable<CompanyModel> CompaniesModel { get; set; }
        public int Total { get; set; }
    }
}