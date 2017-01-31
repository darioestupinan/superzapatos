using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sz.commons.models;
using sz.dataprovider.DataModel;

namespace sz.dataprovider.Tables
{
    public interface IStoreTable
    {
        Task<Store> GetOne(long id);
        Task<Store> Insert(Store value);
        Task<IEnumerable<Store>> GetAll();
        Task Delete(long id);
        Task<Store> Update(long id, Store value);
    }

    public class StoreTable : IStoreTable
    {
        private readonly DataContext _context;
        public StoreTable(DataContext context)
        {
            _context = context;
        }

        public async Task Delete(long id)
        {
            var store = _context.StoreTable.Find(id);
            if (store != null)
                await Task.Run(() => _context.StoreTable.Remove(store));
        }

        public async Task<IEnumerable<Store>> GetAll()
        {
            return await _context.StoreTable.ToArrayAsync();
        }

        public async Task<Store> GetOne(long id)
        {
            return await _context.StoreTable.FindAsync(id);
        }

        public async Task<Store> Insert(Store value)
        {
            await _context.StoreTable.AddAsync(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<Store> Update(long id, Store value)
        {
            value.Id = id;
            await Task.Run(()=>_context.StoreTable.Attach(value));
            await _context.SaveChangesAsync();
            return value;
        }
    }
}
