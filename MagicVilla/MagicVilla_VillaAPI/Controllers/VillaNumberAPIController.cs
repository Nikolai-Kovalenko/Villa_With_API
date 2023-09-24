using AutoMapper;
using AutoMapper.Configuration.Conventions;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaNumberAPI")]
    [ApiController]
    public class VillaNumberAPIController : ControllerBase
    {
       
        private readonly IVillaNumberRepository _dbVillaNum;
        private readonly IVillaRepository _dbVilla;
        public IMapper _mapper { get; set; }
        protected APIResponse _response;

        public VillaNumberAPIController(IVillaNumberRepository dbVillaNum, IMapper mapper, IVillaRepository dbVilla)
        {
            _dbVillaNum = dbVillaNum;
            _mapper = mapper;
            this._response = new();
            _dbVilla = dbVilla;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillaNumbers()
        {
            try
            {
                IEnumerable<VillaNumber> villaNumList = await _dbVillaNum.GetAllAsync(includeProperties:"Villa");
                _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaNumList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages 
                    = new List<string>() { ex.ToString() };
            }
            return _response;

            
        }

        [HttpGet("{id:int}", Name = "GetVillaNumber")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetVillaNumber(int id)
        {
            try
            {
                if(id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }

                var villaNum = await _dbVillaNum.GetAsync(u => u.VillaNo == id);
                if(villaNum == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaNumberDTO>(villaNum);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateVillaNumber([FromBody]VillaNumberCreateDTO creatrDTO) 
        {
            try
            {

                if(await _dbVillaNum.GetAsync(u => u.SpecialDetails.ToLower() == creatrDTO.SpecialDetails.ToLower()) != null
                    | await _dbVillaNum.GetAsync(u => u.VillaNo == creatrDTO.VillaNo) != null )
                {
                    ModelState.AddModelError("CustomError", "VillaNumber already Exist!");
                    return BadRequest(ModelState);
                }

                if(await _dbVilla.GetAsync(u => u.Id == creatrDTO.VillaId) == null)
                {
                    ModelState.AddModelError("CustomError", "Villa Id is InValid!");
                    return BadRequest(ModelState);
                }

                if (creatrDTO == null)
                {
                    return BadRequest(creatrDTO);
                }
                VillaNumber villaNum = _mapper.Map<VillaNumber>(creatrDTO);

                await _dbVillaNum.CreateAsync(villaNum);

                _response.Result = _mapper.Map<VillaNumberCreateDTO>(villaNum);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetVillaNumber", new { id = villaNum.VillaNo }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }
                
        [HttpDelete("{id:int}", Name = "DeleteVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteVillaNumber(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var villaNum = await _dbVillaNum.GetAsync(u => u.VillaNo == id);

                if (villaNum == null)
                {
                    return NotFound();
                }

                await _dbVillaNum.RemoveAsync(villaNum);

                _response.Result = _mapper.Map<VillaNumberDTO>(villaNum);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdateVillaNumber")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVillaNumber(int id, [FromBody] VillaNumberUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.VillaNo)
                {
                    return BadRequest();
                }

                if (await _dbVilla.GetAsync(u => u.Id == updateDTO.VillaId) == null)
                {
                    ModelState.AddModelError("CustomError", "Villa Id is InValid!");
                    return BadRequest(ModelState);
                }

                VillaNumber villaNum = _mapper.Map<VillaNumber>(updateDTO);

                await _dbVillaNum.UpdateAsync(villaNum);

                _response.Result = _mapper.Map<VillaNumberDTO>(villaNum);
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMassages
                    = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        /*
        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
        {
            if (patchDTO == null || id == 0)
            {
                return BadRequest();
            }

            var villa = await  _dbVilla.GetAsync(u => u.Id == id, tracked:false);

            VillaUpdateDTO villaDTO = _mapper.Map<VillaUpdateDTO>(villa);

            if (villa == null)
            {
                return NotFound();  
            }
            
            patchDTO.ApplyTo(villaDTO, ModelState);  
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            Villa model = _mapper.Map<Villa>(villaDTO);

            await _dbVilla.UpdateAsync(model);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }
        */
    }
}
