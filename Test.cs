public class OrderService
{
    public void ProcessOrder(Order order)
    {
        var pro_date = new DateTime.UtcNow; 

        if (order.Type == "Online")
        {
            // Process online order
            Console.WriteLine("Processing online order");
            // ... more code
        }
        else if (order.Type == "InStore")
        {
            // Process in-store order
            Console.WriteLine("Processing in-store order");
            // ... more code
        }
        else if (order.Type == "Phone")
        {
            // Process phone order
            Console.WriteLine("Processing phone order");
            // ... more code
        }
        else
        {
            Console.WriteLine("Unknown order type");
        }

        // Send confirmation email
        var emailService = new EmailService();
        emailService.SendEmail(order.CustomerEmail, "Order Confirmation", "Your order has been processed.");
    }
}

public class EmailService
{
    public async Task SendEmail(string to, string subject, string body)
    {
        await AddAttachmentAsync();
        
        // Send email logic
        Console.WriteLine($"Sending email to {to}: {subject}");
    }

    public async void AddAttachmentAsync()
    {
        try
        {
            // Add Attachment logic
            Console.WriteLine($"Attaching file");
        }
        catch(Exception e)
        {
            throw e;
        }
    }
}

public class Order
{
    public string Type { get; set; }
    public string CustomerEmail { get; set; }
}
