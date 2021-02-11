using DataLayer;
using DataLayer.Models;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{
    public class SearchNewsService: ISearchNewsService
    {
        private readonly IRepository<News> _allNews;
        private readonly IRepository<Category> _newsCategory;

        public SearchNewsService(IRepository<News> allNews, IRepository<Category> newsCategory)
        {
            _allNews = allNews;
            _newsCategory = newsCategory;
        }

        public async Task<IEnumerable<NewsDomain>> GetNews()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDomain>()
                .ForPath(c => c.Category.CategoryName, x => x.MapFrom(d => d.Category.CategoryName))
                .ForPath(c => c.Category.DisplayName, x => x.MapFrom(d => d.Category.DisplayName))
            ).CreateMapper();

            return mapper.Map<IQueryable<News>, List<NewsDomain>>(await _allNews.ReadAll()).OrderByDescending(i=>i.Id);
        }

        public async Task<IEnumerable<NewsDomain>> GetNewsByCategory(string category)
        {
            var _category = category;
            IQueryable<News> news = null;
            if ((await _newsCategory.ReadAll()).Any(x => x.CategoryName == _category))
                news =(await _allNews.ReadAll()).Where(i => i.Category.CategoryName == _category).OrderByDescending(i => i.Id);

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<News, NewsDomain>()
                .ForPath(c => c.Category.CategoryName, x => x.MapFrom(d => d.Category.CategoryName))
                .ForPath(c => c.Category.DisplayName, x => x.MapFrom(d => d.Category.DisplayName))
            ).CreateMapper();

            return mapper.Map<IQueryable<News>, List<NewsDomain>>(news);
        }

        public async Task<NewsDomain> GetNewsById(int? id)
        {
            if (id == null)
                throw new Exception("id отсутствует");

            var news =await _allNews.Read(id.Value);
            if (news == null)
                throw new Exception("id не обнаружен");

            var newsDomain = new NewsDomain().ToNewsDomain(news);
            return newsDomain;
        }
    }
}
