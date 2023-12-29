using Microsoft.EntityFrameworkCore;

namespace APICrudServer.DATA
{
    public class ApiDataContext : DbContext
    {

        public ApiDataContext(DbContextOptions<ApiDataContext> options): base(options)
        {


        }

        public DbSet<Customer> Customers { get; set;}


    }
}
