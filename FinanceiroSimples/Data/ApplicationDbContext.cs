using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroSimples.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
   
        


        public DbSet<FinanceiroSimples.Models.Lançamento> Lançamento { get; set; }

    }
}
