using Chapter4.Data;
using Chapter4.Entities;
using System.Collections.Generic;

namespace Chapter4.Services
{
    public class SqlVideoData : IVideoData
    {
        private VideoDbContext _db;

        public SqlVideoData(VideoDbContext db)
        {
            _db = db;
        }

        public void Add(Video video)
        {
            _db.Add(video);
          
        }

        public Video Get(int id)
        {
            return _db.Find<Video>(id);
        }

        public IEnumerable<Video> GetAll()
        {
            return _db.Videos;
        }
        public int Commit()
        {
            return _db.SaveChanges();
        }
    }
}
