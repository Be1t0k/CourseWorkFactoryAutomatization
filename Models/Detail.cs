namespace CourseWorkFactoryAutomatization.Models
{
    public class Detail
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public decimal Cost { get; set; }
        public long TechnicId { get; set; }
        public long DetailCatalogId { get; set; }
        public virtual Technic? Technic { get; set; }
        public virtual DetailCatalog? DetailCatalog { get; set; }
    }
}
