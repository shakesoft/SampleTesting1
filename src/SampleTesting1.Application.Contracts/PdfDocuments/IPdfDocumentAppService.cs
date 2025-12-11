using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SampleTesting1.PdfDocuments
{
    public interface IPdfDocumentAppService : ICrudAppService<
        PdfDocumentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePdfDocumentDto>
    {
        Task<PagedResultDto<PdfDocumentWithDetailsDto>> GetDetailedListAsync(PagedAndSortedResultRequestDto input);
    }
}
