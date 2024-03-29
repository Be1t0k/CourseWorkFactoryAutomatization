﻿using Microsoft.EntityFrameworkCore;

namespace CourseWorkFactoryAutomatization.Models
{
    public class CourseWorkContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Accountant> Accountants { get; set; }
        public DbSet<SuperVisor> SuperVisors { get; set; }
        public DbSet<UserCatalog> UserCatalogs { get; set; }
        public DbSet<TechnicManual> TechnicManuals { get; set; }
        public DbSet<DetailCatalog> DetailCatalogs { get; set; }
        public DbSet<Technic> Technics { get; set; }
        public DbSet<Detail> Details { get; set; }
        public CourseWorkContext(DbContextOptions<CourseWorkContext> options) : base(options)
        {

        }

    }
}


