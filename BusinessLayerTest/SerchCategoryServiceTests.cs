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
    public class SerchCategoryServiceTests
    {
        #region GetAll
        [Fact]
        public async Task GetAll()
        {
            // Arrange
            var mock = new Mock<IRepository<Category>>();
            mock.Setup(repo => repo.ReadAll())
            .ReturnsAsync(GetTestSessions());
            var searchCategory = new SearchCategoryService(mock.Object);

            // Act
            var result = await searchCategory.GetCategories();

            // Assert
            Assert.Equal(2, result.Count());
        }
        #endregion GetAll
        #region GetById()
        [Fact]
        public async Task GetCategoryById()
        {
            // Arrange
            var mock = new Mock<IRepository<Category>>();
            int testSessionId = 1;
            mock.Setup(repo => repo.Read(testSessionId))
                .ReturnsAsync(GetTestSessions().Where(x=>x.Id==testSessionId).FirstOrDefault);
            var searchCategory = new SearchCategoryService(mock.Object);

            // Act
            var result = await searchCategory.GetCategoryById(testSessionId);

            // Assert
            var viewResult = Assert.IsType<CategoryDomain>(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Category1", result.CategoryName);
            Assert.NotEqual("Категория2", result.DisplayName);
        }
        #endregion GetById
        private IQueryable<Category> GetTestSessions()
        {
            var sessions = new List<Category>();
            sessions.Add(new Category()
            {
                CategoryName="Category1",
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
