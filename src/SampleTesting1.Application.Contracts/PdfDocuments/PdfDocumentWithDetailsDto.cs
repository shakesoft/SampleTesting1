namespace SampleTesting1.PdfDocuments
{
    public class PdfDocumentWithDetailsDto : PdfDocumentDto
    {
        public int CommentCount { get; set; }
        public int ReactionCount { get; set; }
    }
}
