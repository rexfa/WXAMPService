using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Pomelo.EntityFrameworkCore;
using WXAMPService.EF.Domain;
using System.Reflection;
using System;

namespace WXAMPService.EF
{
    public class MysqlContext : DbContext
    {
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }
        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseMySql(@"Server=mysql.rex.me;database=rex;uid=root;pwd=");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var typesToRegister = GetType().GetTypeInfo().Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType))
                .Where(z => { return z.GetInterfaces().Where(q => q.Name.Contains("IEntityTypeConfigura")).Count() > 0 ? true : false; })
                .ToArray();
            var entityMethod = typeof(ModelBuilder).GetMethods().Single(x => x.Name == "Entity" &&
                         x.IsGenericMethod &&
                         x.ReturnType.Name == "EntityTypeBuilder`1");
            foreach (var mappingType in typesToRegister)
            {
                var genericTypeArg = mappingType.GetInterfaces().Single().GenericTypeArguments.Single();
                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArg);
                var entityBuilder = genericEntityMethod.Invoke(modelBuilder, null);

                dynamic configurationInstance = Activator.CreateInstance(mappingType);
                configurationInstance.GetType().GetMethod("Configure").Invoke(configurationInstance, new[] { entityBuilder });
                //modelBuilder.ApplyConfiguration(configurationInstance);
            }
            //删除动作在 mapping里做设置了，这里不统一强调
            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

        }
        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
            if (alreadyAttached == null)
            {
                Set<TEntity>().Attach(entity);
                return entity;
            }
            else
            {
                return alreadyAttached;
            }
        }
        //public void execmd()
        //{
        //    this.Database.ExecuteSqlCommand
        //}
    }
}
