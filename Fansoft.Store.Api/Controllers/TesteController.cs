using Microsoft.AspNetCore.Mvc;

namespace Fansoft.Store.Api.Controllers
{
    public class TesteController
    {
        [HttpGet("teste")]
        public string Ping() => "Pong";

        [HttpGet("testeex")]
        public string TestarException()
        {
            var num1 = 10;
            var num2 = 0;
            var result = num1/num2;
            return result.ToString();
        }

    }
    
}