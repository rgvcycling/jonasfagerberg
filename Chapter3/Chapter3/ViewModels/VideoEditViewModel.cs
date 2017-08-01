using Chapter3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter3.ViewModels
{
    public class VideoEditViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public Genres Genre { get; set; }
    }
}
