namespace CourseWorkFactoryAutomatization.Models
{
    public class UserCatalog
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }    
        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
