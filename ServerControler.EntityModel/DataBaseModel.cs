namespace ServerControler.EntityModel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataBaseModel : DbContext
    {
        public DataBaseModel()
            : base("name=DataBaseModel")
        {
        }
        public DbSet<Test> Tests { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
    public class Test
    {
        public int TestId { get; set; }
        public string Name { get; set; }
    }
}
