using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.ViewComponents
{
    public class CategoryListViewComponent:ViewComponent
    {
        private readonly ISearchCategoryService _searchCategory;
        public CategoryListViewComponent(ISearchCategoryService searchCategoryService)
        {
            _searchCategory = searchCategoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDomain, CategoryViewModel>()).CreateMapper();
            return View(mapper.Map<IEnumerable<CategoryDomain>, List<CategoryViewModel>>(await Task.Run(() => _searchCategory.GetCategories())));
        }
    }
}
