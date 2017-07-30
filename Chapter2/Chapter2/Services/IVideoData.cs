using System;
using System.Collections.Generic;
using Chapter2.Models;

namespace Chapter2.Services
{
    public interface IVideoData
    {
        IEnumerable<Video> GetAll();

    }
}
