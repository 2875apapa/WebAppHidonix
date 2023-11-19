using Hangfire;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using WebApp.EfCore;
using WebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class SettoreApiController : ControllerBase
    {
        private readonly DbHelper _db;
        private readonly IBackgroundJobClient _backgroundJobClient;
        public SettoreApiController(DataContext dataContext, IBackgroundJobClient backgroundJobClient)
        {
            _db = new DbHelper(dataContext);
            _backgroundJobClient = backgroundJobClient;
        }

        // GET: api/<SettoreApiController>/GetAll
        [HttpGet]
        [Authorize]
        [Route("api/[controller]/GetAll")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<SettoreModel> data = _db.GetSettori();

                if(!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET api/<SettoreApiController>/GetId/5
        [HttpGet("{id}")]
        [Authorize]
        [Route("api/[controller]/GetId/{id}")]
        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                SettoreModel data = _db.GetSettoreById(id);
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetAppResponse(type, data));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST api/<SettoreApiController>/Save
        [HttpPost]
        [Authorize]
        [Route("api/[controller]/Save")]
        public IActionResult Post([FromBody] SettoreModel settoreModel)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.SaveSettore(settoreModel);
                return Ok(ResponseHandler.GetAppResponse(type, settoreModel));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT api/<SettoreApiController>/Update
        [HttpPut]
        [Authorize]
        [Route("api/[controller]/Update")]
        public IActionResult Put([FromBody] SettoreModel settoreModel)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                _db.SaveSettore(settoreModel);
                return Ok(ResponseHandler.GetAppResponse(type, settoreModel));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        
        // DELETE api/<SettoreApiController>/Delete/5

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [Route("api/[controller]/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _backgroundJobClient.Enqueue(() => _db.DeleteSettore(id));
                //return Ok(ResponseHandler.GetAppResponse(type, "Delete Successfully"));
                return Ok(ResponseHandler.GetAppResponse(type, "Delete In Background"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        
    }
}
