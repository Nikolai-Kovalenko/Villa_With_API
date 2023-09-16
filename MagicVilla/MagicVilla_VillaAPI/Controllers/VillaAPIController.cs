using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly AppDbContext _db;

        public VillaAPIController(AppDbContext db)
        {
            _db = db;
        }



        [HttpGet]
        // [HttpGet("GetVillas")] // Явно указывает на метод
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(_db.Villas.ToList());
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        // [HttpGet("GetVilla/{id}")] // Явно указывает на метод с id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(200, Type = typeof(VillaDTO))]
        // [ProducesResponseType(400)]
        // [ProducesResponseType(404)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            if(villa == null)
            {
                return NotFound();  
            }
            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody]VillaCreateDTO villaDTO) 
        {

            //if (!ModelState.IsValid) // Работает валидация через [ApiController]
            //{
            //    return BadRequest(ModelState);
            //}

            if (_db.Villas.FirstOrDefault(u => u.Name.ToLower() == villaDTO.Name.ToLower()) != null)
            {
                ModelState.AddModelError("CustomError", "Villa already Exist!");
                return BadRequest(ModelState);
            }
            if (villaDTO == null)
            {
                return BadRequest(villaDTO);
            }

            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft
            };
            _db.Villas.Add(model);
            _db.SaveChanges();

            return CreatedAtRoute("GetVilla", new { id = model.Id }, model);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        { 
            if(id == 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.FirstOrDefault(u => u.Id == id);

            if(villa == null)
            {
                return NotFound();
            }

            _db.Villas.Remove(villa);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaUpdateDTO villaDTO)
        {
            if(villaDTO == null || id != villaDTO.Id)
            { 
                return BadRequest(); 
            }

            //var villa = VillaStore.villaList.FirstOrDefault(u => u.Id == villaDTO.Id);
            //villa.Name = villaDTO.Name;
            //villa.Occupancy = villaDTO.Occupancy;
            //villa.Sqft = villaDTO.Sqft; 

            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft
            };

            _db.Villas.Update(model);
            _db.SaveChanges();


            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }

            var villa = _db.Villas.AsNoTracking().FirstOrDefault(u => u.Id == id);

            VillaUpdateDTO villaDTO = new()
            {
                Amenity = villa.Amenity,
                Details = villa.Details,
                Id = villa.Id,
                ImageUrl = villa.ImageUrl,
                Name = villa.Name,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft
            };


            if (villa == null)
            {
                return NotFound();
            }
            
            patchDTO.ApplyTo(villaDTO, ModelState);  
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Villa model = new()
            {
                Amenity = villaDTO.Amenity,
                Details = villaDTO.Details,
                Id = villaDTO.Id,
                ImageUrl = villaDTO.ImageUrl,
                Name = villaDTO.Name,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft
            };

            _db.Villas.Update(model);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
