namespace CourseWorkFactoryAutomatization.Models
{
    public class Detail
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public long TechnicId { get; set; }
        public virtual Technic Technic { get; set; }
    }
}
