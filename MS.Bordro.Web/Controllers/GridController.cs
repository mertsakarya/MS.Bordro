using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using MS.Bordro.Interfaces.Services;
using MS.Bordro.Web.Helpers;
using MS.Bordro.Web.ViewModels;
using Telerik.Web.Mvc;

namespace MS.Bordro.Web.Controllers
{
    public abstract class GridDetailController<T, TModel> : GridController<T, TModel>
        where T : MS.Bordro.Domain.Entities.BaseEntities.BaseModel
        where TModel : MS.Bordro.Web.Models.BaseEntities.BaseModel, new()
    {
        private readonly IDetailGridService<T> _service;

        protected GridDetailController(IResourceService resourceService, IUserService userService, IDetailGridService<T> service) : base(resourceService, userService, service) {
            _service = service;
        }

        [GridAction(EnableCustomBinding = true)]
        public ActionResult IndexByKeyAjax(long id)
        {
            int gridPage;
            int.TryParse(Request["Page"], out gridPage);
            if (gridPage == 0) {
                int.TryParse(Request["Grid-Page"], out gridPage);
                if (gridPage == 0) {
                    gridPage = 1;
                }
            }

            int size;
            int.TryParse(Request["Size"], out size);
            if (size == 0)
                size = PageSize;

            string orderBy = "Name";
            if (!string.IsNullOrEmpty(Request["orderby"]))
                orderBy = Request["orderby"];
            else if (!string.IsNullOrEmpty(Request["Grid-orderby"]))
                orderBy = Request["Grid-orderby"];

            //ViewData["FilterValue"] = filterValue;

            int total;
            var items = _service.GetAllByKey(id, out total, gridPage, size, p => p.Id, true);
            var itemsModel = Mapper.Map<IList<TModel>>(items);
            return View(new GridModel(itemsModel) { Total = total });
        }
    }   
    
    public abstract class GridController<T, TModel> : BordroController
        where T : MS.Bordro.Domain.Entities.BaseEntities.BaseModel
        where TModel : MS.Bordro.Web.Models.BaseEntities.BaseModel, new()
    {
        private readonly IGridService<T> _service;
        protected const int PageSize = DependencyHelper.GlobalPageSize;

        public GridController(IResourceService resourceService, IUserService userService, IGridService<T> service)
            : base(resourceService, userService)
        {
            _service = service;
        }

        [GridAction(EnableCustomBinding = true)]
        public ActionResult Index()
        {
            int total;
            var items = _service.GetAll(out total, 1, PageSize);
            var itemsModel = Mapper.Map<IList<TModel>>(items);
            var itemsIndexModel = new PagedList<TModel> { Items = itemsModel, TotalRecords = total, Page = 1, PageSize = PageSize };
            return View(itemsIndexModel);
        }

        [GridAction(EnableCustomBinding = true)]
        public ActionResult IndexAjax()
        {
            int gridPage;
            int.TryParse(Request["Page"], out gridPage);
            if (gridPage == 0) {
                int.TryParse(Request["Grid-Page"], out gridPage);
                if (gridPage == 0) {
                    gridPage = 1;
                }
            }

            int size;
            int.TryParse(Request["Size"], out size);
            if (size == 0)
                size = PageSize;

            string orderBy = "Name";
            if (!string.IsNullOrEmpty(Request["orderby"]))
                orderBy = Request["orderby"];
            else if (!string.IsNullOrEmpty(Request["Grid-orderby"]))
                orderBy = Request["Grid-orderby"];

                //ViewData["FilterValue"] = filterValue;

            int total;
            var items = _service.GetAll(out total, gridPage, size);
            var itemsModel = Mapper.Map<IList<TModel>>(items);
            return View(new GridModel(itemsModel) {Total = total});
        }

        [HttpPost]
        [GridAction(EnableCustomBinding = true)]
        public ActionResult Insert()
        {
            var model = new TModel();

            if (TryUpdateModel(model)) {
                var data = Mapper.Map<T>(model);
                _service.Add(data);
            }
            return IndexAjax();
        }

        [HttpPost]
        [GridAction(EnableCustomBinding = true)]
        public ActionResult Update(long id)
        {
            var data = _service.GetById(id);
            if (data != null) {
                var model = Mapper.Map<TModel>(data);
                if (TryUpdateModel(model)) {
                    data = Mapper.Map<T>(model);
                    _service.Update(data);
                }
            }
            return IndexAjax();
        }

        [HttpPost]
        [GridAction]
        public ActionResult Delete(long id)
        {
            var data = _service.GetById(id);
            if (data != null) {
                _service.Delete(data);
            }
            return IndexAjax();
        }
    }


}
