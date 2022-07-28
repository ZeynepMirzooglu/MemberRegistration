using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberRegistration.DataAccess.Concrete.EntityFramework.Mappings;
using MemberRegistration.Entities.Concrete;

namespace MemberRegistration.DataAccess.Concrete.EntityFramework
{
    public class MemberShipContext:DbContext
    {
        public DbSet<Member> Members { get; set; }

        public MemberShipContext()
        {
            Database.SetInitializer<MemberShipContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MemberMap());
        }
    }
}
