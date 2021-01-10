using DomainUsage.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticleCommands.WebAPI.Database
{
    public class FrontierContext : DbContext
    {
        public FrontierContext(DbContextOptions<FrontierContext> options) : base(options)
        { }

        //public DbSet<ArticleCategory> ArticleCategories { get; set; }
        //public DbSet<Article> Articles { get; set; }
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("B2C_Customer", "b2c");
            modelBuilder.Entity<Customer>()
                .Property(t => t.CustomerId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Customer>().HasKey(t => new { t.CustomerId });
            modelBuilder.Entity<Customer>().Property(t => t.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("First_Name")
                .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Customer>().Property(t => t.MiddleName)
                 .HasColumnName("Middle_Name")
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Customer>().Property(t => t.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Last_Name")
                .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Customer>().Property(t => t.DateOfBirth)
                .IsRequired()
                .HasColumnName("Date_of_Birth")
                .HasColumnType("datetime");
            modelBuilder.Entity<Customer>().Property(t => t.Occupation)
                .HasMaxLength(20)
                .HasColumnName("Occupation")
                .HasColumnType("nvarchar(20)");
            modelBuilder.Entity<Customer>().Property(t => t.ImmigrationStatus)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("Citizenship_Status")
                .HasColumnType("nvarchar(10)");
            modelBuilder.Entity<Customer>().Property(t => t.Salary)
                .HasColumnName("Salary")
                .HasColumnType("decimal (18,2)");
            modelBuilder.Entity<Customer>().Property(t => t.LoyaltyEnrolled)
                .HasColumnName("Loyalty_Member")
                .HasColumnType("bit");
            modelBuilder.Entity<Customer>().Property(t => t.CreditRating)
                .HasColumnName("Credit_Score")
                .HasColumnType("int");
            modelBuilder.Entity<Customer>().Property(t => t.DateCreated)
                .HasColumnName("Date_Created")
                .HasColumnType("datetime");
            modelBuilder.Entity<Customer>().Property(t => t.DateModified)
                .HasColumnName("Date_Modified")
                .HasColumnType("datetime");
            modelBuilder.Entity<Customer>().Property(t => t.ModifiedBy)
              .HasMaxLength(50)
              .HasColumnName("Modified_By")
              .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Customer>().Property(t => t.CreatedBy)
              .HasMaxLength(50)
              .HasColumnName("Created_By")
              .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Customer>().Property(t => t.PhoneNumber)
              .HasMaxLength(10)
              .HasColumnName("Phone_Number")
              .HasColumnType("nvarchar(10)");
            modelBuilder.Entity<Customer>().Property(t => t.EmailAddress)
              .HasMaxLength(50)
              .HasColumnName("Email_Address")
              .HasColumnType("nvarchar(50)");

            //modelBuilder.Entity<Customer>().Property(p => p.Photo).HasColumnType("image");
            // modelBuilder.Entity<Customer>().Ignore(t => t.Photo);

            //modelBuilder.Entity<Article>(entity =>
            //{
            //    entity.Property(e => e.Title).IsRequired();
            //    entity.HasIndex(e => new { e.ArticleId })
            //    .IsUnique()
            //    .IsClustered(false);
            //});

            #region student and course

            modelBuilder.Entity<Student>()
                 .ToTable("EDU_Student", "edu");
            modelBuilder.Entity<Student>()
            .Property(t => t.StudentId)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Student>().HasKey(t => new { t.StudentId });
            modelBuilder.Entity<Student>().Property(t => t.FirstName)
               .HasMaxLength(50)
               .IsRequired()
               .HasColumnName("First_Name")
               .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Student>().Property(t => t.MiddleName)
                 .HasColumnName("Middle_Name")
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Student>().Property(t => t.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("Last_Name")
                .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Student>().Property(t => t.DateOfBirth)
                .IsRequired()
                .HasColumnName("Date_of_Birth")
                .HasColumnType("datetime");

            modelBuilder.Entity<Course>()
              .ToTable("EDU_Course", "edu");
            modelBuilder.Entity<Course>()
            .Property(t => t.CourseId)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Course>().HasKey(t => new { t.CourseId });
            modelBuilder.Entity<Course>().Property(t => t.CourseName)
               .HasMaxLength(50)
               .IsRequired()
               .HasColumnName("Course_Name")
               .HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Course>().Property(t => t.CourseNumber)
                 .HasColumnName("Course_Number")
                .HasMaxLength(4)
                .IsRequired()
                .HasColumnType("nvarchar(4)");
            modelBuilder.Entity<Course>().Property(t => t.CourseDescription)
                .HasMaxLength(1024)
                .IsRequired()
                .HasColumnName("Course_Description")
                .HasColumnType("nvarchar(1024)");

            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.Courses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(s => s.Students)
                .HasForeignKey(sc => sc.CourseId);

            #endregion student and course

            #region identity sequence

            //
           // modelBuilder.Entity<Student>()
           //     .Property(o => o.StudentId)
           //     .HasDefaultValueSql("NEXT VALUE FOR NationalIndentificationNumber");

           // modelBuilder.Entity<Course>()
           //.Property(o => o.CourseId)
           //.HasDefaultValueSql("NEXT VALUE FOR NationalIndentificationNumber");

            //
            modelBuilder.Entity<Person>()
                .Property(o => o.PersonId)
                .HasDefaultValueSql("NEXT VALUE FOR NationalIndentificationSequence");

            //modelBuilder.HasSequence<int>("OrderNumbers");
            modelBuilder.HasSequence<int>("NationalIndentificationSequence")
                .StartsAt(1010101)
                .IncrementsBy(137);

            #endregion identity sequence
        }
    }
}