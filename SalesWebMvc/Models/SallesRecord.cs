using SalesWebMvc.Models.Enums;
using System;


namespace SalesWebMvc.Models
{
    public class SallesRecord
    {

        public int id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }

        public SallesRecord() {
        }

        public SallesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            this.id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }

    }
}
