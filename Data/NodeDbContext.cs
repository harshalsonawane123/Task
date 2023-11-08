using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class NodeDbContext : DbContext
    {
        public NodeDbContext(DbContextOptions<NodeDbContext> options) : base(options)
        {
        }

        public DbSet<Node> Nodes { get; set; }
    }
}

