using Microsoft.EntityFrameworkCore;
using Invoice.API.Models;
using Invoice.Models;
namespace Invoice.API.Controllers;

public static class BankAccount
{
    public static void MapBankAccountInfoEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/BankAccountInfo", async (AppDbContext db) =>
        {
            return await db.BankAccountInfos.ToListAsync();
        })
        .WithName("GetAllBankAccountInfos");

        routes.MapGet("/api/BankAccountInfo/{id}", async (int UniqueId, AppDbContext db) =>
        {
            return await db.BankAccountInfos.FindAsync(UniqueId)
                is BankAccountInfo model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetBankAccountInfoById");

        routes.MapPut("/api/BankAccountInfo/{id}", async (int UniqueId, BankAccountInfo bankAccountInfo, AppDbContext db) =>
        {
            var foundModel = await db.BankAccountInfos.FindAsync(UniqueId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(bankAccountInfo);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateBankAccountInfo");

        routes.MapPost("/api/BankAccountInfo/", async (BankAccountInfo bankAccountInfo, AppDbContext db) =>
        {
            db.BankAccountInfos.Add(bankAccountInfo);
            await db.SaveChangesAsync();
            return Results.Created($"/BankAccountInfos/{bankAccountInfo.UniqueId}", bankAccountInfo);
        })
        .WithName("CreateBankAccountInfo");

        routes.MapDelete("/api/BankAccountInfo/{id}", async (int UniqueId, AppDbContext db) =>
        {
            if (await db.BankAccountInfos.FindAsync(UniqueId) is BankAccountInfo bankAccountInfo)
            {
                db.BankAccountInfos.Remove(bankAccountInfo);
                await db.SaveChangesAsync();
                return Results.Ok(bankAccountInfo);
            }

            return Results.NotFound();
        })
        .WithName("DeleteBankAccountInfo");
    }
}
