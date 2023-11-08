using AppliVacationProject.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace AppliVacationProject.DataAccess.Data
{
    public class AppliVacationDbContext : DbContext
    {
        public DbSet<Users> TUsers { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<VacationBalances> VacationBalances { get; set; }
        public DbSet<VacationCalendar> VacationCalendars { get; set; }

        public AppliVacationDbContext()
        {            

        }
        public AppliVacationDbContext(DbContextOptions<DbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TI79MHJ\\INFI-9;Database=AppliVacation;Trusted_Connection=True;encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Modelisation de l'entité Users
            modelBuilder.Entity<Users>() 
                .HasKey(u => u.UsersId); // Définir la clé primaire

            modelBuilder.Entity<Users>()
                .Property(u => u.CreatedDate)
                .HasColumnType("text");

            modelBuilder.Entity<Users>()
                .HasOne(u => u.Role) // un utilisateur à un seule role
                .WithMany(r => r.Users) // Un role peut etre associé à plusieurs utilisateurs qui correspond ici à Users
                .HasForeignKey(u => u.RoleId); // La clé étrangère dans Users est RoleId

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => ur.RoleId);

            modelBuilder.Entity<UserRole>()
                .Property(ur => ur.RoleName);

            modelBuilder.Entity<UserRole>()
                .HasMany(ur => ur.Users) 
                .WithOne(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);
            
            //// Configuration de l'entité vacation
            
            modelBuilder.Entity<Vacation>()
                .HasKey(v => v.VacationId);

            modelBuilder.Entity<Vacation>()
                .HasOne(v => v.Users)
                .WithMany(u => u.Vacations)
                .HasForeignKey(v => v.UsersId);
                
                

            modelBuilder.Entity<VacationBalances>()
                .HasKey(vb => vb.VacationBalancesID);


            modelBuilder.Entity<VacationCalendar>()
                .HasKey(vc => vc.VacationCalendarId);
        }
    }
}
