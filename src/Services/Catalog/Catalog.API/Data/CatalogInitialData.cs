using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync(cancellation)) return;
        
        // Marten UPSERT will carter for existing records
        session.Store(GetPreconfiguredProducts());
        await session.SaveChangesAsync(cancellation);
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => // new List<Product> { }
    [
        new()
        {
            Id = new Guid("5334c996-8457-4cf0-815c-ed2b77c4ff61"),
            Name = "Iphone X",
            Description = "This phone is the company's biggest change to its flagship smartphone",
            ImageFile = "product-1.png",
            Price = 950.00M,
            Category = new List<string> { "Smart Phone" }
        },

        new()
        {
            Id = new Guid("c67d6323-e8b1-4bdf-9a75-b0d0d2e7e914"),
            Name = "Samsung Galaxy S23",
            Description = "Experience the power of Galaxy with advanced camera and performance",
            ImageFile = "product-2.png",
            Price = 899.00M,
            Category = ["Smart Phone"]
        },

        new()
        {
            Id = new Guid("4f136e9f-ff8c-4c1f-9a33-d12f689bdab8"),
            Name = "MacBook Pro 16",
            Description = "The most powerful MacBook Pro ever with M3 chip",
            ImageFile = "product-3.png",
            Price = 2499.00M,
            Category = ["Laptop", "Electronics"]
        },

        new()
        {
            Id = new Guid("6ec1297b-ec0a-4aa1-be25-6726e3b51a27"),
            Name = "Sony WH-1000XM5",
            Description = "Industry-leading noise canceling wireless headphones",
            ImageFile = "product-4.png",
            Price = 399.00M,
            Category = ["Audio", "Electronics"]
        },

        new()
        {
            Id = new Guid("b786103d-c621-4f5a-b498-07d8c79e9d07"),
            Name = "iPad Air",
            Description = "Powerful, colorful, and versatile tablet for work and play",
            ImageFile = "product-5.png",
            Price = 599.00M,
            Category = ["Tablet", "Electronics"]
        },

        new()
        {
            Id = new Guid("3a0e6a5d-3b30-4c3e-8f88-7c5d8f9e0a1b"),
            Name = "Dell XPS 13",
            Description = "Ultra-portable laptop with stunning InfinityEdge display",
            ImageFile = "product-6.png",
            Price = 1299.00M,
            Category = ["Laptop", "Electronics"]
        },

        new()
        {
            Id = new Guid("f3c2d5e1-9a8b-4c7d-8e6f-5a4b3c2d1e0f"),
            Name = "Apple Watch Series 9",
            Description = "Advanced health and fitness tracking with beautiful design",
            ImageFile = "product-7.png",
            Price = 429.00M,
            Category = ["Wearable", "Electronics"]
        },

        new()
        {
            Id = new Guid("8d3e5f2a-1b4c-4d7e-9f8a-6b5c4d3e2f1a"),
            Name = "Samsung 55\" QLED TV",
            Description = "4K quantum dot technology with stunning picture quality",
            ImageFile = "product-8.png",
            Price = 1199.00M,
            Category = ["Television", "Electronics"]
        },

        new()
        {
            Id = new Guid("2b4d6f8a-3c5e-4f7a-8d9b-1e2f3a4b5c6d"),
            Name = "Logitech MX Master 3S",
            Description = "Advanced wireless mouse for productivity and precision",
            ImageFile = "product-9.png",
            Price = 99.00M,
            Category = ["Accessories", "Electronics"]
        },

        new()
        {
            Id = new Guid("9e5f7a3b-4d6c-4e8f-9a1b-2c3d4e5f6a7b"),
            Name = "Nintendo Switch OLED",
            Description = "Gaming console with vibrant OLED screen and versatile play modes",
            ImageFile = "product-10.png",
            Price = 349.00M,
            Category = ["Gaming", "Electronics"]
        },

        new()
        {
            Id = new Guid("7c4e6a2d-5f8b-4c9e-8d7a-3b4c5d6e7f8a"),
            Name = "Canon EOS R6",
            Description = "Full-frame mirrorless camera for professional photography",
            ImageFile = "product-11.png",
            Price = 2499.00M,
            Category = ["Camera", "Electronics"]
        }
    ];
}