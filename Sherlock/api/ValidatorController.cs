using System.Web.Http;


namespace Sherlock.api
{
    public class ValidatorController : ApiController
    {


        // GET: api/Validator/string

        [HttpGet]
        [Route("api/Validator/{input}")]
        public IHttpActionResult Get(string input)
        {
            var history = Business.Sherlock.ValidateString(input);
            return Ok(new { history });

        }


    }
}
