namespace CourseWorkFactoryAutomatization.Models
{
    public class UserCatalog
    {
        public int Id { get; set; }
        public virtual ICollection<Admin> Admins { get; set; }
    }
}
