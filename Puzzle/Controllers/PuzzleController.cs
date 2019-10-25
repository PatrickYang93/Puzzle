using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Puzzle.Service;

namespace Puzzle.Controllers
{
    public class PuzzleController : ApiController
    {
        private readonly ICalculator _calculator;
        public PuzzleController(ICalculator calculator)
        {
            _calculator = calculator;
        }
        public IHttpActionResult GetScore(string id)
        {     
            int score = _calculator.run(id);
            return Ok(score);
        }
    }
}
