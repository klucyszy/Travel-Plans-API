using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelPlans.API.Common.Controllers;
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
        [HttpGet("me")]
        public async Task<ActionResult<IEnumerable<TravelPlanDto>>> Get()
        {
            var travelPlans = await Mediator.Send(new GetTravelPlansQuery(CurrentUser.Id));

            return Ok(travelPlans);
        }

        /// <summary>
        /// Retrieve all travel plans.
        /// </summary>
        /// <returns>List of travel plans.</returns>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var travelPlans = await Mediator.Send(new GetTravelPlansQuery(default));

            return Ok(travelPlans);
        }

        /// <summary>
        /// Creates a new travel plan.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add(AddTravelPlanCommand command)
        {
            if (!string.IsNullOrEmpty(command.UserId) && !CurrentUser.IsAdmin)
            {
                return Unauthorized();
            }

            if (string.IsNullOrEmpty(command.UserId))
            {
                command.UserId = CurrentUser.Id;
            }

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
        public async Task<ActionResult> Update(int id, UpdateTravelPlanCommand command)
        {
            if (id != command.TravelPlan.Id)
            {
                return BadRequest();
            }

            if (command.TravelPlan.UserId != CurrentUser.Id && !CurrentUser.IsAdmin)
            {
                return Unauthorized();
            }

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
            await Mediator.Send(new RemoveTravelPlanCommand(id, CurrentUser.Id));

            return Ok();
        }
    }
}
