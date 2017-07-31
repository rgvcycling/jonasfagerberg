using System;
using System.Collections.Generic;
using Chapter3.Models;

namespace Chapter3.Services
{
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();

    }
}
