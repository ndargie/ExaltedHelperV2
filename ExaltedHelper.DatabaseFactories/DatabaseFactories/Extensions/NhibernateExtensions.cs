using System;
using System.Collections.Generic;
using System.Reflection;
using NHibernate.Cfg;
using NHibernate.Mapping;
using NHibernate.Tool.hbm2ddl;

namespace ExaltedHelper.DatabaseFactories.DatabaseFactories.Extensions
{
    public static class NhibernateExtensions
    {
        #region Static Fields

        /// <summary>
        ///     The table mappings property.
        /// </summary>
        private static readonly PropertyInfo TableMappingsProperty = typeof(Configuration).GetProperty(
            "TableMappings", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        #endregion

        #region Public Methods and Operators


        public static bool RecreateSchema()
        {
            try
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Check if Database Schema is still valid. If not update it.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <param name="reCreate"></param>
        public static void BuildSchema(this Configuration configuration, bool reCreate)
        {
            if (reCreate)
            {
                DropCreateSchema(configuration);
                return;
            }

            if (!ValidateSchema(configuration))
            {
                UpdateSchema(configuration);
            }
        }

        /// <summary>
        /// Automatic create Indexes on foreign Keys.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public static void CreateIndexesForForeignKeys(this Configuration configuration)
        {
            configuration.BuildMappings();
            var tables = (ICollection<Table>)TableMappingsProperty.GetValue(configuration, null);
            foreach (var table in tables)
            {
                foreach (var foreignKey in table.ForeignKeyIterator)
                {
                    var idx = new Index();
                    idx.AddColumns(foreignKey.ColumnIterator);
                    idx.Name = "FKey_" + foreignKey.ReferencedTable.Name;
                    idx.Table = table;
                    table.AddIndex(idx);
                }
            }
        }

        /// <summary>
        /// Update the Database Schema
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        public static void UpdateSchema(this Configuration configuration)
        {
            // configuration.CreateIndexesForForeignKeys();
            var schema = new SchemaUpdate(configuration);
            schema.Execute(false, true);
        }

        public static void DropCreateSchema(this Configuration configuration)
        {
            var exporter = new SchemaExport(configuration);
            exporter.Drop(false, true);
            exporter.Create(false, true);
        }

        /// <summary>
        /// Validate the Database Schema.
        /// </summary>
        /// <param name="configuration">
        /// The configuration.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool ValidateSchema(this Configuration configuration)
        {
            var myvalidator = new SchemaValidator(configuration);
            try
            {
                myvalidator.Validate();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}