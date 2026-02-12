namespace Ordering.Infrastructure.Data.Extensions;

public class InitialData
{
    public static IEnumerable<Customer> Customers =>
        new List<Customer>
        {
            Customer.Create(CustomerId.Of(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890")), "John", "john@gmail.com"),
            Customer.Create(CustomerId.Of(new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901")), "Sarah", "sarah@outlook.com"),
            Customer.Create(CustomerId.Of(new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012")), "Miguel", "miguel@yahoo.com"),
            Customer.Create(CustomerId.Of(new Guid("d4e5f6a7-b8c9-0123-def1-234567890123")), "Emma", "emma@hotmail.com"),
            Customer.Create(CustomerId.Of(new Guid("e5f6a7b8-c9d0-1234-ef12-345678901234")), "David", "david@gmail.com"),
        };

    public static IEnumerable<Product> Products =>
        new List<Product>
        {
            Product.Create(ProductId.Of(new Guid("f1a2b3c4-d5e6-7890-abcd-ef1234567890")), "iPhone X", 500.60M),
            Product.Create(ProductId.Of(new Guid("f2b3c4d5-e6f7-8901-bcde-f12345678901")), "Samsung Galaxy S21", 699.99M),
            Product.Create(ProductId.Of(new Guid("f3c4d5e6-f7a8-9012-cdef-123456789012")), "MacBook Pro", 1999.00M),
            Product.Create(ProductId.Of(new Guid("f4d5e6f7-a8b9-0123-def1-234567890123")), "Sony WH-1000XM4", 349.99M),
            Product.Create(ProductId.Of(new Guid("f5e6f7a8-b9c0-1234-ef12-345678901234")), "iPad Air", 599.00M),
            Product.Create(ProductId.Of(new Guid("f6f7a8b9-c0d1-2345-f123-456789012345")), "Dell XPS 15", 1499.50M),
            Product.Create(ProductId.Of(new Guid("f7a8b9c0-d1e2-3456-1234-567890123456")), "AirPods Pro", 249.00M),
            Product.Create(ProductId.Of(new Guid("f8b9c0d1-e2f3-4567-2345-678901234567")), "LG OLED TV 55", 1299.99M),
            Product.Create(ProductId.Of(new Guid("f9c0d1e2-f3a4-5678-3456-789012345678")), "Canon EOS R6", 2499.00M),
            Product.Create(ProductId.Of(new Guid("fad1e2f3-a4b5-6789-4567-890123456789")), "Nintendo Switch", 299.99M),
        };

    public static IEnumerable<Order> OrdersWithItems
    {
        get
        {
            // John
            var address1 = Address.Of("John", "Smith", "john@gmail.com", "Broadway No: 123", "USA", "Los Angeles", "90001");
            var payment1 = Payment.Of("John Smith", "4532123456789012", "06/30", "222", 1);
            // Sarah
            var address2 = Address.Of("Sarah", "Johnson", "sarah@outlook.com", "Oak Street No: 456", "USA", "New York", "10001");
            var payment2 = Payment.Of("Sarah Johnson", "5425233430109903", "08/29", "333", 2);
            // Miguel
            var address3 = Address.Of("Miguel", "Rodriguez", "miguel@yahoo.com", "Reforma Avenue No: 789", "Mexico", "Mexico City", "06600");
            var payment3 = Payment.Of("Miguel Rodriguez", "378282246310005", "12/28", "444", 1);
            // Emma
            var address4 = Address.Of("Emma", "Williams", "emma@hotmail.com", "King Street No: 321", "Canada", "Toronto", "M5H2N");
            var payment4 = Payment.Of("Emma Williams", "6011111111111117", "03/27", "555", 3);
            // David
            var address5 = Address.Of("David", "Brown", "david@gmail.com", "Market Street No: 654", "USA", "San Francisco", "94102");
            var payment5 = Payment.Of("David Brown", "3530111333300000", "09/26", "666", 2);

            var order1 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890")),
                OrderName.Of("ORD_1"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);
            order1.Add(ProductId.Of(new Guid("f1a2b3c4-d5e6-7890-abcd-ef1234567890")), 2, 500.65M);
            order1.Add(ProductId.Of(new Guid("f2b3c4d5-e6f7-8901-bcde-f12345678901")), 1, 400.36M);

            var order2 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901")),
                OrderName.Of("ORD_2"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);
            order2.Add(ProductId.Of(new Guid("f3c4d5e6-f7a8-9012-cdef-123456789012")), 1, 1999.00M);
            order2.Add(ProductId.Of(new Guid("f4d5e6f7-a8b9-0123-def1-234567890123")), 2, 349.99M);
            order2.Add(ProductId.Of(new Guid("f5e6f7a8-b9c0-1234-ef12-345678901234")), 1, 599.00M);


            var order3 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012")),
                OrderName.Of("ORD_3"),
                shippingAddress: address3,
                billingAddress: address3,
                payment3);
            order3.Add(ProductId.Of(new Guid("f6f7a8b9-c0d1-2345-f123-456789012345")), 1, 1499.50M);
            order3.Add(ProductId.Of(new Guid("f7a8b9c0-d1e2-3456-1234-567890123456")), 3, 249.00M);
            
            var order4 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("d4e5f6a7-b8c9-0123-def1-234567890123")),
                OrderName.Of("ORD_4"),
                shippingAddress: address4,
                billingAddress: address4,
                payment4);
            order4.Add(ProductId.Of(new Guid("f8b9c0d1-e2f3-4567-2345-678901234567")), 1, 1299.99M);
            order4.Add(ProductId.Of(new Guid("f9c0d1e2-f3a4-5678-3456-789012345678")), 1, 2499.00M);
            order4.Add(ProductId.Of(new Guid("fad1e2f3-a4b5-6789-4567-890123456789")), 2, 299.99M);
            
            var order5 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("e5f6a7b8-c9d0-1234-ef12-345678901234")),
                OrderName.Of("ORD_5"),
                shippingAddress: address5,
                billingAddress: address5,
                payment5);
            order5.Add(ProductId.Of(new Guid("f1a2b3c4-d5e6-7890-abcd-ef1234567890")), 1, 500.60M);
            order5.Add(ProductId.Of(new Guid("f3c4d5e6-f7a8-9012-cdef-123456789012")), 1, 1999.00M);
            
            var order6 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890")),
                OrderName.Of("ORD_6"),
                shippingAddress: address1,
                billingAddress: address1,
                payment1);
            order6.Add(ProductId.Of(new Guid("f4d5e6f7-a8b9-0123-def1-234567890123")), 2, 349.99M);
            order6.Add(ProductId.Of(new Guid("f7a8b9c0-d1e2-3456-1234-567890123456")), 4, 249.00M);
            order6.Add(ProductId.Of(new Guid("fad1e2f3-a4b5-6789-4567-890123456789")), 1, 299.99M);
            
            var order7 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901")),
                OrderName.Of("ORD_7"),
                shippingAddress: address2,
                billingAddress: address2,
                payment2);
            order7.Add(ProductId.Of(new Guid("f2b3c4d5-e6f7-8901-bcde-f12345678901")), 1, 699.99M);
            order7.Add(ProductId.Of(new Guid("f5e6f7a8-b9c0-1234-ef12-345678901234")), 2, 599.00M);
            
            var order8 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("c3d4e5f6-a7b8-9012-cdef-123456789012")),
                OrderName.Of("ORD_8"),
                shippingAddress: address3,
                billingAddress: address3,
                payment3);
            order8.Add(ProductId.Of(new Guid("f6f7a8b9-c0d1-2345-f123-456789012345")), 1, 1499.50M);
            order8.Add(ProductId.Of(new Guid("f8b9c0d1-e2f3-4567-2345-678901234567")), 1, 1299.99M);
            order8.Add(ProductId.Of(new Guid("f9c0d1e2-f3a4-5678-3456-789012345678")), 1, 2499.00M);
            
            var order9 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("d4e5f6a7-b8c9-0123-def1-234567890123")),
                OrderName.Of("ORD_9"),
                shippingAddress: address4,
                billingAddress: address4,
                payment4);
            order9.Add(ProductId.Of(new Guid("f1a2b3c4-d5e6-7890-abcd-ef1234567890")), 3, 500.60M);
            order9.Add(ProductId.Of(new Guid("f7a8b9c0-d1e2-3456-1234-567890123456")), 2, 249.00M);

            var order10 = Order.Create(
                OrderId.Of(Guid.NewGuid()),
                CustomerId.Of(new Guid("e5f6a7b8-c9d0-1234-ef12-345678901234")),
                OrderName.Of("OR_10"),
                shippingAddress: address5,
                billingAddress: address5,
                payment5);
            order10.Add(ProductId.Of(new Guid("f3c4d5e6-f7a8-9012-cdef-123456789012")), 1, 1999.00M);
            order10.Add(ProductId.Of(new Guid("f4d5e6f7-a8b9-0123-def1-234567890123")), 1, 349.99M);
            order10.Add(ProductId.Of(new Guid("fad1e2f3-a4b5-6789-4567-890123456789")), 3, 299.99M);
            
            return new List<Order> { order1, order2, order3, order4,  order5, order6, order7, order8, order9, order10 };
        }
    }
}