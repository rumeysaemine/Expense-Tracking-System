using ExpenseTracking.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTracking.Infrastructure;

public static class InitialDataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var adminId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var personelId = Guid.Parse("22222222-2222-2222-2222-222222222222");
        var category1Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
        var category2Id = Guid.Parse("44444444-4444-4444-4444-444444444444");

        // UTC olarak belirlenmiş DateTime
        var createdAt = new DateTime(2024, 01, 01, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = adminId,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@example.com",
                PasswordHash = "hashed_password",
                Role = UserRole.Admin,
                IBAN = "TR000000000000000000000000",
                CreatedAt = createdAt
            },
            new User
            {
                Id = personelId,
                FirstName = "Rumeysa",
                LastName = "Personel",
                Email = "remi@example.com",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "Personel123!"),
                Role = UserRole.Personel,
                IBAN = "TR111111111111111111111111",
                CreatedAt = createdAt
            }
        );

        modelBuilder.Entity<ExpenseCategory>().HasData(
            new ExpenseCategory { Id = category1Id, Name = "Yemek" },
            new ExpenseCategory { Id = category2Id, Name = "Ulaşım" }
        );
    }
}