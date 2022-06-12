using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using News.Models.Services;

namespace News.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _service;

        public NewsController(INewsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: News/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Categories,DatePosted,Description,Name,Content,PicUrl")] Models.News news)
        {
            if (!ModelState.IsValid)
            {
                return View(news);
            }
            await _service.AddAsync(news);
            return RedirectToAction(nameof(Index));
        }

        //Get: News/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var newsDetails = await _service.GetByIdAsync(id);

            if (newsDetails == null) return View("NotFound");
            return View(newsDetails);
        }

        //Get: News/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var newsDetails = await _service.GetByIdAsync(id);
            if (newsDetails == null) return View("NotFound");
            return View(newsDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Categories,DatePosted,Description,Name,Content,PicUrl")] Models.News news)
        {
            if (!ModelState.IsValid)
            {
                return View(news);
            }
            await _service.UpdateAsync(id, news);
            return RedirectToAction(nameof(Index));
        }

        //Get:  /Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var newsDetails = await _service.GetByIdAsync(id);
            if (newsDetails == null) return View("NotFound");
            return View(newsDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsDetails = await _service.GetByIdAsync(id);
            if (newsDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        
    }
}
