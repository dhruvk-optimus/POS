using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Application.DTOs.Item;
using POS.Application.Features.Item.Commands;
using POS.Application.Features.Item.Queries;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemsController(IMediator mediator) => this._mediator = mediator;

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemResponseDTO>> AddItem([FromBody] AddItemRequestDTO request)
        {
            var command = new AddItemCommand(request);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetItemById), new { itemId = result.ItemId }, result);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ItemResponseDTO>> UpdateItem([FromBody] UpdateItemRequestDTO request)
        {
            var command = new UpdateItemCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ItemResponseDTO>>> GetItems()
        {
            var query = new GetItemsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete("{itemId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteItem(Guid itemId)
        {
            var command = new DeleteItemCommand(itemId);
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{itemId}")]
        [Authorize]
        public async Task<ActionResult<ItemResponseDTO>> GetItemById(Guid itemId)
        {
            var query = new GetItemByIdQuery(itemId);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
