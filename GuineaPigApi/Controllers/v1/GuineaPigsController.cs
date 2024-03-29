﻿using GuineaPigApi.DTOs;
using GuineaPigApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GuineaPigApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{v:ApiVersion}/[controller]")]
    [ApiController]
    public class GuineaPigsController : ControllerBase
    {
        private readonly IGuineaPigService _service;
        public GuineaPigsController(IGuineaPigService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetGuineaPigs()
        {
            var guineaPigs = await _service.GetGuineaPigsAsync();
            if (guineaPigs.Count() < 0) return NoContent();
            return Ok(guineaPigs);
        }

        [HttpGet("{guineaPigId:int}")]
        public async Task<IActionResult> GetGuineaPig(int guineaPigId)
        {
            var guineaPig = await _service.GetGuineaPigByIdAsync(guineaPigId);
            if (guineaPig == null) return NotFound($"Kein Meerschweinchen mit der Id:{guineaPigId} gefunden");
            return Ok(guineaPig);
        }

        [HttpPost]
        public async Task<IActionResult> InsertGuineaPig(GuineaPigDto? guineaPigDto)
        {
            try
            {
                if (guineaPigDto == null) return BadRequest("NO DATA");
                var newGuineaPig = await _service.InsertGuineaPigAsync(guineaPigDto);
                return Ok(newGuineaPig);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{guineaPigId:int}")]
        public async Task<IActionResult> UpdateGuineaPig(int guineaPigId, GuineaPigDto guineaPigDto)
        {
            try
            {
                if (guineaPigId != guineaPigDto.Id) return BadRequest("Falsche ID");
                var updatedGuineaPig = await _service.UpdateGuineaPigAsync(guineaPigId, guineaPigDto);
                return Ok(updatedGuineaPig);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{guineaPigId}")]
        public async Task<IActionResult> DeleteGuineaPig(int guineaPigId)
        {
            try
            {
                var checkDelete = await _service.DeleteGuineaPigAsync(guineaPigId);
                if (!checkDelete) return BadRequest("Konnte nicht gelöscht werden");
                return Ok(checkDelete);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
