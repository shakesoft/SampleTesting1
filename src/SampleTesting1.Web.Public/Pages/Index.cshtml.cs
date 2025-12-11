using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace SampleTesting1.Web.Public.Pages;

public class IndexModel : SampleTesting1PublicPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
