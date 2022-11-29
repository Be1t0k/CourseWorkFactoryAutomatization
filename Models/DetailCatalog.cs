namespace CourseWorkFactoryAutomatization.Models
{
    public class DetailCatalog
    {
        public long Id { get; set; }
        public DateTime DateCreate { get; set; }
        public virtual ICollection<Accountant> Accountants { get; set; }
        public virtual ICollection<Detail> Details { get; set; }

    }
}
