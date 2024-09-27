using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorldAPI.Data;
using WorldAPI.Model;

namespace WorldAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public readonly ApplicationDbContext _dbContext;
        public CountryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        [HttpPost]
        public ActionResult<Country> Create([FromBody]Country country)
        {
            _dbContext.countries.Add(country);
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpGet]
        // If the output is not documented, Have to document the status
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            var Countries = _dbContext.countries.ToList();
            if(Countries==null)
            {
                return NoContent();
            }
            return Countries;
        }
        [HttpGet("{Id:int}")]
        // If the output is not documented, Have to document the status
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Country> GetByID(int Id)
        {
            var country = _dbContext.countries.Find(Id);
            if(country==null)
            {
                return NoContent();
            }
            return country;
        }
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<Country> Update(int id,[FromBody]Country country)
        {
            if(country==null || id!=country.Id)
            {
                return BadRequest();
            }

            var CountryFromDB = _dbContext.countries.Find(id);
            if (CountryFromDB == null)
            {
                return NotFound();
            }

            CountryFromDB.Name= country.Name;
            CountryFromDB.ShortName= country.ShortName;
            CountryFromDB.CountryCode= country.CountryCode;

            _dbContext.countries.Update(CountryFromDB);
            _dbContext.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{Id:int}")]
        public ActionResult DeleteById(int Id)
        {
            var country = _dbContext.countries.Find(Id);
            _dbContext.countries.Remove(country);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
