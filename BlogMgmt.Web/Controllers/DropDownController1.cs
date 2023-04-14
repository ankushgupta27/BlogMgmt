// using System;  
// using System.Collections.Generic;  
// using System.Linq;  
// using System.Web;  

// using BlogMgmt.Data.Entities;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Rendering;
// using MvcDemoApplication.Models;  
  
// namespace MvcDemoApplication.Controllers  
// {  
//     public class DropDownController1 : Controller  
//     {  
//         //  
//         // GET: /DropDownList/  
//         BlogDBContext SelectState = new BlogDBContext();

//         public IList<SelectListItem> StateNames { get; private set; }

//         // public ActionResult Index()  
//         // {  
//         //     List<SelectListItem> stateNames = new List<SelectListItem>();  
//         //     StateModel stuModel=new StateModel();  
              
//         //     List<State> states = SelectState.States.ToList();  
//         //     states.ForEach(x =>  
//         //         {  
//         //   StateNames.Add(new SelectListItem { Text = x.Name , Value = x.StateId.ToString() });  
//         //         });  
//         //     stuModel.StateNames = StateNames;  
//         //     return View(stuModel);  
//         // }  
//         public ActionResult Index()  
//         {  
//             List<SelectListItem> stateNames = new List<SelectListItem>();  
//             StateModel stuModel=new StateModel();  
              
//             List<State> states = SelectState.States.ToList();  
//             states.ForEach(x =>  
//                 {  
//                     stateNames.Add(new SelectListItem { Text = x.Name , Value = x.Id.ToString() });  
//                 });  
//             stuModel.StateNames = stateNames;  
//             return View(stuModel);  
//         }  
//     //     BlogDBContext SelectStates = new  BlogDBContext();  
  
//     //  List<State> states = SelectStates.State.ToList();
//      [HttpPost]  
//         public ActionResult GetCity(string stateId)  
//         {  
//             int statId;  
//             List<SelectListItem> CityNames = new List<SelectListItem>();  
//             if (!string.IsNullOrEmpty(stateId))  
//             {  
//                 statId = Convert.ToInt32(stateId);  
// List<City> districts = SelectState.Cities.Where(x => x.StateId == statId).ToList();  
//                 districts.ForEach(x =>  
//                 {  
// CityNames.Add(new SelectListItem { Text = x.Name, Value = x.Id.ToString() });  
//                 });  
//             }  
//             return Json(CityNames, JsonRequestBehavior.AllowGet);  
//         }

//         private ActionResult Json(List<SelectListItem> cityNames, object allowGet)
//         {
//             throw new NotImplementedException();
//         }
//     }  
          
// }  