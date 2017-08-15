﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoOnDemand.Models.DTOModels
{
    public class VideoDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Thumbnail { get; set; }
        public string Url { get; set; }
    }
}
