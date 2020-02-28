using System;
using System.Globalization;
using CarRentalNelioResolution.Entities;
using CarRentalNelioResolution.Services;

namespace CarRentalNelioResolution
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");
            string model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime start = DateTime.Parse(Console.ReadLine()); //Alternativa: datetime.parseExact(console.readline(), "dd/MM/yyyy hh:mm");
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.Parse(Console.ReadLine()); //datetime.parseExact(console.readline(), "dd/MM/yyyy hh:mm");
            
            CarRental carRental = new CarRental(start, finish, new Vehicle(model)); //Bacana

            Console.Write("Enter price per hour: ");
            double hour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");

            double day = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            RentalService rentalService = new RentalService(hour, day, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);
            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRental.Invoice);
        }
    }
}
