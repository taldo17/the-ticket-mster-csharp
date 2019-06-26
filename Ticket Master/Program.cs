using System;


namespace Ticket_Master
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the Ticket master");
                Console.WriteLine("Please choose the name of the show: ");
                var showName = Console.ReadLine();
                Console.WriteLine("Please choose the desired date in the following format dd//mm/yyyy: ");
                var desiredDate = Console.ReadLine();
                Console.WriteLine("Number of tickets: ");
                int numberOfTickets = Convert.ToInt32(Console.ReadLine());
                TicketService ticketService = new TicketService();
                var placeOrder = ticketService.PlaceOrder(showName, desiredDate, numberOfTickets);
                Console.WriteLine(placeOrder);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
    }
}