using Code360_Management.Models.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code360_Management.Models.Payments
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student student { get; set; }
        public double Total { get; set; }
        public List<PaymentHistory> ListOfPayment { get; set; }
    }

    public class PaymentHistory
    {
        public int Id { get; set; }
        public double AmountPaid { get; set; }
        public DateTime DatePaid { get; set; }
        public int PaymentId { get; set; }
        public Payment payment { get; set; }
    }
}
