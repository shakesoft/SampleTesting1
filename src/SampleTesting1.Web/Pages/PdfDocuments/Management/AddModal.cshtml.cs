using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleTesting1.PdfDocuments;

namespace SampleTesting1.Web.Pages.PdfDocuments.Management;

public class AddModalModel : SampleTesting1PageModel
{
    [BindProperty]
    public CreateUpdatePdfDocumentDto PdfDocument { get; set; } = new();

    private readonly IPdfDocumentAppService _pdfDocumentAppService;

    public AddModalModel(IPdfDocumentAppService pdfDocumentAppService)
    {
        _pdfDocumentAppService = pdfDocumentAppService;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _pdfDocumentAppService.CreateAsync(PdfDocument);
        return NoContent();
    }
}
