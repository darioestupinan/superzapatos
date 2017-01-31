using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sz.dataprovider.DataModel
{
    public static class TestDataClass
    {
        public static void AddTestData(DataContext context)
        {
            var testStore = new sz.commons.models.Store
            {
                Id = 1,
                Address = "5th Avenue, New York",
                Name = "Christies"
            };

            var testStore1 = new sz.commons.models.Store
            {
                Id = 2,
                Address = "5th Avenue, New York",
                Name = "Apple Store"
            };

            context.StoreTable.Add(testStore);
            context.StoreTable.Add(testStore1);

            var testArticle = new sz.commons.models.Article
            {
                Id = 1,
                Name = "Box",
                Description = "Schrodinger Box",
                Price = 150.15M,
                StoreId = 1,
                TotalInShelf = 100,
                TotalInVault = 500
            };

            var testArticle2 = new sz.commons.models.Article
            {
                Id = 2,
                Name = "Toy",
                Description = "Cat",
                Price = 40.15M,
                StoreId = 1,
                TotalInShelf = 100,
                TotalInVault = 500
            };

            var testArticle3 = new sz.commons.models.Article
            {
                Id = 3,
                Name = "Dog",
                Description = "Dog Puff",
                Price = 140.15M,
                StoreId = 2,
                TotalInShelf = 100,
                TotalInVault = 500
            };

            context.ArticleTable.Add(testArticle);
            context.ArticleTable.Add(testArticle2);
            context.ArticleTable.Add(testArticle3);

            context.SaveChanges();
        }
    }
}
