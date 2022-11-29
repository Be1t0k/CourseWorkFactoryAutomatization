namespace CourseWorkFactoryAutomatization.Models
{
    public class Admin: User
    {
        public long IdCatalog { get; set; }
        public virtual UserCatalog UserCatalog { get; set; }
    }
}
