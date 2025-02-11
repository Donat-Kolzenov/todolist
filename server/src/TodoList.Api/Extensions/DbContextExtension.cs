﻿namespace TodoList.Api.Extensions
{
    using Microsoft.EntityFrameworkCore;

    using TodoList.Data.Contexts.ApplicationDb;

    public static class DbContextExtension
    {
        private const string ConnectionStringName = "DefaultConnection";

        public static void AddCustomSqliteContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration
                .GetConnectionString(ConnectionStringName);

            services.AddDbContext<ApplicationDbContext>(
                o => o.UseSqlite(connectionString));

            services.BuildServiceProvider()
                .GetService<ApplicationDbContext>()!
                .Database
                .Migrate();
        }
    }
}
