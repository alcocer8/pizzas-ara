/* Dependecies */
Npgsql.EntityFrameworkCore.PostgreSQL
Microsoft.EntityFrameworkCore.Design -v 6.0.2

/* Scalfold */
dotnet ef dbcontext scaffold "Host=localhost;Database=pizzitas;Username=lorenzo;Password=1234" Npgsql.EntityFrameworkCore.PostgreSQL -o Models/entities/

