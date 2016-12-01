using System.Data.Entity;

namespace LookupDataSample.ModelFive
{
    public class ModelFiveContext : DbContext
    {
        public DbSet<Feature> Features { get; set; }
        public DbSet<Style> Styles { get; set; }

        public ModelFiveContext():base("DefaultContext")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Feature>()
                .HasMany<Style>(f => f.Styles)
                .WithMany()
                .Map(fs =>
                {
                    fs.MapLeftKey("FeatureId");
                    fs.MapRightKey("StyleId");
                    fs.ToTable("FeatureStyle");
                });

        }
    }
}