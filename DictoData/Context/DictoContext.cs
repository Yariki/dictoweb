﻿using DictoData.Model;
using Microsoft.EntityFrameworkCore;

namespace DictoData.Context
{
    public class DictoContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Word> Words { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<SuperMemory> SuperMemories { get; set; }

        public DbSet<Translate> Translates { get; set; }

        public DbSet<Transcription> Transcriptions { get; set; }

        public DbSet<Deck> Decks { get; set; }

        public DictoContext(DbContextOptions opt): base(opt)
        {   
        }
        
    }
}