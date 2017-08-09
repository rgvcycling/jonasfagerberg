﻿using Chapter4.Services;
using Chapter4.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Chapter4.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Chapter4.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IVideoData _videos;
        public HomeController(IVideoData videos)
        {
            _videos = videos;
        }

        [AllowAnonymous]
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
            if (ModelState.IsValid)
            {
                var video = new Video
                {
                    Title = model.Title,
                    Genre = model.Genre
                };

                _videos.Add(video);
                _videos.Commit();

                return RedirectToAction("Details", new { id = video.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var video = _videos.Get(id);
            if (video == null) return RedirectToAction("Index");
            return View(video);
        }
        [HttpPost]
        public IActionResult Edit(int id, VideoEditViewModel model)
        {
            var video = _videos.Get(id);
            if (video == null || !ModelState.IsValid) return View(model);

            video.Title = model.Title;
            video.Genre = model.Genre;
            _videos.Commit();

            return RedirectToAction("Details", new { id = video.Id });
            
        }
    }
}
