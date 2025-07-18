using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using p_proyect.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace p_proyect
{
        internal static class Program
        {
                /// <summary>
                /// Punto de entrada principal para la aplicación.
                /// </summary>
                [STAThread]
                static void Main() {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                       // var connectionString = ConfigurationManager.ConnectionStrings["p_proyect_c"].ConnectionString;
                        //esta es la parte del DbContext
                        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                        optionsBuilder.UseSqlServer("Server=WILDESK\\SQLEXPRESS;Database=p_proyect;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");

                        try
                        {
                                using (var context = new AppDbContext(optionsBuilder.Options))
                                {
                                        context.Database.EnsureCreated();
                                }
                                
                        } catch(Exception ex)
                        {
                                MessageBox.Show(ex.Message);
                        }

                        //Aqui termina el DbContext

                        Application.Run(new Inicio_De_Secion());
                }
        }
}
