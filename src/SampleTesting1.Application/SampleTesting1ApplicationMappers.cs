using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using SampleTesting1.PdfDocuments;

namespace SampleTesting1;

/// <summary>
/// Mapper for PdfDocument to PdfDocumentDto
/// </summary>
[Mapper]
public partial class PdfDocumentToPdfDocumentDtoMapper : MapperBase<PdfDocument, PdfDocumentDto>
{
    public override partial PdfDocumentDto Map(PdfDocument source);
    public override partial void Map(PdfDocument source, PdfDocumentDto destination);
}
