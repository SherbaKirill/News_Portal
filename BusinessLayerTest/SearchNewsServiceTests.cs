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
    public class SearchNewsServiceTests
    {
        #region GetAll
        [Fact]
        public async Task GetAll()
        {
            var mock = new Mock<IRepository<News>>();
            mock.Setup(repo => repo.ReadAll())
            .ReturnsAsync(GetTestSessions());
            var mock2 = new Mock<IRepository<Category>>();
            var searchNews = new SearchNewsService(mock.Object,mock2.Object);

            // Act
            var result = await searchNews.GetNews();

            // Assert
            Assert.Equal(3, result.Count());
        }
        #endregion GetAll
        #region GetById()
        [Fact]
        public async Task GetCategoryById()
        {
            // Arrange
            var mock = new Mock<IRepository<News>>();
            int testSessionId = 1;
            mock.Setup(repo => repo.Read(testSessionId))
                .ReturnsAsync(GetTestSessions().Where(x => x.Id == testSessionId).FirstOrDefault);
            var mock2 = new Mock<IRepository<Category>>();
            var searchNews = new SearchNewsService(mock.Object,mock2.Object);

            // Act
            var result = await searchNews.GetNewsById(testSessionId);

            // Assert
            var viewResult = Assert.IsType<NewsDomain>(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Category1", result.Category.CategoryName);
            Assert.Equal("First",result.Name);
        }
        #endregion GetById
        #region GetByCategory()
        [Fact]
        public async Task GetCategoryByCategory()
        {
            // Arrange
            var mock = new Mock<IRepository<News>>();
            string category = "Category1";
            mock.Setup(repo =>repo.ReadAll()).ReturnsAsync(GetTestSessions());
            var mock2 = new Mock<IRepository<Category>>();
            mock2.Setup(repo => repo.ReadAll()).ReturnsAsync(GetCategoryTestSessions());
            var searchNews = new SearchNewsService(mock.Object, mock2.Object);

            // Act
            var result = await searchNews.GetNewsByCategory(category);

            // Assert
            var viewResult = Assert.IsType<List<NewsDomain>>(result);
            Assert.Equal(2, result.Count());
        }
        #endregion GetByCategory
        private IQueryable<News> GetTestSessions()
        {
            var sessions = new List<News>();
            sessions.Add(new News()
            {
                Image="firstImage",
                Name="First",
                Content="Первое",
                Description="Есть",
                Category=new Category() { CategoryName = "Category1", DisplayName = "Категория1" },
                Id = 1               
            });;
            sessions.Add(new News()
            {
                Image = "secondImage",
                Name = "Second",
                Content = "Второй",
                Description = "Есть2",
                Category = new Category() { CategoryName = "Category2", DisplayName = "Категория2" },
                Id = 2
            });
            sessions.Add(new News()
            {
                Image = "ThirdImage",
                Name = "Third",
                Content = "Третий",
                Description = "Есть3",
                Category = new Category() { CategoryName = "Category1", DisplayName = "Категория1" },
                Id = 3
            }); ;
            return sessions.AsQueryable();
        }
        private IQueryable<Category> GetCategoryTestSessions()
        {
            var sessions = new List<Category>();
            sessions.Add(new Category()
            {
                CategoryName = "Category1",
                Id = 1,
                DisplayName = "Категория1"
            });
            sessions.Add(new Category()
            {
                CategoryName = "Category2",
                Id = 2,
                DisplayName = "Категория2"
            });
            return sessions.AsQueryable();
        }
    }
}

