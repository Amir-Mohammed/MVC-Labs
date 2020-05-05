using ITI.UI40Smart.MVC.Day02.Models.Entities;

namespace ITI.UI40Smart.MVC.Day02.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}