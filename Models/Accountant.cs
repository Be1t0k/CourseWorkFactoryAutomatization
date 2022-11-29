namespace CourseWorkFactoryAutomatization.Models
{
    public class Accountant : User
    {
        public virtual ICollection<DetailCatalog> DetailCatalogs { get; set; }

    }
}
