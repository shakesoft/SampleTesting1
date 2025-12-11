using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;
using SampleTesting1.PdfDocuments;

namespace SampleTesting1;

[Mapper]
public partial class SampleTesting1ApplicationMappers
{
    // PdfDocument mappings
    public partial PdfDocumentDto PdfDocumentToPdfDocumentDto(PdfDocument source);
    public partial CreateUpdatePdfDocumentDto PdfDocumentDtoToCreateUpdatePdfDocumentDto(PdfDocumentDto source);
    public partial void CreateUpdatePdfDocumentDtoToPdfDocument(CreateUpdatePdfDocumentDto source, PdfDocument destination);
}

/*
 * You can add your own mappings here.
 * [Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
 * public partial class SampleTesting1ApplicationMappers : MapperBase<BookDto, CreateUpdateBookDto>
 * {
 *    public override partial CreateUpdateBookDto Map(BookDto source);
 * 
 *    public override partial void Map(BookDto source, CreateUpdateBookDto destination);
 * }
 */
