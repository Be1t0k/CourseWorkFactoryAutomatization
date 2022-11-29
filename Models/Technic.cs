namespace CourseWorkFactoryAutomatization.Models
{
    public class Technic
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Detail> Details { get; set; }
    }
}
