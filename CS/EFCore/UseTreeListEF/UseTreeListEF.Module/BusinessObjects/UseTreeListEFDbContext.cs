using DevExpress.ExpressApp.EFCore.Updating;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.ExpressApp.Design;
using DevExpress.ExpressApp.EFCore.DesignTime;
using HowToUseTreeListEditor.Module;

namespace UseTreeListEF.Module.BusinessObjects;

// This code allows our Model Editor to get relevant EF Core metadata at design time.
// For details, please refer to https://supportcenter.devexpress.com/ticket/details/t933891.
public class UseTreeListEFContextInitializer : DbContextTypesInfoInitializerBase {
	protected override DbContext CreateDbContext() {
		var optionsBuilder = new DbContextOptionsBuilder<UseTreeListEFEFCoreDbContext>()
            .UseSqlServer(";")
            .UseChangeTrackingProxies()
            .UseObjectSpaceLinkProxies();
        return new UseTreeListEFEFCoreDbContext(optionsBuilder.Options);
	}
}
//This factory creates DbContext for design-time services. For example, it is required for database migration.
public class UseTreeListEFDesignTimeDbContextFactory : IDesignTimeDbContextFactory<UseTreeListEFEFCoreDbContext> {
	public UseTreeListEFEFCoreDbContext CreateDbContext(string[] args) {
		throw new InvalidOperationException("Make sure that the database connection string and connection provider are correct. After that, uncomment the code below and remove this exception.");
		//var optionsBuilder = new DbContextOptionsBuilder<UseTreeListEFEFCoreDbContext>();
		//optionsBuilder.UseSqlServer("Integrated Security=SSPI;Pooling=false;Data Source=(localdb)\\mssqllocaldb;Initial Catalog=UseTreeListEF");
        //optionsBuilder.UseChangeTrackingProxies();
        //optionsBuilder.UseObjectSpaceLinkProxies();
		//return new UseTreeListEFEFCoreDbContext(optionsBuilder.Options);
	}
}
[TypesInfoInitializer(typeof(UseTreeListEFContextInitializer))]
public class UseTreeListEFEFCoreDbContext : DbContext {
	public UseTreeListEFEFCoreDbContext(DbContextOptions<UseTreeListEFEFCoreDbContext> options) : base(options) {
	}
	public DbSet<Category> Categories { get; set; }
	public DbSet<CategoryWithIssues> CategoryWithIssues { get; set; }
	public DbSet<ProjectGroupWithIssues> ProjectGroupWithIssues { get; set; }
	public DbSet<ProjectWithIssues> ProjectWithIssues { get; set; }
	public DbSet<ProjectAreaWithIssues> ProjectAreaWithIssues { get; set; }
	public DbSet<Issue> Issues { get; set; }
	public DbSet<Project> Projects { get; set; }
	public DbSet<ProjectArea> ProjectAreas { get; set; }
	public DbSet<ProjectGroup> ProjectGroups { get; set; }
	public DbSet<HCategory> HCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangingAndChangedNotificationsWithOriginalValues);
    }
}
