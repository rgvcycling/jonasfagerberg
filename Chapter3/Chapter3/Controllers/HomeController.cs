using Chapter3.Services;
using Chapter3.ViewModels;
using Chapter3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace Chapter3.Controllers
{

    public class HomeController : Controller
    {
        private IVideoData _videos;
        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }

        public ViewResult Index()
        {
            var model = _videos.GetAll().Select(video =>
                                               new VideoViewModel
                                               {
                                                    Id = video.Id,
                                                    Title = video.Title,
                Genre = Enum.GetName(typeof(Genres), video.GenreId)
                                                });

            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _videos.Get(id);

            // if Genre Id passed doesn't exist, redirect to the default index file
            if (model == null)
                return RedirectToAction("Index");

            return View(new VideoViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Genre = Enum.GetName(typeof(Genres), model.GenreId)

            });
        }

    }
}
