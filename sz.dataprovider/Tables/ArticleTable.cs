using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sz.commons.models;
using sz.dataprovider.DataModel;

namespace sz.dataprovider.Tables
{
    public interface IArticleTable
    {
        Task Delete(long id);
        Task<IEnumerable<Article>> GetAllAsync();
        Task<IEnumerable<Article>> GetByStoreId(long id);
        Task<Article> GetOne(long id);
        Task<Article> Insert(Article value);
        Task<Article> Update(long id, Article value);
    }

    public class ArticleTable : IArticleTable
    {
        private readonly DataContext _context;
        public ArticleTable(DataContext context)
        {
            _context = context;
        }        

        public async Task Delete(long id)
        {
            var article = _context.ArticleTable.Find(id);
            if (article != null)
                await Task.Run(()=> _context.ArticleTable.Remove(article));
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _context.ArticleTable.Include(u => u.Store).ToArrayAsync();
        }

        public async Task<IEnumerable<Article>> GetByStoreId(long id)
        {
            return await _context.ArticleTable.Where(u => u.StoreId == id).ToArrayAsync();
        }

        public async Task<Article> GetOne(long id)
        {
            return await _context.ArticleTable.FindAsync(id);
        }

        public async Task<Article> Insert(Article value)
        {
            await _context.AddAsync(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Article> Update(long id, Article value)
        {
            value.Id = id;
            await Task.Run(()=> _context.ArticleTable.Attach(value));
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
