using WebSalesMVC.Models;
namespace WebSalesMVC.Data
{
    public class SeedingService
    {
        private WebSalesMVCContext _context;

        public SeedingService(WebSalesMVCContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return;
            }
            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Books");

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1996, 08, 14), 2093.00);

            SalesRecord c1 = new SalesRecord(1, new DateTime(2023, 05, 22), 5800.00, Models.Enums.SaleStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3);
            _context.Seller.AddRange(s1);
            _context.SalesRecord.AddRange(c1);

            _context.SaveChanges();
        }
    }
}
