﻿using Microsoft.AspNetCore.Mvc;
using RainfallAPI.Services;
using RainfallAPI.TransformObjects;

namespace RainfallAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        private readonly ProcessAPIResponse _processAPIResponse;

        public RainfallController(ProcessAPIResponse processAPIResponse)
        {
            _processAPIResponse = processAPIResponse;
        }

        [HttpGet("id/{stationId}/readings")]
        public async Task<ActionResult> GetReadings(int stationId, [FromQuery] int numberOfReadings)
        {
            if ((numberOfReadings < 1) || (numberOfReadings > 100))
                return BadRequest(new ErrorResponse { Message = "Parameter should be from 1 to 100" });

            var result = await _processAPIResponse.GetResponse(stationId, numberOfReadings);

            if (result == null)
                return StatusCode(500, new ErrorResponse { Message = "Internal server error" });

            if (result.Readings.Count == 0)
                return NotFound(new ErrorResponse { Message = "No readings found for the specified stationId" });

            return Ok(result);
        }
    }
}
