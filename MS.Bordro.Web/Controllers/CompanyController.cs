using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using MS.Bordro.Domain.Entities;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Web.Models;
using MS.Bordro.Web.ViewModels;
using Telerik.Web.Mvc;

namespace MS.Bordro.Web.Controllers
{
    public class CompanyController : BordroController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(IResourceService resourceService, IUserService userService, ICompanyService companyService) : base(resourceService, userService) {
            _companyService = companyService;
        }

        public ActionResult Index()
        {
            int total;
            var companies = _companyService.GetAll(out total);
            var companiesModel = Mapper.Map<IList<CompanyModel>>(companies);
            var companyIndexModel = new CompanyIndexModel { CompaniesModel = companiesModel, Total = total };
            return View(companyIndexModel);
        }

        [GridAction]
        public ActionResult IndexAjax()
        {
            int total;
            var companies = _companyService.GetAll(out total);
            var companiesModel = Mapper.Map<IList<CompanyModel>>(companies);
            return View(new GridModel(companiesModel));
        }

        [HttpPost]
        [GridAction]
        public ActionResult Insert()
        {
            CompanyModel model = new CompanyModel();

            if (TryUpdateModel(model)) {
                var data = Mapper.Map<Company>(model);
                _companyService.Add(data);
            }
            return IndexAjax();
        }

        [HttpPost]
        [GridAction]
        public ActionResult Update(long id)
        {
            var data = _companyService.GetById(id);
            if (data != null) {
                var model = Mapper.Map<CompanyModel>(data);
                if (TryUpdateModel(model)) {
                    data = Mapper.Map<Company>(model);
                    _companyService.Update(data);
                }
            }
            return IndexAjax();
        }

        [HttpPost]
        [GridAction]
        public ActionResult Delete(long id)
        {
            var data = _companyService.GetById(id);
            if (data != null) {
                _companyService.Delete(data);
            }
            return IndexAjax();
        }

    }
}
