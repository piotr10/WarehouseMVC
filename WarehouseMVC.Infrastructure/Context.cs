using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WarehouseMVC.Domain.Model;

namespace WarehouseMVC.Infrastructure
{
    public class Context : IdentityDbContext // klasa Context jest to klasa, która wskazuje na to, które klasy defakto zostaną utworzone w bazie danych jako Tabele
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; } //relacja jeden do jednego z tabelą ContactDetailTypes
        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerContactInformation> CustomerContactInformations { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<ApplyCountImageModel> ApplyCountImageModels { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<GroupLeader> GroupLeaders { get; set; }
        public DbSet<GroupManager> GroupManagers { get; set; }


        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder) // metoda szegółowej konfiguracji relacji z wykorzystaniem FluentApi
        {
            base.OnModelCreating(builder);

            //Relations One to One

            builder.Entity<Customer>()
                .HasOne(a => a.CustomerContactInformation).WithOne(b => b.Customer)
                .HasForeignKey<CustomerContactInformation>(e => e.CustomerRef);

            #region Relations Many to Many
            /*
            //Relations Many to Many

            builder.Entity<ItemTag>()
                .HasKey(it => new {it.ItemId, it.TagId});

            builder.Entity<ItemTag>()
                .HasOne<Item>(it => it.Item)
                .WithMany(i => i.ItemTags)
                .HasForeignKey(it => it.ItemId);

            builder.Entity<ItemTag>()
                .HasOne<Tag>(it => it.Tag)
                .WithMany(t => t.ItemTags)
                .HasForeignKey(it => it.TagId);
            */
            #endregion
        }
    }
}