namespace CSharp_prospect
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        public Model1(): base("name=EFCodeFirst")
        { }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}