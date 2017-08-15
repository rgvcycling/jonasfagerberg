using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoOnDemand.Entities;

namespace VideoOnDemand.Repositories
{
    public interface IReadRepository
    {
        IEnumerable<Course> GetCourses(string userId);
        Video GetVideo(string UserId, int videoId);
    }


}
