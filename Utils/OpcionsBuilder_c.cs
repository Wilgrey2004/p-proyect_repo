using Microsoft.EntityFrameworkCore;
using p_proyect.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_proyect.Utils
{
        public class OpcionsBuilder_c
        {
                public static DbContextOptionsBuilder<AppDbContext> getConnection() {
                        
                        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                        optionsBuilder.UseSqlServer("Server=WILDESK\\SQLEXPRESS;Database=p_proyect;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");


                        return optionsBuilder;
                }
                
        }
}
