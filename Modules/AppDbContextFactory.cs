using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_proyect.Modules
{

        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
                public AppDbContext CreateDbContext( string[] args ) {
                        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                        optionsBuilder.UseSqlServer("Server=WILDESK\\SQLEXPRESS;Database=p_proyect;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");

                        return new AppDbContext(optionsBuilder.Options);
                }
        }
}
