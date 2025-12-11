using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleTesting1.PdfDocuments;

namespace SampleTesting1.Web.Pages.PdfDocuments.Management;

public class EditModalModel : SampleTesting1PageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdatePdfDocumentDto PdfDocument { get; set; } = new();

    private readonly IPdfDocumentAppService _pdfDocumentAppService;

    public EditModalModel(IPdfDocumentAppService pdfDocumentAppService)
    {
        _pdfDocumentAppService = pdfDocumentAppService;
    }

    public async Task OnGetAsync()
    {
        var dto = await _pdfDocumentAppService.GetAsync(Id);
        PdfDocument = ObjectMapper.Map<PdfDocumentDto, CreateUpdatePdfDocumentDto>(dto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _pdfDocumentAppService.UpdateAsync(Id, PdfDocument);
        return NoContent();
    }
}
