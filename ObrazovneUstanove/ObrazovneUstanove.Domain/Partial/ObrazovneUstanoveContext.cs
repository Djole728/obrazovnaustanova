using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;

namespace ObrazovneUstanove.Domain
{
    public partial class ObrazovneUstanoveContext : DbContext
    {
        public enum AuditColumns
        {
            RadnikIdKreirao,
            DatumKreiranja,
            IsDeleted,
        }

        public override int SaveChanges()
        {
            var currentContext = System.Web.HttpContext.Current;
            //var korisnickoIme = currentContext.User.Identity.Name;
            var korisnickoIme = "KorisnickoIme";
           // if (currentContext.Cache[korisnickoIme] != null)
           if (korisnickoIme != null)
            {
                //var userCache = (UserCache)currentContext.Cache[korisnickoIme];
                var radnikIdKreirao = 1;               

                var datumKreiranja = DateTime.Now;
                // DELETE
                foreach (var entry in ChangeTracker.Entries().Where(p =>
                    p.State == EntityState.Deleted
                    && p.Entity.GetType().GetProperty(AuditColumns.IsDeleted.ToString()) != null))
                {
                    Type entryEntityType = entry.Entity.GetType();

                    string tableName = GetTableName(entryEntityType);
                    string primaryKeyName = GetPrimaryKeyName(entryEntityType);

                    string deletequery =
                        string.Format(
                            "UPDATE {0} SET {1} = {2}, {3} = '{4}', {5} = '{6}' WHERE {7} = @id",
                                tableName,
                                AuditColumns.IsDeleted.ToString(), 1,
                                AuditColumns.DatumKreiranja.ToString(), datumKreiranja.ToString("MM/dd/yyyy HH:mm:ss:fff"),
                                AuditColumns.RadnikIdKreirao.ToString(), radnikIdKreirao,
                                primaryKeyName);

                    Database.ExecuteSqlCommand(
                        deletequery,
                        new SqlParameter("@id", entry.OriginalValues[primaryKeyName]));

                    entry.State = EntityState.Detached;
                }

                // UPDATE
                foreach (var entry in ChangeTracker.Entries().Where(p => p.State == EntityState.Modified))
                {
                    var entryValues = entry.CurrentValues;
                    if (entryValues.PropertyNames.Contains(AuditColumns.RadnikIdKreirao.ToString()))
                    {
                        entryValues[AuditColumns.RadnikIdKreirao.ToString()] = radnikIdKreirao;
                    }

                    if (entryValues.PropertyNames.Contains(AuditColumns.DatumKreiranja.ToString()))
                    {
                        entryValues[AuditColumns.DatumKreiranja.ToString()] = datumKreiranja;
                    }
                }

                // insert
                foreach (var entry in ChangeTracker.Entries().Where(p => p.State == EntityState.Added))
                {
                    var entryValues = entry.CurrentValues;
                    if (entryValues.PropertyNames.Contains(AuditColumns.RadnikIdKreirao.ToString()))
                    {
                        entryValues[AuditColumns.RadnikIdKreirao.ToString()] = radnikIdKreirao;
                    }

                    if (entryValues.PropertyNames.Contains(AuditColumns.DatumKreiranja.ToString()))
                    {
                        entryValues[AuditColumns.DatumKreiranja.ToString()] = datumKreiranja;
                    }
                }
            }
            // in the end, call base to save changes
            return base.SaveChanges();
        }

        private static Dictionary<Type, EntitySetBase> _mappingCache = new Dictionary<Type, EntitySetBase>();

        private EntitySetBase GetEntitySet(Type type)
        {
            if (!_mappingCache.ContainsKey(type))
            {
                ObjectContext octx = ((IObjectContextAdapter)this).ObjectContext;

                string typeName = ObjectContext.GetObjectType(type).Name;

                var es = octx.MetadataWorkspace
                                .GetItemCollection(DataSpace.SSpace)
                                .GetItems<EntityContainer>()
                                .SelectMany(c => c.BaseEntitySets
                                                .Where(e => e.Name == typeName))
                                .FirstOrDefault();

                if (es == null)
                    throw new ArgumentException("Entity type not found in GetTableName", typeName);

                _mappingCache.Add(type, es);
            }

            return _mappingCache[type];
        }

        private string GetTableName(Type type)
        {
            EntitySetBase es = GetEntitySet(type);

            return string.Format("[{0}].[{1}]",
                es.MetadataProperties["Schema"].Value,
                es.MetadataProperties["Table"].Value);
        }

        private string GetPrimaryKeyName(Type type)
        {
            EntitySetBase es = GetEntitySet(type);

            return es.ElementType.KeyMembers[0].Name;
        }
    }
}
