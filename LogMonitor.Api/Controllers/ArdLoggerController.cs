using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ARD.ESProvider;
using LogMonitor.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogMonitor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArdLoggerController : ControllerBase
    {
        public ArdLoggerController(ESClientProvider<LogViewModel> eSClientProvider)
        {
            _esClientProvider = eSClientProvider;
        }

        private ESClientProvider<LogViewModel> _esClientProvider;


        [HttpPost, Route("Create")]
        public async Task<IActionResult> Create([FromBody] LogViewModel model)
        {
            try
            {
                var res = await _esClientProvider.Client.IndexDocumentAsync<LogViewModel>(model);
                if (!res.IsValid)
                {
                    throw new InvalidOperationException(res.DebugInformation);
                }

                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpGet, Route("Query/{pageIndex}/{pageSize}/{keywords}")]
        public async Task<IActionResult> Query(string keywords, int? pageIndex = 0, int? pageSize = 10)
        {
            var searchResponse = await _esClientProvider.Client.SearchAsync<LogViewModel>(
                s => s
                    .From(pageIndex)
                    .Size(pageSize)
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f
                                .AreaKeyWords
                                )
                            .Analyzer(keywords)
                            )
                            )
                );
            var logInfo = searchResponse.Documents;
            return Ok(logInfo);
        }
    }
}