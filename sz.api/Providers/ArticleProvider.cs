using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sz.api.ExceptionHandlers;
using sz.api.Models;
using sz.dataprovider.DataModel;
using sz.dataprovider.Tables;

namespace sz.api.Providers
{
    public interface IArticleProvider
    {
        Task<IEnumerable<Article>> GetAllAsync();
        Task<Article> GetOne(long id);
        Task<IEnumerable<Article>> GetByStoreId(long id);
        Task<Article> Insert(Article value);
        Task<Article> Update(long id, Article value);
        Task Delete(long id);
    }

    public class ArticleProvider : IArticleProvider
    {
        private IArticleTable _articleData;

        public ArticleProvider (IArticleTable articleData)
        {
            _articleData = articleData;
        }

        public async Task Delete(long id)
        {
            await _articleData.Delete(id);
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            var articles = await _articleData.GetAllAsync();
            var result = articles.Select(s => new sz.api.Models.Article
            {
                Id = s.Id,
                Description = s.Description,
                Name = s.Name,
                Price = s.Price,
                Store = new sz.api.Models.Store
                {
                    Address = s.Store.Address,
                    Name = s.Store.Name,
                    Id = s.Store.Id
                },
                StoreId = s.StoreId,
                StoreName = s.Store.Name,
                TotalInShelf = s.TotalInShelf,
                TotalInVault = s.TotalInVault
            }).ToList();
            return result;
        }

        public async Task<IEnumerable<Article>> GetByStoreId(long id)
        {
            var articles = await _articleData.GetByStoreId(id);
            if (articles.Count() == 0)
                throw new RecordNotFoundException();
            var result = articles.Select(s => new sz.api.Models.Article
            {
                Id = s.Id,
                Description = s.Description,
                Name = s.Name,
                Price = s.Price,
                StoreId = s.StoreId,
                TotalInShelf = s.TotalInShelf,
                TotalInVault = s.TotalInVault
            }).ToList();
            return result;
        }

        public async Task<Article> GetOne(long id)
        {
            var article = await _articleData.GetOne(id);
            var result = new sz.api.Models.Article
            {
                Id = article.Id,
                Description = article.Description,
                Name = article.Name,
                Price = article.Price,
                StoreId = article.StoreId,
                TotalInShelf = article.TotalInShelf,
                TotalInVault = article.TotalInVault
            };
            return result;
        }

        public async Task<Article> Insert(Article value)
        {
            var result = await _articleData.Insert(new commons.models.Article
            {
                Id = value.Id,
                Description = value.Description,
                Name = value.Name,
                Price = value.Price,
                StoreId = value.StoreId,
                TotalInShelf = value.TotalInShelf,
                TotalInVault = value.TotalInVault
            });
            value.Id = result.Id;
            return value;
        }

        public async Task<Article> Update(long id, Article value)
        {
            var result = await _articleData.Update(id, new commons.models.Article
            {
                Description = value.Description,
                Name = value.Name,
                Price = value.Price,
                StoreId = value.StoreId,
                TotalInShelf = value.TotalInShelf,
                TotalInVault = value.TotalInVault
            });
            value.Id = result.Id;
            return value;
        }
    }
}
