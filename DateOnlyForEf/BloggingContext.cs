using Microsoft.EntityFrameworkCore;

namespace DateOnlyForEf
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=192.168.1.37\sql2019;Initial Catalog=DateOnly;User Id=user1; Password=123456;");
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");

            builder.Properties<DateOnly?>()
                .HaveConversion<NullableDateOnlyConverter>()
                .HaveColumnType("date");


            builder.Properties<TimeOnly>()
              .HaveConversion<TimeOnlyConverter>()
              .HaveColumnType("time");

            builder.Properties<TimeOnly?>()
                .HaveConversion<NullableTimeOnlyConverter>()
                .HaveColumnType("time");
        }
    }
}
