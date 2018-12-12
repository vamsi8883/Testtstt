using Microsoft.AspNetCore.Mvc;
using MvcServerSide.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcServerSide.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<Department> departments;
            var responseTask = GlobalVariables.Client.GetAsync("departments");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<Department>>();
                departments = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                departments = Enumerable.Empty<Department>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(departments);
        }
       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            var postTask = GlobalVariables.Client.PostAsJsonAsync("departments",department);
         
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(department);
        }

        public async Task<ActionResult<Department>> DeleteDetails(int id)
        {
           
            var deleteTask = GlobalVariables.Client.DeleteAsync("departments/" + id.ToString());
            deleteTask.Wait();
            var result =await deleteTask.Result.Content.ReadAsAsync<Department>();
            return View(result);

        }

        public ActionResult UpdateDetails(int id)
        {
            Department departments = null;
            var updateTask = GlobalVariables.Client.GetAsync("departments/"+id.ToString());
            updateTask.Wait();
            var result = updateTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Department>();
                readTask.Wait();
                departments = readTask.Result;
            }

            return View(departments);
        }
        [HttpPost]
        public ActionResult UpdateDetails(Department department)
        {
            var updateTask = GlobalVariables.Client.PutAsJsonAsync("departments",department);
            updateTask.Wait();
            var result = updateTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
    }
}
