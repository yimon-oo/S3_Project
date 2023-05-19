using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using S3Project.Entities;
using S3Project.IRepository;
using S3Project.Logging;
using S3Project.Mappers;
using S3Project.Models;
using S3Project.Utilities;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace S3Project.Controllers
{
    public class VisitorInfoController : Controller
    {
        Logger logger;
        IVisitorInfoRepository visitorInfoRepo;
        VisitorInfoMapper mapper;

        public VisitorInfoController(IVisitorInfoRepository _visitorInfoRepo)
        {
            this.logger = new Logger(typeof(VisitorInfoController));
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
                logger.LogError(ex.Message, ex);
                return View(new { message = ex.Message });
            }
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
                    visitor_Info = mapper.MapModeltoEntity(model);
                    visitor_Info.id = model.id;
                    result = visitorInfoRepo.CreateOrUpdate(visitor_Info);
                }
                else
                {
                    visitor_Info = mapper.MapModeltoEntity(model);
                    result = visitorInfoRepo.CreateOrUpdate(visitor_Info);
                }
                if (result == 1)
                {
                    //return Json(new { message = Constants.SAVE_SUCCESS_MESSAGE });
                    List<VisitorInfoListViewModel> list = new List<VisitorInfoListViewModel>();
                    list = GetAllData();
                    return View("Index", list);
                }
                else
                {
                    //return Json(new { message = Constants.Unsuccess_MESSAGE });
                    return View("Create");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
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
                    VisitorInfoViewModel model = mapper.MapEntityToModel(visitorinfo);
                    return View("Create", model);
                }
                return RedirectToAction("Create", "VisitorInfo", new { isModel = false });
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
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
            List<VisitorInfoListViewModel> list= new List<VisitorInfoListViewModel>();
            list = GetAllData();
            return View("Index", list);
        }

        #endregion
    }
}
