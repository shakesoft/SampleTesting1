using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleTesting1.PdfDocuments;
using Volo.Abp.Application.Dtos;

namespace SampleTesting1.Web.Public.Pages.PdfDocuments;

public class IndexModel : PageModel
{
    public PagedResultDto<PdfDocumentDto> PdfDocuments { get; set; } = new();

    private readonly IPdfDocumentAppService _pdfDocumentAppService;

    public IndexModel(IPdfDocumentAppService pdfDocumentAppService)
    {
        _pdfDocumentAppService = pdfDocumentAppService;
    }

    public async Task OnGetAsync()
    {
        PdfDocuments = await _pdfDocumentAppService.GetListAsync(
            new PagedAndSortedResultRequestDto
            {
                MaxResultCount = 100
            }
        );
    }
}
