using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using S3Project.Entities;
using S3Project.IRepository;
using S3Project.Mappers;
using S3Project.Models;
using S3Project.Utilities;
using System.Net;
using System.Reflection;

namespace S3Project.Controllers
{
    public class VisitorInfoController : Controller
    {
        private readonly ILogger<VisitorInfoController> _logger;
        IVisitorInfoRepository visitorInfoRepo;
        VisitorInfoMapper mapper;

        public VisitorInfoController(ILogger<VisitorInfoController> logger, IVisitorInfoRepository _visitorInfoRepo)
        {
            this._logger = logger;
            this.visitorInfoRepo = _visitorInfoRepo;
            this.mapper = new VisitorInfoMapper();
        }
        #region Select Visitor Information
               
        public IActionResult Index()
        {
            try
            {
                var result = GetAllData();
                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return View(new { message = ex.Message });
            }
            return View();
        }

        List<VisitorInfoListViewModel> GetAllData()
        {
            List<Visitor_Info> result = visitorInfoRepo.GetAll();
            List<VisitorInfoListViewModel> vmlist = new List<VisitorInfoListViewModel>();
            vmlist = mapper.MapEntityToListViewModel(result);
            return vmlist;
        }

        #endregion
        
        public IActionResult Create()
        {
            return View();
        }

        #region Create or Update Visitor Information
        [HttpPost]
        public IActionResult Create(VisitorInfoViewModel model)
        {
            try
            {
                Visitor_Info visitor_Info = new Visitor_Info();
                int result = 0;
                if (model.id > 0)
                {
                    visitor_Info = visitorInfoRepo.Get(model.id);
                    visitor_Info.id = model.id;
                    visitor_Info = mapper.MapModeltoEntity(model);
                    result = visitorInfoRepo.CreateOrUpdate(visitor_Info);
                }
                else
                {
                    visitor_Info = mapper.MapModeltoEntity(model);
                    visitor_Info = mapper.MapModeltoEntity(model);
                    result = visitorInfoRepo.CreateOrUpdate(visitor_Info);
                }
                if (result == 1)
                {
                    return Json(new { message = Constants.SAVE_SUCCESS_MESSAGE });
                }
                else
                {
                    return Json(new { message = Constants.Unsuccess_MESSAGE });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
        }
        #endregion

        #region Get Visitor Information by Id
        
        public ActionResult Edit(int id)
        {
            try
            {
                if (id > 0)
                {
                    Visitor_Info visitorinfo=visitorInfoRepo.Get(id);
                    ViewBag.VisitorInfoID = id;
                    return View("Create", visitorinfo);
                }
                return RedirectToAction("Create", "VisitorInfo", new { isModel = false });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
            
        }

        #endregion

        #region Delete Visitor Information

        //[HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Visitor_Info visitor_Info = new Visitor_Info();
            var result = visitorInfoRepo.Delete(id);
            return View("Index", visitor_Info);
        }

        #endregion
    }
}
