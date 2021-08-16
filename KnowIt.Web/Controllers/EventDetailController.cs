using KnowIt.Domain.DTO;
using KnowIt.Service.EventDetailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowIt.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [AllowAnonymous]
    public class EventDetailController : ControllerBase
    {
        private readonly IEventDetailService _service;

        public EventDetailController(IEventDetailService service)
        {
            _service = service;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDetailDto>>> GetAll()
        {
            try
            {
                var EventDetails = await _service.GetAllAsync();
                return EventDetails.ToList();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([BindRequired] int id)
        {
            try
            {
                var EventDetail = await _service.GetAsync(id);
                if (EventDetail == null)
                    return NotFound($"EventDetail with id {id} not found");
                else
                    return new ObjectResult(EventDetail);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to connect on server");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EventDetail"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EventDetailDto EventDetail)
        {
            try
            {
                var result = await _service.PostAsync(EventDetail);
                return new ObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to add a new EventDetail: {ex.Message}");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="EventDetail"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update([BindRequired] int id, [FromBody] EventDetailDto EventDetail)
        {
            try
            {
                if (EventDetail == null || id != EventDetail.Id)
                    return BadRequest($"EventDetail with id {id} not found");
                else
                {
                    var result = await _service.PutAsync(EventDetail);
                    return StatusCode(StatusCodes.Status200OK, $"EventDetail id {id} update succesfull");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error when try to update EventDetail {ex.Message}");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete([BindRequired] int id)
        {
            try
            {
                var result = await _service.GetAsync(id);
                if (result == null)
                    return NotFound($"EventDetail with id {id} not found");

                await _service.DeleteAsync(id);

                return StatusCode(StatusCodes.Status200OK, "EventDetail deleted succesfull");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error when try to delete EventDetail");
            }
        }

       
    }
}
