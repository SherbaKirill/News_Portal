using DataLayer;
using DataLayer.Models;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer.Models;
using AutoMapper;

namespace BusinessLayer
{
    public class Reader: IReader
    {
        private readonly IRepository<News> _allNews;
        private readonly IRepository<Category> _newsCategory;
        public Reader(IRepository<News> allNews, IRepository<Category> newsCategory)
        {
            _allNews = allNews;
            _newsCategory = newsCategory;
        }

        public IEnumerable<NewsDTO> GetNews()
        {
            var mapper= new MapperConfiguration(cfg => cfg.CreateMap<News,NewsDTO>()
            .ForPath(c=>c.Category.CategoryName,x=>x.MapFrom(d=>d.Category.CategoryName))
            .ForPath(c => c.Category.DisplayName, x => x.MapFrom(d => d.Category.DisplayName))
            ).CreateMapper();
            return mapper.Map<IQueryable<News>, List<NewsDTO>>(_allNews.ReadAll().Result);
        }

        public IEnumerable<NewsDTO> GetNewsOfCategory(string category)
        {
            string _category = category;
            IQueryable<News> news = null;
            if (_newsCategory.ReadAll().Result.Any(x => x.CategoryName == _category))
            {
                news = _allNews.ReadAll().Result.Where(i => i.Category.CategoryName == _category).OrderByDescending(i => i.Id);
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDTO>()
            .ForPath(c => c.Category.CategoryName, x => x.MapFrom(d => d.Category.CategoryName))
            .ForPath(c => c.Category.DisplayName, x => x.MapFrom(d => d.Category.DisplayName))
            ).CreateMapper();
            return mapper.Map<IQueryable<News>, List<NewsDTO>>(news);
        }
        public NewsDTO NewsId(int? Id)
        {
            if (Id == null)
                throw new Exception("id отсутствует");
            var news = _allNews.Read(Id.Value).Result;
            if (news == null)
                throw new Exception("id не обнаружен");
            NewsDTO newsDTO = new NewsDTO().ToNewsDTO(news);
            return (newsDTO);
        }
    }
}
