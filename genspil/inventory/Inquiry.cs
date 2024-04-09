using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using genspil.Enums;

namespace genspil.inventory
{
    public class Inquiry(InquiryStatus status, string boardgameName, string customerName, string customerEmail, string customerID, DateTime? creationDate = null)
    {
        public InquiryStatus Status { get; set; } = status;
        public DateTime CreationDate { get; } = creationDate ?? DateTime.Now;

        public string Email { get; } = customerEmail;

        public void PrintInquiry()
        {
            Console.WriteLine("Status: {0} \n" +
                "Creation Date: {1} \n" +
                "Customer: {2} \n" +
                "Boardgame: {3} \n" +
                "______________________________",
                status, CreationDate, customerName, boardgameName
            );
        }

        public void UpdateInquiryStatus(InquiryStatus newStatus)
        {
            status = newStatus;
        }
    }
}
