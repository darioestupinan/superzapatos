using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sz.api.Models;
using sz.dataprovider.Tables;

namespace sz.api.Providers
{
    public interface IStoreProvider
    {
        Task<Store> GetOne(long id);
        Task<Store> Insert(Store value);
        Task<IEnumerable<Store>> GetAll();
        Task Delete(long id);
        Task<Store> Update(long id, Store value);
    }

    public class StoreProvider : IStoreProvider
    {
        private IStoreTable _storeData;

        public StoreProvider(IStoreTable storeData)
        {
            _storeData = storeData;
        }

        public async Task Delete(long id)
        {
            await _storeData.Delete(id);
        }

        public async Task<IEnumerable<Store>> GetAll()
        {
            var stores = await _storeData.GetAll();
            var result = stores.Select(s => new sz.api.Models.Store
            {
                Address = s.Address,
                Id = s.Id,
                Name = s.Name
            }).ToList();
            return result;
        }

        public async Task<Store> GetOne(long id)
        {
            var store = await _storeData.GetOne(id);
            var result = new sz.api.Models.Store
            {
                Address = store.Address,
                Id = store.Id,
                Name = store.Name
            };
            return result;
        }

        public async Task<Store> Insert(Store value)
        {
            var result = _storeData.Insert(new commons.models.Store
            {
                Address = value.Address,
                Id = value.Id,
                Name = value.Name
            });
            value.Id = result.Id;
            return value;
        }

        public async Task<Store> Update(long id, Store value)
        {
            var result = await _storeData.Update(id, new commons.models.Store
            {
                Address = value.Address,
                Name = value.Name
            });
            value.Id = result.Id;
            return value;
        }
    }
}
