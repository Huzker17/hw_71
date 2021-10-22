using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<User> ContextUser { get; set; }
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<WorkExp> Works { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
