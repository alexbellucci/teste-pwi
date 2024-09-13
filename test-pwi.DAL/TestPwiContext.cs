using Microsoft.EntityFrameworkCore;
using test_pwi.DL.DB;

namespace test_pwi.DAL
{
    public partial class TestPwiContext : DbContext
    {
        public TestPwiContext()
        {
        }

        public TestPwiContext(DbContextOptions<TestPwiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TodoItem> TodoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:AZURE_SQL_CONNECTIONSTRING");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TodoItem>(entity =>
            {
                entity.ToTable("TodoItem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql("GETUTCDATE()")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DataConclusao)
                    .HasColumnType("datetime2")
                    .IsRequired(false);

                entity.Property(e => e.Concluido)
                    .IsRequired();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
