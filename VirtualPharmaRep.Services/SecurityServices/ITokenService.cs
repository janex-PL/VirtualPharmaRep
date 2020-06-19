using System.Threading.Tasks;
using VirtualPharmaRep.Data.ViewModels.Tokens;

namespace VirtualPharmaRep.Services.SecurityServices
{
    public interface ITokenService
    {
        Task<TokenResponseViewModel> GetToken(TokenRequestViewModel request);
        Task<TokenResponseViewModel> RefreshToken(TokenRequestViewModel request);
    }
}
