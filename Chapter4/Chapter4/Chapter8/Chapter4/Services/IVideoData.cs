using System;
using System.Collections.Generic;
using Chapter4.Entities;

namespace Chapter4.Services
{
    
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();
        Video Get(int id);
        void Add(Video newVideo);
        int Commit();
    }
}
