﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sz.api.Models;
using System.Web.Http;
using System.Net;
using sz.api.Providers;
using Newtonsoft.Json.Linq;
using System.Threading;
using sz.api.ExceptionHandlers;

namespace sz.api.Controllers
{
    [Route("services/articles")]
    public class ArticleController : Controller
    {
        private readonly IArticleProvider _articleProvider;
        private readonly IStoreProvider _storeProvider;

        public ArticleController(IArticleProvider articleProvider, IStoreProvider storeProvider)
        {
            _articleProvider = articleProvider;
            _storeProvider = storeProvider;
        }

        // GET api/article
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var articles = await _articleProvider.GetAllAsync();
                var result = new ArticlesResponseModel(articles);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new FailureModel(success: true, code: (int)HttpStatusCode.BadRequest, response: "Bad Request");
                return BadRequest(result);
            }
        }

        // GET api/article/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var article = await _articleProvider.GetOne(id);
                var result = new ArticleResponseModel(article);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new FailureModel(success: false, code: (int)HttpStatusCode.BadRequest, response: "Bad Request");
                return BadRequest(result);
            }

        }

        // GET api/article/store/5
        [HttpGet("stores/{id}")]        
        public async Task<IActionResult> GetByStore(long id)
        {
            try
            {
                if (id == 0) throw new Exception();
                var article = await _articleProvider.GetByStoreId(id);
                var result = new ArticlesResponseModel(article);
                return Ok(result);
            }
            catch (RecordNotFoundException)
            {
                var result = new FailureModel(success: false, code: (int)HttpStatusCode.NotFound, response: "Record Not Found");
                return NotFound(result);
            }
            catch (Exception ex)
            {
                var result = new FailureModel(success: false, code: (int)HttpStatusCode.BadRequest, response: "Bad Request");
                return BadRequest(result);
            }

        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ArticleEntry value)
        {
            try
            {
                var result = await _articleProvider.Insert(value);
                var response = new ArticleResponseModel(result);
                return Ok(response);
            }
            catch (Exception)
            {
                var result = new FailureModel(success: false, code: (int)HttpStatusCode.BadRequest, response: "Bad Request");
                return BadRequest(result);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody]Article value)
        {
            try
            {
                var result = await _articleProvider.Update(id, value);
                var response = new ArticleResponseModel(result);
                return Ok(response);
            }
            catch (Exception)
            {
                var result = new FailureModel(success: false, code: (int)HttpStatusCode.BadRequest, response: "Bad Request");                    
                return BadRequest(result);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                await _articleProvider.Delete(id);
                var emptyModel = new Article();
                var response = new ArticleResponseModel(emptyModel);
                return Ok(response);
            }
            catch (Exception)
            {
                var result = new FailureModel(success: false, code: (int)HttpStatusCode.BadRequest, response: "Bad Request");
                return BadRequest(result);
            }
        }
    }
}
