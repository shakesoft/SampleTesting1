using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SampleTesting1.PdfDocuments;

namespace SampleTesting1.Web.Public.Pages.PdfDocuments;

public class DetailModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    public PdfDocumentDto PdfDocument { get; set; } = new();

    private readonly IPdfDocumentAppService _pdfDocumentAppService;

    public DetailModel(IPdfDocumentAppService pdfDocumentAppService)
    {
        _pdfDocumentAppService = pdfDocumentAppService;
    }

    public async Task OnGetAsync()
    {
        PdfDocument = await _pdfDocumentAppService.GetAsync(Id);
    }
}
