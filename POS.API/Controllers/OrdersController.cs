using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        //[HttpGet]
        //[Authorize(Roles = "Admin,Cashier")]
        //public async Task<ActionResult<>> GetAllOrders()
        //{

        //}
    }
}
