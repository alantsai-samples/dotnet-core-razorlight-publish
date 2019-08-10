using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using RazorLight;

namespace DoteNetCore.Reaorlight.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IHostingEnvironment Env { get; }

        public ValuesController(IHostingEnvironment env)
        {
            Env = env;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            var engine = new RazorLightEngineBuilder()
              .UseFilesystemProject(Path.Combine(Env.ContentRootPath, "Template"))
              .UseMemoryCachingProvider()
              .Build();

            string result = await engine.CompileRenderAsync("HelloWorld.cshtml", new { Name = "John Doe" });

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
