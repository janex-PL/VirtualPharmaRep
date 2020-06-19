using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualPharmaRep.Data.ViewModels.Tokens;
using VirtualPharmaRep.Services.SecurityServices;

namespace VirtualPharmaRep.API.Controllers
{
	[Route("api/[controller]"), ApiController]
	public class TokenController : ControllerBase
    {
        private readonly ITokenService _service;

        public TokenController(ITokenService service)
        {
            _service = service;
        }

        [HttpPost("Auth")]
		public async Task<ActionResult<TokenResponseViewModel>> Auth([FromBody] TokenRequestViewModel model)
		{
			if(model?.GrantType == null)
				return BadRequest();
            TokenResponseViewModel response;
            switch (model.GrantType)
            {
				case "password":
                    response = await _service.GetToken(model);
                    break;
                case "refresh_token":
                    response = await _service.RefreshToken(model);
                    break;
                default:
                    return BadRequest();
            }

            return response ?? (ActionResult<TokenResponseViewModel>) Unauthorized();
        }
    }
}