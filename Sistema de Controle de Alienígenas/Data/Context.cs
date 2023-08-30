using Microsoft.EntityFrameworkCore;

namespace Sistema_de_Controle_de_Alienígenas.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
    }
}
