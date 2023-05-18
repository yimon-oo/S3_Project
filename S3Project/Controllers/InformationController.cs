using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S3Project.Entities;
using S3Project.IRepository;
using S3Project.Models;
using S3Project.Utilities;
using System.Globalization;

namespace S3Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : Controller
    {
        private readonly ILogger<InformationController> _logger;
        IDataRepository dataRepo;
        public InformationController(ILogger<InformationController> logger, IDataRepository _dataRepo)
        {
            _logger = logger;
            this.dataRepo = _dataRepo;
        }

        #region Receive the payload and store main information (temperature, humidity, occupancy)

        [HttpPost]
        public IActionResult SaveOrUpdate(InformationViewModel model)
        {
            try
            {
                var result = 0;
                if (model.data!=null)
                {
                    Data data=new Data();
                    data.temperature = model.data.temperature;
                    data.humidity = model.data.humidity;
                    data.occupancy = model.data.occupancy;
                    result = dataRepo.Create(data);
                }

                /*  For Informatioon    */
                //Information info = new Information();                
                //info.deviceId = model.deviceId;
                //info.deviceType = model.deviceType;
                //info.deviceName = model.deviceName;
                //info.groupId = model.groupId;
                //info.dataType = model.dataType;
                ////info.data_id = model.da;
                //System.DateTime dat_Time = new System.DateTime(1965, 1, 1, 0, 0, 0, 0);
                //dat_Time = dat_Time.AddSeconds(model.timestamp);
                //string print_the_Date = dat_Time.ToShortDateString() + " " + dat_Time.ToShortTimeString();
                //info.timestamp = DateTime.ParseExact(print_the_Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                
                if (result == 1)
                {
                    return Json(new { message = Constants.SAVE_SUCCESS_MESSAGE });
                }
                else
                {
                    return Json(new { message = Constants.Unsuccess_MESSAGE });
                }
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Json(new { message = ex.Message });
            }
        }

        #endregion
    }
}
