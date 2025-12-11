using System;
using Volo.Abp.Application.Dtos;

namespace SampleTesting1.PdfDocuments
{
    public class PdfDocumentDto : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid PdfMediaId { get; set; }
        public string Category { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
