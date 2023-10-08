using AutoMapper;
using AutoMapper.Configuration.Conventions;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Specialized;
using System.Data;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers.v2
{
    [Route("api/v{version:apiVersion}/VillaNumberAPI")]
    [ApiController]
    [ApiVersion("2.0")]
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

        [HttpGet("GetString")]
        // [MapToApiVersion("2.0")]
        public IEnumerable<string> Get()
        {
            return new string[] { "V2 value1", "V2 value2" };
        }
    }
}
