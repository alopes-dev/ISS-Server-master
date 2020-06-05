// using GraphQL;
// using GraphQL.Types;
// using ISWebApp.GraphQL.Query;
// using ISWebLib;
// using ISS.Application.Api;
// using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Threading.Tasks;

// namespace ISWebApp.Api
// {
//    [ApiController]
//    [Route(ApiRoutes.BaseRoute)]
//    public class GraphQLController : ControllerBase
//    {

//        private readonly IDocumentExecuter _documentExecuter;
//        private readonly ISchema _schema;
//        private readonly IDistributedCacheService _redisCache;

//        public GraphQLController(ISchema schema, 
//                                 IDocumentExecuter documentExecuter,
//                                 IDistributedCacheService redisCache)
//        {
//            _schema = schema;
//            _documentExecuter = documentExecuter;
//            _redisCache = redisCache;
//        }

//        [HttpPost]
//        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
//        {
//            if (query == null) { throw new ArgumentNullException(nameof(query)); }

//            var executionOptions = new ExecutionOptions
//            {
//                Schema = _schema,
//                Query = query.Query,
//                Inputs = query.Variables?.ToInputs()
//            };
           
//            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

//            if (result.Errors?.Count > 0)
//            {
//                return BadRequest(result);
//            }

//            return Ok(result);
//        }


//    }
// }
