using BusinessLayer.Models;
using BusinessLayer.Service;
using DataLayer;
using DataLayer.Models;
using DataLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BusinessLayer.Test
{
    public class ManageCategoryServiceTests
    {
        #region Create
        [Fact]
        public async Task Create()
        {
            var mock = new Mock<IRepository<Category>>();
            Category category = new Category() { DisplayName = "Test", CategoryName = "Test" };
            CategoryDomain category1 = new CategoryDomain() { DisplayName = "Test", CategoryName = "Test" };
            mock.Setup(x =>  x.Create(It.IsAny<Category>()))
                .ReturnsAsync(category);
            ManageCategoryService manageCategory = new ManageCategoryService(mock.Object);

            var result =await manageCategory.Create(category1);

            Assert.NotNull(result);
            Assert.Equal(category.CategoryName, result.CategoryName);
        }
        #endregion Create
        #region Update
        [Fact]
        public async Task Update()
        {
            var mock = new Mock<IRepository<Category>>();
            Category category = new Category() { DisplayName = "Test", CategoryName = "Test" };
            CategoryDomain category1 = new CategoryDomain() { DisplayName = "Test", CategoryName = "Test" };
            mock.Setup(x => x.Update(It.IsAny<Category>()))
                .ReturnsAsync(category);
            ManageCategoryService manageCategory = new ManageCategoryService(mock.Object);

            var result = await manageCategory.Update(category1);

            Assert.NotNull(result);
            Assert.Equal(category.CategoryName, result.CategoryName);
        }
        #endregion Update

    }
}

