using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using Microsoft.AspNetCore.Http;

namespace DHDWeb.Controllers
{
    public class SoftController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Models.SoftwareModel> models = DataAdapter.MongoDBHelper<Models.SoftwareModel>.GetAll();
            return View(models);
        }

        public IActionResult Detial(String id)
        {
            Models.SoftwareModel model = DataAdapter.MongoDBHelper<Models.SoftwareModel>.GetByID(id);
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCommit()
        {
            // 获取表单数据
            var soft_name = Request.Form["soft_name"];

            return View();
        }
    }
}
