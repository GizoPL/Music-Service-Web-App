using Microsoft.EntityFrameworkCore;
using MyFirstWebApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Repository
{
    public class MusicContext : DbContext 
    {
        public  MusicContext(DbContextOptions<MusicContext> opt) : base(opt){ }
        public  DbSet<Supplier> Suppliers { get; set; }
        public  DbSet<Album> Albums { get; set; }
        public  DbSet<Track> Tracks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
    }
}
