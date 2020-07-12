using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Service;
using DataLayer;
using DataLayer.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BusinessLayer.Test
{
    public class ManageNewsServiceTests
    {
        #region Create
        [Fact]
        public async Task Create()
        {
            var mock = new Mock<IRepository<News>>();
            News news = new News() {
                Image = "firstImage",
                Name = "First",
                Content = "Первое",
                Description = "Есть",
                Category = new Category() { CategoryName = "Category1", DisplayName = "Категория1" }
            };
            CategoryDomain categoryDomain = new CategoryDomain() { CategoryName = "Category1", DisplayName = "Категория1" };
            NewsDomain news1 = new NewsDomain() {
                Image = "firstImage",
                Name = "First",
                Content = "Первое",
                Description = "Есть",
                Category = categoryDomain
            };
            var mock1 = new Mock<ISearchCategoryService>();         
            var mock2 = new Mock<IManageCategoryService>();
            mock2.Setup(x => x.Create(It.IsAny<CategoryDomain>()))
                .ReturnsAsync(categoryDomain);
            mock.Setup(x => x.Create(It.IsAny<News>()))
                .ReturnsAsync(news);

            ManageNewsService manageCategory = new ManageNewsService(mock.Object,mock1.Object,mock2.Object);

            var result = await manageCategory.Create(news1);

            Assert.NotNull(result);
            Assert.Equal(result.Name, news.Name);
        }
        #endregion Create
        #region Update
        [Fact]
        public async Task Update()
        {
            var mock = new Mock<IRepository<News>>();
            News news = new News()
            {
                Image = "firstImage",
                Name = "First",
                Content = "Первое",
                Description = "Есть",
                Category = new Category() { CategoryName = "Category1", DisplayName = "Категория1" }
            };
            CategoryDomain categoryDomain = new CategoryDomain() { CategoryName = "Category1", DisplayName = "Категория1" };
            NewsDomain news1 = new NewsDomain()
            {
                Image = "firstImage",
                Name = "First",
                Content = "Первое",
                Description = "Есть",
                Category = categoryDomain
            };
            var mock1 = new Mock<ISearchCategoryService>();
            var mock2 = new Mock<IManageCategoryService>();
            mock.Setup(x => x.Update(It.IsAny<News>()))
                .ReturnsAsync(news);

            ManageNewsService manageCategory = new ManageNewsService(mock.Object, mock1.Object, mock2.Object);

            var result = await manageCategory.Update(news1);

            Assert.NotNull(result);
            Assert.Equal(result.Name, news.Name);
        }
        #endregion Update
    }
}
