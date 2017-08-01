using Microsoft.AspNetCore.Mvc;
using Chapter3.Services;
using System.Linq;
using Chapter3.Entities;
using Chapter3.ViewModels;
using System;
using Chapter3.Models;

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

    }
}
