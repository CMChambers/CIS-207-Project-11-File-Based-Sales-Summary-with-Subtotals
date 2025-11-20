
namespace CIS207.Project11FileBasedSalesSummaryWithSubtotals
{
    class Program
    {
        static void Main(string[] args)
        {
            // get file
            string filePath = "sales-data.csv";

            Console.WriteLine("=== Sales Summary by Region ===");
            Console.WriteLine($"Reading file: {filePath}");
            Console.WriteLine();

            // if file not found
            if (!File.Exists(filePath))
            {
                Console.WriteLine("ERROR: File not found.");
                Console.WriteLine("Make sure sales-data.csv is in the correct folder.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            // initialize fields
            string currentDepartment = null;
            decimal departmentSalesTotal = 0m;
            int departmentSalesCount = 0;

            decimal grandTotal = 0m;
            int grandCount = 0;

            // read file
            using (StreamReader reader = new StreamReader(filePath))
            {
                string headerLine = reader.ReadLine();

                string line;

                // read line
                while ((line = reader.ReadLine()) != null)
                {
                    // split csv into array
                    string[] parts = line.Split(',');

                    if (parts.Length < 4)
                    {
                        Console.WriteLine($"Skipping invalid line (not enough fields): {line}");
                        continue; // skip and move on
                    }

                    // parse fields
                    string department = parts[0].Trim();
                    string itemName = parts[1].Trim();
                    string quantityText = parts[2].Trim();
                    string unitPriceText = parts[3].Trim();


                    if (!int.TryParse(quantityText, out int quantity))
                    {
                        Console.WriteLine($"Skipping invalid line (invalid quantity): {line}");
                        continue; // skip and move on
                    }
                    if (!decimal.TryParse(unitPriceText, out decimal unitPrice))
                    {
                        Console.WriteLine($"Skipping invalid line (invalid unit price): {line}");
                        continue; // skip and move on
                    }

                    decimal lineTotal = quantity * unitPrice;

                    // check if first time
                    if (currentDepartment == null)
                    {
                        // initialize control field
                        currentDepartment = department;
                    }
                    // if not first time
                    else if (department != currentDepartment)
                    {
                        // print subtotal
                        PrintRegionSubtotal(currentDepartment, departmentSalesTotal, departmentSalesCount);

                        // reset fields
                        currentDepartment = department;
                        departmentSalesTotal = 0m;
                        departmentSalesCount = 0;
                    }

                    // accumulate fields
                    departmentSalesTotal += lineTotal;
                    departmentSalesCount += quantity;

                    grandTotal += lineTotal;
                    grandCount += quantity;
                }
            }
            // print subtotal for last region
            if (currentDepartment != null)
            {
                PrintRegionSubtotal(currentDepartment, departmentSalesTotal, departmentSalesCount);
            }

            // print grand total
            Console.WriteLine(new string('=', 45));
            Console.WriteLine($"Grand Total Sales ({grandCount} records): {grandTotal:C}");
            Console.WriteLine(new string('=', 45));

            Console.WriteLine();
            Console.WriteLine("Demo complete. Press any key to exit...");
            Console.ReadKey();




        }


        private static void PrintRegionSubtotal(string currentRegion, decimal regionTotal, int regionCount)
        {
            Console.WriteLine(new string('-', 45));
            Console.WriteLine($"Region: {currentRegion}");
            Console.WriteLine($"  Number of Sales: {regionCount}");
            Console.WriteLine($"  Region Total:    {regionTotal:C}");
            Console.WriteLine(new string('-', 45));
        }
    }
}