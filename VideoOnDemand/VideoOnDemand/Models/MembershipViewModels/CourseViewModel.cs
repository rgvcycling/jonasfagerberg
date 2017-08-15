using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoOnDemand.Models.DTOModels;

namespace VideoOnDemand.Models.MembershipViewModels
{
    public class CourseViewModel
    {
        public CourseDTO Course { get; set; }
        public InstructorDTO Instructor { get; set; }
        public IEnumerable<ModuleDTO> Modules { get; set; }
    }
}
