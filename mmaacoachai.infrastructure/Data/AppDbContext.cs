using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using mmacoachai.core.Entities;
using System;

namespace mmacoachai.infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) { 

        }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<SkillRating> SkillRatings { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
    }
}
