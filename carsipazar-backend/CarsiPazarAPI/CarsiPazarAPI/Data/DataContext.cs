﻿using CarsiPazarAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsiPazarAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<City> Cities { get; set; }
        //public DbSet<Photo> Photos { get; set; }
    }
}
