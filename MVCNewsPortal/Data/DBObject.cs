using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using MVCNewsPortal.Data;
using MVCNewsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCNewsPortal
{
    public class DBObject
    {
        public static void Initial(DBContext context)
        {

            if (!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!context.News.Any())
            {
                context.News.AddRange(NewsContents.Select(c => c.Value));
            }
            context.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        private static Dictionary<string, News> news;
        public static Dictionary<string, News> NewsContents
        {
            get
            {
                if (news == null)
                {
                    var List = new News[]
                    {
                        new News
                        {
                            Name = "Результат матча",
                            Description = "Матч Испания-Италия",
                            Category = category["Sport"],
                            Content = "Испания разгромила италию",
                            Img = "/img/Spain.jpg"
                        },
                        new News
                        {
                            Name = "Владимиру Кореневу исполнилось 80 лет",
                            Description ="Сегодня, 20 июня, исполнилось 80 лет заслуженному артисту РСФСР, " +
                            "народному артисту России, мужу Алефтины Константиновой...",
                            Category = category["Cinema"],
                            Content = "Сегодня, 20 июня, исполнилось 80 лет заслуженному артисту РСФСР, " +
                            "народному артисту России, мужу Алефтины Константиновой, отцу Ирины Кореневой, профессору, педагогу, художественному руководителю " +
                            "театрального факультета Института гуманитарного образования (ИГУМО), театральному режиссёру, популярному" +
                            " советскому и российскому актёру театра и кино Владимиру Кореневу, которого зрители любят и помнят по роли Ихтиандра в «Человеке-амфибии».",
                            Img = "/img/VlCorenev.jpg"
                        }
                    };
                    news = new Dictionary<string, News>();
                    foreach (News item in List)
                        news.Add(item.Name, item);

                }
                return news;
            }
        }
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var List = new Category[]
                    {
                        new Category{ CategoryName="Sport",DisplayName="Новости Спорта"},
                         new Category{ CategoryName="Cinema",DisplayName="Новости Киноиндустрии"}
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category item in List)
                        category.Add(item.CategoryName, item);
                }
                return category;
            }
        }
    }
}
