using BrandTask;
using System.Transactions;

BrandService brandService=new BrandService();
string opt;

do
{
    Console.WriteLine("1.Create Brand");
    Console.WriteLine("2. Delete Brand ");
    Console.WriteLine("3. Get Brand by Id");
    Console.WriteLine("4.Get All Brands");
    Console.WriteLine("5.Update Brand");
    Console.WriteLine("0. Exit");
    Console.Write("Choose Operation:");
    opt= Console.ReadLine();

    string idStr;
    string yearStr;
    string brandName;
    int id;
    int year;

    switch (opt)
    {
        case "1":
            do
            {
                Console.Write("Enter brand name: ");
                brandName = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(brandName));
            do
            {
                Console.Write("Enter brand year: ");
                yearStr = Console.ReadLine();
            }
            while (!int.TryParse(yearStr, out year) || year < 1900 || year > 2024);
            brandService.CreateBrand(brandName, year);
            Console.WriteLine("Brand successfully added!");
            break;
            case "2":
            do
            {
                Console.Write("Enter brand Id: ");
                idStr = Console.ReadLine();
            }
            while (!int.TryParse(idStr, out id) || id < 0);
            brandService.DeleteBrand(id);
            Console.WriteLine("Brand successfully deleted!");
            break;
            case "3":
            do
            {
                Console.Write("Enter brand Id: ");
                idStr = Console.ReadLine();
            }
            while (!int.TryParse(idStr, out id) || id < 0);
            var data = brandService.GetBrandById(id);
            if (data == null)
                Console.WriteLine("Error not found!");
            else 
                Console.WriteLine(data);
            break;
            case "4":
            Console.WriteLine("=All Bands==:");
            foreach (var item in brandService.GetAllBrands())
                Console.WriteLine(item);
            break;
            case "5":
            {
                Console.Write("Enter brand Id: ");
                idStr = Console.ReadLine();
            }
            while (!int.TryParse(idStr, out id) || id < 0);
            string brandUpt;
            Console.WriteLine("Choose name or year for updating:");
            brandUpt= Console.ReadLine();
            switch (brandUpt) 
            {
                case "NameUpdate":
                    do
                    {

                        Console.Write("Enter new brand name:");
                        brandName = Console.ReadLine();
                    } 
                    while (string.IsNullOrWhiteSpace(brandName));
                    brandService.UpdateNameOfBrand(id, brandName);
                    Console.WriteLine("BrandName updated");
                    break;

                case "YearUpdate":
                    do
                    {

                     Console.Write("Enter new brand year:");
                     yearStr=Console.ReadLine();
                    }
                    while (!int.TryParse(yearStr, out year) || year < 1900 || year > 2024);
                    brandService.UpdateYearOfBrand(id, year);
                    Console.WriteLine("BrandYear Updated");
                    break;
                default:
                    Console.WriteLine("Error!");
                    break;
            }
            break;
        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid Operation!!");
            break;
    }

} while (true);