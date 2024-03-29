﻿using System.Buffers;

namespace airtek_assessment;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "data/orders.json"; // Harcoded file-path, Adjust as needed
        
        var orderProcessor = new JsonOrderProcessor( 
            new FileJsonReader(), 
            new ProgramConsoleWriter()
        );


        try
        {
            orderProcessor.ProcessOrders(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing orders: {ex.Message}");
        }
    }
}
