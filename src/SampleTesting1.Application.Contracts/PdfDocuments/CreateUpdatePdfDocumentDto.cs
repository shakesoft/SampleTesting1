using System;
using System.ComponentModel.DataAnnotations;

namespace SampleTesting1.PdfDocuments
{
    public class CreateUpdatePdfDocumentDto
    {
        [Required]
        [StringLength(256)]
        public string Title { get; set; }
        
        [StringLength(2000)]
        public string Description { get; set; }
        
        [Required]
        public Guid PdfMediaId { get; set; }
        
        [StringLength(128)]
        public string Category { get; set; }
    }
}
