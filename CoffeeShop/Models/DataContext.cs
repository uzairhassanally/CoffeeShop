using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoffeeShop.Models
{
    public class DataContext : DbContext
    {


        public DbSet<Cart> Carts { get; set; }
        public DbSet<WorkFlow> WorkFlow  { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public DbSet<CustomerRegister> CustomerRegisters { get; set; }

        public DbSet<EmployeeRegister> EmployeeRegisters { get; set; }
        public DbSet<AdminRegister> AdminRegisters { get; set; }

       

        public System.Data.Entity.DbSet<ArticlesComment> ArticlesComments { get; set; }

        public System.Data.Entity.DbSet<Article> Articles { get; set; }

      

        public System.Data.Entity.DbSet<Scheduler> Schedulers { get; set; }

        public System.Data.Entity.DbSet<CoffeeShop.Models.TaskDescription> TaskDescriptions { get; set; }

        public System.Data.Entity.DbSet<CoffeeShop.Models.Updates> Updates { get; set; }
    }
}