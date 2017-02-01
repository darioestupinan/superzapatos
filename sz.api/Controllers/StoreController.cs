using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sz.api.Providers;
using sz.api.Models;
using System.Net;

namespace sz.api.Controllers
{
    [Route("services/stores")]
    public class StoreController : Controller
    {
        private readonly IStoreProvider _storeProvider;

        public StoreController(IStoreProvider storeProvider)
        {
            _storeProvider = storeProvider;
        }

        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _storeProvider.GetAll();
                var response = new StoresResponseModel().CreateOkModel(result);
                return Ok(response);
            }
            catch (Exception)
            {
                var result = new StoresResponseModel
                {
                    Stores = null,
                    ErrorCode = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = "Bad Request",
                    Success = false
                };
                return BadRequest(result);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var result = await _storeProvider.GetOne(id);
                var response = new StoreResponseModel().CreateOkModel(result);
                return Ok(response);
            }
            catch (Exception)
            {
                var result = new StoreResponseModel
                {
                    ErrorCode = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = "Bad Request",
                    Success = false
                };
                return BadRequest(result);
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Store value)
        {
            try
            {
                var result = await _storeProvider.Insert(value);
                var response = new StoreResponseModel().CreateOkModel(result);
                return Ok(response);
            }
            catch (Exception)
            {
                var result = new StoreResponseModel
                {
                    ErrorCode = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = "Bad Request",
                    Success = false
                };
                return BadRequest(result);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]Store value)
        {
            try
            {
                var result = await _storeProvider.Update(id, value);
                var response = new StoreResponseModel().CreateOkModel(result);
                return Ok(response);
            }
            catch (Exception)
            {
                var result = new StoreResponseModel
                {
                    ErrorCode = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = "Bad Request",
                    Success = false
                };
                return BadRequest(result);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _storeProvider.Delete(id);
                var emptyModel = new Store();
                var response = new StoreResponseModel().CreateOkModel(emptyModel);
                return Ok(response);
            }
            catch (Exception)
            {
                var result = new StoreResponseModel
                {
                    ErrorCode = (int)HttpStatusCode.BadRequest,
                    ErrorMessage = "Bad Request",
                    Success = false
                };
                return BadRequest(result);
            }
        }
    }
}
