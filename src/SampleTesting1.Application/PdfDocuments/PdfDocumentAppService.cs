using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.CmsKit.Comments;
using Volo.CmsKit.Reactions;

namespace SampleTesting1.PdfDocuments
{
    public class PdfDocumentAppService : CrudAppService<
        PdfDocument,
        PdfDocumentDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateUpdatePdfDocumentDto>, IPdfDocumentAppService
    {
        private readonly IRepository<Comment, Guid> _commentRepository;
        private readonly IRepository<UserReaction, Guid> _reactionRepository;
        private readonly PdfDocumentToPdfDocumentDtoMapper _pdfDocumentMapper;

        public PdfDocumentAppService(
            IRepository<PdfDocument, Guid> repository,
            IRepository<Comment, Guid> commentRepository,
            IRepository<UserReaction, Guid> reactionRepository,
            PdfDocumentToPdfDocumentDtoMapper pdfDocumentMapper)
            : base(repository)
        {
            _commentRepository = commentRepository;
            _reactionRepository = reactionRepository;
            _pdfDocumentMapper = pdfDocumentMapper;
        }

        public override async Task<PdfDocumentDto> CreateAsync(CreateUpdatePdfDocumentDto input)
        {
            if (input.PdfMediaId == Guid.Empty)
            {
                throw new Volo.Abp.UserFriendlyException("Please upload a PDF file before saving.");
            }

            var pdfDocument = new PdfDocument(
                GuidGenerator.Create(),
                input.Title,
                input.Description ?? string.Empty,
                input.PdfMediaId,
                input.Category,
                CurrentTenant.Id
            );

            await Repository.InsertAsync(pdfDocument, autoSave: true);
            return _pdfDocumentMapper.Map(pdfDocument);
        }

        public override async Task<PdfDocumentDto> UpdateAsync(Guid id, CreateUpdatePdfDocumentDto input)
        {
            if (input.PdfMediaId == Guid.Empty)
            {
                throw new Volo.Abp.UserFriendlyException("Please upload a PDF file before saving.");
            }

            var pdfDocument = await Repository.GetAsync(id);
            
            pdfDocument.Title = input.Title;
            pdfDocument.Description = input.Description ?? string.Empty;
            pdfDocument.PdfMediaId = input.PdfMediaId;
            pdfDocument.Category = input.Category ?? string.Empty;

            await Repository.UpdateAsync(pdfDocument, autoSave: true);
            return _pdfDocumentMapper.Map(pdfDocument);
        }

        public async Task<PagedResultDto<PdfDocumentWithDetailsDto>> GetDetailedListAsync(PagedAndSortedResultRequestDto input)
        {
            var query = await Repository.GetQueryableAsync();
            
            var totalCount = await AsyncExecuter.CountAsync(query);
            
            var documents = await AsyncExecuter.ToListAsync(
                query
                    .OrderByDescending(x => x.CreationTime)
                    .PageBy(input)
            );

            var documentDtos = await Task.WhenAll(documents.Select(async doc => 
            {
                var commentCount = await _commentRepository
                    .CountAsync(c => c.EntityType == SampleTesting1Consts.PdfDocumentEntityType && c.EntityId == doc.Id.ToString());
                
                var reactionCount = await _reactionRepository
                    .CountAsync(r => r.EntityType == SampleTesting1Consts.PdfDocumentEntityType && r.EntityId == doc.Id.ToString());

                return new PdfDocumentWithDetailsDto
                {
                    Id = doc.Id,
                    Title = doc.Title,
                    Description = doc.Description,
                    PdfMediaId = doc.PdfMediaId,
                    Category = doc.Category,
                    CreationTime = doc.CreationTime,
                    CommentCount = commentCount,
                    ReactionCount = reactionCount
                };
            }));

            return new PagedResultDto<PdfDocumentWithDetailsDto>(
                totalCount,
                documentDtos.ToList()
            );
        }
    }
}
