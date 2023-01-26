using Microsoft.EntityFrameworkCore;
using Invoice.API.Models;
using Invoice.Models;
namespace Invoice.API.Controllers;

public static class MerchantEndpoints
{
    public static void MapMerchantEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Merchant", async (AppDbContext db) =>
        {
            return await db.Merchants.ToListAsync();
        })
        .WithName("GetAllMerchants");

        routes.MapGet("/api/Merchant/{id}", async (int UniqueId, AppDbContext db) =>
        {
            return await db.Merchants.FindAsync(UniqueId)
                is Merchant model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetMerchantById");

        routes.MapPut("/api/Merchant/{id}", async (int UniqueId, Merchant merchant, AppDbContext db) =>
        {
            var foundModel = await db.Merchants.FindAsync(UniqueId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(merchant);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateMerchant");

        routes.MapPost("/api/Merchant/", async (Merchant merchant, AppDbContext db) =>
        {
            db.Merchants.Add(merchant);
            await db.SaveChangesAsync();
            return Results.Created($"/Merchants/{merchant.UniqueId}", merchant);
        })
        .WithName("CreateMerchant");

        routes.MapDelete("/api/Merchant/{id}", async (int UniqueId, AppDbContext db) =>
        {
            if (await db.Merchants.FindAsync(UniqueId) is Merchant merchant)
            {
                db.Merchants.Remove(merchant);
                await db.SaveChangesAsync();
                return Results.Ok(merchant);
            }

            return Results.NotFound();
        })
        .WithName("DeleteMerchant");
    }
}
