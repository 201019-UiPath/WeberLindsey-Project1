using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreLib;
using StoreDB.Models;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService locationService;

        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }


        [HttpPost("add")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult AddLocation(Location location)
        {
            try
            {
                locationService.AddLocation(location);
                return CreatedAtAction("AddLocation", location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("edit")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult UpdateLocation(Location location)
        {
            try
            {
                locationService.UpdateLocation(location);
                return CreatedAtAction("UpdateLocation", location);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IActionResult DeleteLocation(Location location)
        {
            try
            {
                locationService.DeleteLocation(location);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("get")]
        [Produces("application/json")]
        public IActionResult GetAllLocations()
        {
            try
            {
                return Ok(locationService.GetAllLocations());
            } catch(Exception)
            {
                return StatusCode(500);
            } 
        }


        //TODO not implemented because dont need this 
        //Location GetLocationById(int id);
        // Location GetLocationByState(string state);
    }
}
