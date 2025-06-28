markdown

Scaffold-DbContext "Server=.;Database=DotNetTrainingBatch2;User ID=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir AppDbContextModels -Context AppDbContext

dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch2;User ID=sa;Password=sasa@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o App2DbContextModels -c App2DbContext -f