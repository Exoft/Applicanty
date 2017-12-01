using Applicant.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;


public class Program
{
    public static void Main(string[] args)
    {

    }

    public class AtsDbContextFactory : IDesignTimeDbContextFactory<AtsDbContext>
    {
        public AtsDbContext Create(DbContextFactoryOptions options)
        {
            //
            // this is only used for data migrations and db updates; the connection
            // string is not used for production
            //

            var optionsBuilder = new DbContextOptionsBuilder<AtsDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AtsDb;Trusted_Connection=True;");

            return new AtsDbContext(optionsBuilder.Options);
        }

        public AtsDbContext CreateDbContext(string[] args)
        {
            throw new System.NotImplementedException();
        }

    
    }
}