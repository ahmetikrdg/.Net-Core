using Sabor.Data.Abstract;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sabor.Data.Concrate.EfCore
{
    public class VideoRepository : GenericRepository<Video, SaborDbContext>, IVideoRepository
    {
        public List<Video> LastGetAll()
        {
            using(var context=new SaborDbContext())
            {
                return context.Videos.OrderByDescending(i => i.VideoId).ToList();
            }
        }

        public List<Video> LastOneGetAll()
        {
            using (var context = new SaborDbContext())
            {
                return context.Videos.OrderByDescending(i => i.VideoId).Take(1).ToList();
            }
        }
    }
}
