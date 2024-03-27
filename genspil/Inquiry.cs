using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil
{
    internal class Inquiry
    {
        public Inquiry(InquiryStatus status, Customer customer, DateTime creationDate)
        {
            Status = status;
            Customer = customer;
            CreationDate = creationDate;
        }
        //Public Inquiry er en constructor der tager status, customerID og creationDate som parametre og opretter et Inquiry objekt.


        public InquiryStatus Status { get; set; }
        public DateTime CreationDate { get; set; }
        public Boardgame Boardgame { get; set; }
        public Customer Customer { get; set; }
        //Status, CreationDate, Boardgame og Customer er properties der kan tilgås og ændres udefra.

        public enum InquiryStatus
        {
            Open,
            InProgress,
            Closed,
            Resolved
        }
        //InquiryStatus er en enum der indeholder de forskellige statusser et inquiry objekt kan have. Enum er en datatype der kan have en af en række foruddefinerede værdier.

        public void UpdateStatus(InquiryStatus newStatus)
        {
            Status = newStatus;
        }
        //UpdateStatus metoden er en metode der tager en ny status som parameter og opdaterer status på inquiry objektet.
    }
}
