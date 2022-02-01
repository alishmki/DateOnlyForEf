using Microsoft.AspNetCore.Mvc;

namespace DateOnlyForEf.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("add")]
        public IActionResult Post()
        {
            BloggingContext context = new BloggingContext();
            var date = new DateOnly(2020, 01, 20);
            var time = new TimeOnly(08, 30);        
            context.Blogs.Add(new Blog { RegDate = date,Time = time});
            context.SaveChanges();
            return Ok("ok!");
        }


        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            BloggingContext context = new BloggingContext();
       
            //var date = DateOnly.FromDateTime(DateTime.Now);
            //var listByDateFilter = context.Blogs.Where(x=>x.RegDate==date).ToList();

            //var time = TimeOnly.FromDateTime(DateTime.Now);
            //var listByTimeFilter = context.Blogs.Where(x=>x.Time== time).ToList();

            var list3 = context.Blogs.ToList();
            return Json(list3);
        }
    }
}