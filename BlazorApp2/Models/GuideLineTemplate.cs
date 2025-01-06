namespace BlazorApp2.Models
{
    public class GuideLineTemplate
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? AuthorID { get; set; }
        public int? ClientID { get; set; }
        public string? ClientName { get; set; }
        public string? Status { get; set; }
        public string? CalculationType { get; set; }
        public string? AllowAttachment { get; set; }
        public string? FeedbackType { get; set; }
        public string? TemplateType { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
