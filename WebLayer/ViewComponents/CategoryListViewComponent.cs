﻿using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebLayer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebLayer.ViewComponents
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
