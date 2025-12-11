using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace SampleTesting1.PdfDocuments;

public class PdfDocument : CreationAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public Guid PdfMediaId { get; set; }
    
    public string Category { get; set; } = string.Empty;
    
    protected PdfDocument()
    {
    }

    public PdfDocument(
        Guid id,
        string title,
        string description,
        Guid pdfMediaId,
        string? category = null,
        Guid? tenantId = null) : base(id)
    {
        Title = title;
        Description = description;
        PdfMediaId = pdfMediaId;
        Category = category ?? string.Empty;
        TenantId = tenantId;
    }
}
