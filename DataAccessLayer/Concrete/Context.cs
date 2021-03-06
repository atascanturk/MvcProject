

using EntityLayer.Concrete;
using System.Data.Entity;

namespace DataAccessLayer.Concrete
{
   public class Context :DbContext
    {
        public Context()
        {
            //Database.SetInitializer<Context>(null);
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<MySkill> MySkills { get; set; }

    }
}
