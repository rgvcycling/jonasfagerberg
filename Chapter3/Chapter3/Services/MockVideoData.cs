using System;
using System.Collections.Generic;
using Chapter3.Models;

namespace Chapter3.Services
{
    public class MockVideoData : IVideoData
    {
        private List<Video> _videos;

        public MockVideoData()
        {
            _videos = new List<Video>
            {
                new Video {Id = 1, Title="Snakes on a Plane"},
                new Video {Id = 2, Title="Sharknado"},
                new Video {Id = 3, Title="Game of Thrones"}
            };
        }
        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }
    }
}
