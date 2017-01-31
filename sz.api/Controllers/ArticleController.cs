using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sz.api.Models;
using System.Web.Http;
using System.Net;
using sz.api.Providers;
using Newtonsoft.Json.Linq;

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
        //[Produces("application/json", "application/xml")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var articles = await _articleProvider.GetAllAsync();
                var result = new ArticlesResponseModel().CreateOkModel(articles);
                return Ok(result);
            }
            catch (Exception ex)
            {
                var result = new ArticlesResponseModel().CreateFailureModel((int)HttpStatusCode.BadRequest, Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.BadRequest)) as ArticlesResponseModel;
                return BadRequest(result);
            }
        }

        // GET api/article/5
        [HttpGet("{id}")]
        public async Task<ArticleResponseModel> Get(long id)
        {
            try
            {
                var article = await _articleProvider.GetOne(id);
                var result = new ArticleResponseModel().CreateOkModel(article);
                return result;
            }
            catch (Exception ex)
            {
                var result = new ArticleResponseModel().CreateFailureModel((int)HttpStatusCode.BadRequest, Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.BadRequest)) as ArticleResponseModel;
                return result;
            }

        }

        // GET api/article/store/5
        [HttpGet("store/{id}")]        
        public async Task<ArticlesResponseModel> GetByStore(long id)
        {
            try
            {
                var article = await _articleProvider.GetByStoreId(id);
                var result = new ArticlesResponseModel().CreateOkModel(article);
                return result;
            }
            catch (Exception ex)
            {
                var result = new ArticlesResponseModel().CreateFailureModel((int)HttpStatusCode.BadRequest, Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.BadRequest)) as ArticlesResponseModel;
                return result;
            }

        }

        // POST api/values
        [HttpPost]
        public async Task<ArticleResponseModel> Post([FromBody]Article value)
        {
            try
            {
                var result = await _articleProvider.Insert(value);
                var response = new ArticleResponseModel().CreateOkModel(result);
                return response;
            }
            catch (Exception)
            {
                var result = new ArticleResponseModel().CreateFailureModel((int)HttpStatusCode.BadRequest, Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.BadRequest)) as ArticleResponseModel;
                return result;
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ArticleResponseModel> Put(long id, [FromBody]Article value)
        {
            try
            {
                var result = await _articleProvider.Update(id, value);
                var response = new ArticleResponseModel().CreateOkModel(result);
                return response;
            }
            catch (Exception)
            {
                var result = new ArticleResponseModel().CreateFailureModel((int)HttpStatusCode.BadRequest, Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.BadRequest)) as ArticleResponseModel;
                return result;
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ArticleResponseModel> Delete(long id)
        {
            try
            {
                await _articleProvider.Delete(id);
                var emptyModel = new Article();
                var response = new ArticleResponseModel().CreateOkModel(emptyModel);
                return response;
            }
            catch (Exception)
            {
                var result = new ArticleResponseModel().CreateFailureModel((int)HttpStatusCode.BadRequest, Enum.GetName(typeof(HttpStatusCode), HttpStatusCode.BadRequest)) as ArticleResponseModel;
                return result;
            }
        }
    }
}
