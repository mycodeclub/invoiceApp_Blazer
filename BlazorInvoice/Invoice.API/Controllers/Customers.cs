using Microsoft.EntityFrameworkCore;
using Invoice.API.Models;
using Invoice.Models;
namespace Invoice.API.Controllers;

public static class Customers
{
    public static void MapCustomerEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Customer", async (AppDbContext db) =>
        {
            return await db.Customers.ToListAsync();
        })
        .WithName("GetAllCustomers")
        .Produces<List<Customer>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Customer/{id}", async (int UniqueId, AppDbContext db) =>
        {
            return await db.Customers.FindAsync(UniqueId)
                is Customer model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCustomerById")
        .Produces<Customer>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Customer/{id}", async (int UniqueId, Customer customer, AppDbContext db) =>
        {
            var foundModel = await db.Customers.FindAsync(UniqueId);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            
            db.Update(customer);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateCustomer")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Customer/", async (Customer customer, AppDbContext db) =>
        {
            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return Results.Created($"/Customers/{customer.UniqueId}", customer);
        })
        .WithName("CreateCustomer")
        .Produces<Customer>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Customer/{id}", async (int UniqueId, AppDbContext db) =>
        {
            if (await db.Customers.FindAsync(UniqueId) is Customer customer)
            {
                db.Customers.Remove(customer);
                await db.SaveChangesAsync();
                return Results.Ok(customer);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCustomer")
        .Produces<Customer>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
