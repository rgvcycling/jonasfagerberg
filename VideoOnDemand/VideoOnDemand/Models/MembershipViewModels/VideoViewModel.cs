﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoOnDemand.Models.DTOModels;

namespace VideoOnDemand.Models.MembershipViewModels
{
    public class VideoViewModel
    {
        public VideoDTO Video { get; set; }
        public InstructorDTO Instructor { get; set; }
        public CourseDTO Course { get; set; }
        public LessonInfoDTO LessinInfo { get; set; }
    }
}
