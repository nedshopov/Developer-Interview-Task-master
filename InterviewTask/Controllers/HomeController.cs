using Contracts.Commands;
using Contracts.Models;
using Contracts.Services;
using JuniorInterviewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace JuniorInterviewTask.Controllers
{
   public class HomeController : Controller
   {
      /*
       * Prepare your opening times here using the provided HelperServiceRepository class.       
       */
      public ActionResult Index()
      {
         var request = new HelperServicesQuery();
         request.Handle();
         RequestResultModel resultModel = GetResultModel(request);
         return View(resultModel);
      }

      /// <summary>
      /// Get result model for the view.
      /// </summary>
      /// <param name="request">Data request.</param>
      /// <returns>The result model to use on the view.</returns>
      private RequestResultModel GetResultModel(HelperServicesQuery request)
      {
         var resultModel = new RequestResultModel();
         IList<HelperServiceModel> results = new List<HelperServiceModel>();
         foreach(HelperServiceDto item in request.Results)
         {
            if(item.MondayOpeningHours == null)
            {
               resultModel.RequestFail = true;
               break;
            }
            results.Add(MapToModel(item));
         }
         resultModel.Results = results;
         return resultModel;
      }

      /// <summary>
      /// Map a data transfer object to a model.
      /// </summary>
      /// <param name="item">Data transfer object item to map from.</param>
      /// <returns>A helper service model with mapped values.</returns>
      private HelperServiceModel MapToModel(HelperServiceDto item)
      {
         var resultModel = new HelperServiceModel();
         SimpleMapper.Map(item, resultModel);

         if(AllEqual(resultModel.MondayOpeningHours, resultModel.TuesdayOpeningHours, resultModel.WednesdayOpeningHours, resultModel.ThursdayOpeningHours, resultModel.FridayOpeningHours))
         {
            resultModel.WorkingDays = WorkingDays.EveryWorkDay;
            if(resultModel.MondayOpeningHours == resultModel.SaturdayOpeningHours)
            {
               resultModel.WorkingDays = WorkingDays.EverydayButSunday;
               if(resultModel.SaturdayOpeningHours == resultModel.SundayOpeningHours)
               {
                  resultModel.WorkingDays = WorkingDays.EveryDay;
               }
            }
         }
         return resultModel;
      }
      
      private bool AllEqual<T>(params T[] values)
      {
         if(values == null || values.Length == 0)
            return true;
         return values.All(v => v.Equals(values[0]));
      }
   }
}