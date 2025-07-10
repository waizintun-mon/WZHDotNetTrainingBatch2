markdown

Scaffold-DbContext "Server=.;Database=DotNetTrainingBatch2MiniPos;User ID=sa;Password=sa@@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir AppDbContextModels -Context AppDbContext

dotnet ef dbcontext scaffold "Server=.;Database=DotNetTrainingBatch2MiniPos;User ID=sa;Password=sa@@123;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f