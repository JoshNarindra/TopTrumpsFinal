using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TopTrumpsFinal.Models;

namespace TopTrumpsFinal.Data
{
    public class TopTrumpsFinalContext : DbContext
    {
        public TopTrumpsFinalContext (DbContextOptions<TopTrumpsFinalContext> options)
            : base(options)
        {
        }

        public DbSet<TopTrumpsFinal.Models.CatDeck> CatDeck { get; set; } = default!;

        public DbSet<TopTrumpsFinal.Models.DinoDeck> DinoDeck { get; set; }

        public DbSet<TopTrumpsFinal.Models.DogDeck> DogDeck { get; set; }

        public DbSet<TopTrumpsFinal.Models.StarWarsDeck> StarWarsDeck { get; set; }
    }
}
