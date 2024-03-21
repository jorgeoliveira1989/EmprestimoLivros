using EmprestimoLivros.Models;
using Microsoft.EntityFrameworkCore;


namespace EmprestimoLivros.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {    
        }

        //local onde se adiciona quantas tabelas quiser para aparecer no sqlserver
        public DbSet<EmprestimosModel> Emprestimos { get; set; }


    }
}
