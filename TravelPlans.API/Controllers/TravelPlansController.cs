using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelPlans.API.Common.Controllers;
using TravelPlans.Application.TravelPlans.Commands;

namespace TravelPlans.API.Controllers
{
    public class TravelPlansController : BaseApiController
    {
        /// <summary>
        /// Retrieve users travel plans.
        /// </summary>
        /// <returns>List of user travel plans.</returns>
        [HttpGet("me")]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }

        /// <summary>
        /// Retrieve all travel plans.
        /// </summary>
        /// <returns>List of travel plans.</returns>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok();
        }

        /// <summary>
        /// Creates a new travel plan.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Add(AddTravelPlanCommand command)
        {
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
            return Ok();
        }
    }
}
