using AppWebMvcSales.Models;
using AppWebMvcSales.Models.Enums;

namespace AppWebMvcSales.Data
{
    public class SeedingService
    {
        private readonly AppWebMvcSalesContext _context;
        public SeedingService(AppWebMvcSalesContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            if (_context.Departament.Any() ||
                _context.Seller.Any() ||
                _context.SellersRecord.Any())
            {
                return; // Db has been seeded
            }


            Departament d1 = new Departament("Computers");
            Departament d2 = new Departament("Electronics");
            Departament d3 = new Departament("Fashion");
            Departament d4 = new Departament("Books");

            Seller s1 = new Seller("Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0M, 1);
            //Seller s2 = new Seller("Maria Green", "maria@gmail.com", new DateTime(1979, 12, 31), 3500.0M, 2);
            //Seller s3 = new Seller("Alex Grey", "alex@gmail.com", new DateTime(1988, 1, 15), 2200.0M, 1);
            //Seller s4 = new Seller("Martha Red", "martha@gmail.com", new DateTime(1993, 11, 30), 3000.0M, 4);
            //Seller s5 = new Seller("Donald Blue", "donald@gmail.com", new DateTime(2000, 1, 9), 4000.0M, 3);
            //Seller s6 = new Seller("Alex Pink", "bob@gmail.com", new DateTime(1997, 3, 4), 3000.0M, 2);

            SelesRecord r1 = new SelesRecord(new DateTime(2018, 09, 25), 11000.0M, SalesStatus.BILLED, 1);
            //SelesRecord r2 = new SelesRecord(new DateTime(2018, 09, 4), 7000.0M, SalesStatus.BILLED, 3);
            //SelesRecord r3 = new SelesRecord(new DateTime(2018, 09, 13), 4000.0M, SalesStatus.BILLED, 5);
            //SelesRecord r4 = new SelesRecord(new DateTime(2018, 09, 1), 8000.0M, SalesStatus.BILLED, 4);
            //SelesRecord r5 = new SelesRecord(new DateTime(2018, 09, 21), 3000.0M, SalesStatus.BILLED, 4);
            //SelesRecord r6 = new SelesRecord(new DateTime(2018, 09, 15), 2000.0M, SalesStatus.BILLED, 4);
            //SelesRecord r7 = new SelesRecord(new DateTime(2018, 09, 28), 13000.0M, SalesStatus.BILLED, 2);
            //SelesRecord r8 = new SelesRecord(new DateTime(2018, 09, 11), 4000.0M, SalesStatus.BILLED, 4);
            //SelesRecord r9 = new SelesRecord(new DateTime(2018, 09, 14), 11000.0M, SalesStatus.PEDDING, 6);
            //SelesRecord r10 = new SelesRecord(new DateTime(2018, 09, 7), 9000.0M, SalesStatus.BILLED, 6);
            //SelesRecord r11 = new SelesRecord(new DateTime(2018, 09, 13), 6000.0M, SalesStatus.BILLED, 2);
            //SelesRecord r12 = new SelesRecord(new DateTime(2018, 09, 25), 7000.0M, SalesStatus.PEDDING, 3);
            //SelesRecord r13 = new SelesRecord(new DateTime(2018, 09, 29), 10000.0M, SalesStatus.BILLED, 4);
            //SelesRecord r14 = new SelesRecord(new DateTime(2018, 09, 4), 3000.0M, SalesStatus.BILLED, 5);
            //SelesRecord r15 = new SelesRecord(new DateTime(2018, 09, 12), 4000.0M, SalesStatus.BILLED, 1);
            //SelesRecord r16 = new SelesRecord(new DateTime(2018, 10, 5), 2000.0M, SalesStatus.BILLED, 4);
            //SelesRecord r17 = new SelesRecord(new DateTime(2018, 10, 1), 12000.0M, SalesStatus.BILLED, 1);
            //SelesRecord r18 = new SelesRecord(new DateTime(2018, 10, 24), 6000.0M, SalesStatus.BILLED, 3);
            //SelesRecord r19 = new SelesRecord(new DateTime(2018, 10, 22), 8000.0M, SalesStatus.BILLED, 5);
            //SelesRecord r20 = new SelesRecord(new DateTime(2018, 10, 15), 8000.0M, SalesStatus.BILLED, 6);
            //SelesRecord r21 = new SelesRecord(new DateTime(2018, 10, 17), 9000.0M, SalesStatus.BILLED, 2);
            //SelesRecord r22 = new SelesRecord(new DateTime(2018, 10, 24), 4000.0M, SalesStatus.BILLED, 4);
            //SelesRecord r23 = new SelesRecord(new DateTime(2018, 10, 19), 11000.0M, SalesStatus.CANCELED, 5);
            //SelesRecord r24 = new SelesRecord(new DateTime(2018, 10, 12), 8000.0M, SalesStatus.BILLED, 5);
            //SelesRecord r25 = new SelesRecord(new DateTime(2018, 10, 31), 7000.0M, SalesStatus.BILLED, 3);
            //SelesRecord r26 = new SelesRecord(new DateTime(2018, 10, 6), 5000.0M, SalesStatus.BILLED, 4);
            //SelesRecord r27 = new SelesRecord(new DateTime(2018, 10, 13), 9000.0M, SalesStatus.PEDDING, 1);
            //SelesRecord r28 = new SelesRecord(new DateTime(2018, 10, 7), 4000.0M, SalesStatus.BILLED, 3);
            //SelesRecord r29 = new SelesRecord(new DateTime(2018, 10, 23), 12000.0M, SalesStatus.BILLED, 5);
            //SelesRecord r30 = new SelesRecord(new DateTime(2018, 10, 12), 5000.0M, SalesStatus.BILLED,4);

            _context.Departament.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1/*, s2, s3, s4, s5, s6*/);

            _context.SellersRecord.AddRange(
                //r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                //r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                //r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }
    }
}
