using System;
using System.Collections.Generic;
using Chapter3.Entities;

namespace Chapter3.Services
{
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();
        Video Get(int id);
        void Add(Video newVideo);
    }
}
