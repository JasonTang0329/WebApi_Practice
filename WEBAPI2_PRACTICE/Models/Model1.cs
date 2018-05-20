namespace WEBAPI2_PRACTICE.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DatabaseEntities")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Model1>());

            this.Configuration.ProxyCreationEnabled = false;
        }
        /// <summary>
        /// �ɮ�
        /// </summary>
        public virtual DbSet<KM_file> KM_file { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual DbSet<KM_file_Annotation> KM_file_Annotation { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public virtual DbSet<KM_file_Comments> KM_file_Comments { get; set; }
        /// <summary>
        /// ����r
        /// </summary>
        public virtual DbSet<KM_file_Keywords> KM_file_Keywords { get; set; }
        //public virtual DbSet<KM_file_Temp_Path> KM_file_Temp_Path { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KM_file>()
                .Property(e => e.file_type)
                .IsUnicode(false);

            modelBuilder.Entity<KM_file>()
                .Property(e => e.Link)
                .IsUnicode(false);

            modelBuilder.Entity<KM_file>()
                .HasMany(e => e.KM_file_Annotation)
                .WithRequired(e => e.KM_file)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KM_file>()
                .HasMany(e => e.KM_file_Comments)
                .WithRequired(e => e.KM_file)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KM_file>()
                .HasMany(e => e.KM_file_Keywords)
                .WithRequired(e => e.KM_file)
                .WillCascadeOnDelete(false);
        }
    }
}
