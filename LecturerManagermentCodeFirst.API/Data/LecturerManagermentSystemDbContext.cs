using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Data
{
    public class LecturerManagermentSystemDbContext : DbContext
    {
        public LecturerManagermentSystemDbContext()
        {

        }

        public LecturerManagermentSystemDbContext(DbContextOptions<LecturerManagermentSystemDbContext> options) 
            : base(options)
        {

        }
    }
}
