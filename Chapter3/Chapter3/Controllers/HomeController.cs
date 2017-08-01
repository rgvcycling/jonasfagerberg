using Chapter3.Services;
using Chapter3.ViewModels;
using Chapter3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Chapter3.Entities;

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
                                                    Genre = video.Genre.ToString()
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
                Genre = model.Genre.ToString()

            });
        }

        // create action
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(VideoEditViewModel model)
        {
            var video = new Video
            {
                Title = model.Title,
                Genre = model.Genre
            };

            _videos.Add(video);

            return RedirectToAction("Details", new { id = video.Id });
        }

    }
}
