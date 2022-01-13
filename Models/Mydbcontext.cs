using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace InventoryApplication.Models
{
    public class Mydbcontext: DbContext
    {
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        }
    }
