using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlans.API.Common.Controllers;
using TravelPlans.API.Model.TravelPlans;
using TravelPlans.Application.TravelPlans.Commands;
using TravelPlans.Application.TravelPlans.Dtos;
using TravelPlans.Application.TravelPlans.Queries;

namespace TravelPlans.API.Controllers
{
    public class TravelPlansController : BaseApiController
    {
        /// <summary>
        /// Retrieve users travel plans.
        /// </summary>
        /// <returns>List of user travel plans.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelPlanDto>>> Get()
        {
            var travelPlans = await Mediator.Send(new GetTravelPlansQuery(CurrentUser.Id, CurrentUser.IsAdmin));

            return Ok(travelPlans);
        }

        /// <summary>
        /// Retrieve all travel plans. Available only for admins.
        /// </summary>
        /// <returns>List of all travel plans.</returns>
        [HttpGet("all")]
        [Authorize(Policy = "Admins")]
        public async Task<ActionResult> GetAll()
        {
            var travelPlans = await Mediator.Send(new GetTravelPlansQuery(default, CurrentUser.IsAdmin));

            return Ok(travelPlans);
        }

        /// <summary>
        /// Creates a new travel plan.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add(AddTravelPlanDto request)
        {
            AddTravelPlanCommand command = new AddTravelPlanCommand
            {
                UserId = request?.UserId,
                CurrentUserId = CurrentUser.Id,
                IsAdmin = CurrentUser.IsAdmin,
                Name = request?.Name,
                StartDate = request?.StartDate,
                EndDate = request?.EndDate,
                Locations = request?.Locations
            };

            await Mediator.Send(command);

            return Ok();
        }

        /// <summary>
        /// Update a travel plan.
        /// </summary>
        /// <param name="id">Travel plan indentifier.</param>
        /// <param name="command">Travel plan updated body.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTravelPlanDto request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            UpdateTravelPlanCommand command = new UpdateTravelPlanCommand
            {
                Id = request.Id,
                UserId = request?.UserId,
                CurrentUserId = CurrentUser.Id,
                IsAdmin = CurrentUser.IsAdmin,
                Name = request?.Name,
                StartDate = request?.StartDate,
                EndDate = request?.EndDate,
                Locations = request?.Locations
            };

            await Mediator.Send(command);

            return Ok();
        }


        /// <summary>
        /// Remove a travel plan.
        /// </summary>
        /// <param name="id">Travel plan identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            RemoveTravelPlanCommand command = new RemoveTravelPlanCommand
            {
                Id = id,
                CurrentUserId = CurrentUser.Id,
                IsAdmin = CurrentUser.IsAdmin
            };

            await Mediator.Send(command);

            return Ok();
        }
    }
}
