using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualPharmaRep.Data.ViewModels.Tokens;
using VirtualPharmaRep.Services.SecurityServices;

namespace VirtualPharmaRep.API.Controllers
{
	[Route("api/auth"), ApiController]
	public class AuthorizationController : ControllerBase
    {
        #region Services
        private readonly ITokenService _service;
        #endregion

        #region Constructor
        public AuthorizationController(ITokenService service)
        {
            _service = service;
        }
        #endregion

        #region Endpoints
        [HttpPost("Auth")]
        public async Task<ActionResult<TokenResponseViewModel>> Auth([FromBody] TokenRequestViewModel model)
        {
            if (model?.GrantType == null)
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

            return response ?? (ActionResult<TokenResponseViewModel>)Unauthorized();
        }
        #endregion
    }
}