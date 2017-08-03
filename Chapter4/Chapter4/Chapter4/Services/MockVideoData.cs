using System;
using System.Collections.Generic;
using Chapter4.Entities;
using System.Linq;

namespace Chapter4.Services
{
    public class MockVideoData : IVideoData
    {
        private List<Video> _videos;

        public MockVideoData()
        {
            _videos = new List<Video>
            {
                new Video {Id = 1, Genre = Models.Genres.Comedy, Title="Snakes on a Plane"},
                new Video {Id = 2, Genre = Models.Genres.Action, Title="Sharknado"},
                new Video {Id = 3, Genre = Models.Genres.Romance, Title="Game of Thrones"}
            };
        }
        public IEnumerable<Video> GetAll()
        {
            return _videos;
        }
        public Video Get(int id)
        {
            return _videos.FirstOrDefault(v => v.Id.Equals(id));
        }
        public void Add(Video newVideo)
        {
            // figure out the next ID #
            newVideo.Id = _videos.Max(v => v.Id) + 1;
            _videos.Add(newVideo);
        }

        public int Commit()
        {
            return 0;
        }
    }
}
