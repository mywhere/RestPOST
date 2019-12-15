using System;
using Microsoft.AspNetCore.Mvc;
using RestPOST.Models;

namespace RestPOST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpPost]
        [ActionName("Test")]
        public ActionResult<SearchResponse> Test([FromBody] SearchRequest searchRequest)
        {
            Guid organizationId = Guid.Empty;
            if (this.Request.Headers.ContainsKey("organization-id"))
            {
                Guid orgId;
                if (Guid.TryParse(this.Request.Headers["organization-id"], out orgId))
                {
                    organizationId = orgId;
                }
            }
             
            if (organizationId == Guid.Empty)
            {
                organizationId = Guid.NewGuid();
            }

            return new SearchResponse()
            {
                OrganizationId = organizationId,
                ControllerName = "Demo",
                ActionName = "Test",
                InputSearch = searchRequest.Search,
            };
        }
    }
}