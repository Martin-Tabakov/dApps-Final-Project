using Meeting_Room_Booking.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Meeting_Room_Booking.Database
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        DbSet<Meet> Meets { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<BoardRoom> BoardRooms { get; set; }

        public static void Seed(IServiceProvider applicationServices)
        {
            using (IServiceScope serviceScope = applicationServices.CreateScope())
            {
                DatabaseContext context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();

                if (context.Database.EnsureCreated())
                {
                    PasswordHasher<User> hasher = new();
                    User admin = new()
                    {
                        Id = Guid.NewGuid().ToString("D"),
                        Email = "admin@test.test",
                        NormalizedEmail = "admin@test.test".ToUpper(),
                        EmailConfirmed = true,
                        UserName = "admin@test.test",
                        NormalizedUserName = "admin@test.test".ToUpper(),
                        SecurityStamp = Guid.NewGuid().ToString("D")
                    };

                    admin.PasswordHash = hasher.HashPassword(admin, "adminpass");
                    context.Users.Add(admin);
                    context.SaveChanges();
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Meet>().HasOne(m => m.BoardRoom);
            builder.Entity<Meet>().HasMany(m => m.Participants);
        }
    }
}
