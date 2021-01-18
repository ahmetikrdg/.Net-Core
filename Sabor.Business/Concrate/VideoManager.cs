using Sabor.Business.Abstract;
using Sabor.Data.Abstract;
using Sabor.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Business.Concrate
{
    public class VideoManager : IVideoServices
    {
        private IVideoRepository _videoRepository;
        public VideoManager(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public void Create(Video Entity)
        {
            _videoRepository.Create(Entity);
        }

        public void Delete(Video Entity)
        {
            _videoRepository.Delete(Entity);
        }

        public List<Video> GetAll()
        {
            return _videoRepository.GetAll();
        }

        public Video GetById(int id)
        {
            return _videoRepository.GetById(id);
        }

        public List<Video> LastGetAll()
        {
            return _videoRepository.LastGetAll();
        }

        public List<Video> LastOneGetAll()
        {
            return _videoRepository.LastOneGetAll();
        }

        public void Update(Video Entity)
        {
            _videoRepository.Update(Entity);
        }
    }
}
