﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using genspil.Enums;

namespace genspil.inventory
{
    public class Inquiry(InquiryStatus status, string inquiryID, string boardgameName, string customerName, string customerEmail, string customerID, DateTime? creationDate = null)
    {       
        public InquiryStatus Status 
        { 
            get { return status; } 
        }

        public DateTime CreationDate
        {
            get { return creationDate ?? DateTime.Now; }
        }

        public string InquiryID
        {
            get { return inquiryID; }
        }

        public string Email
        {
            get { return customerEmail; }
        }

        public void PrintInquiry()
        {
            Console.WriteLine("Status: {0} \n" +
                "Inquiry ID: {1} \n" +
                "Creation Date: {2} \n" +
                "Customer: {3} \n" +
                "Boardgame: {4} \n" +
                "______________________________",
                status, inquiryID, CreationDate, customerName, boardgameName
            );
        }

        public void UpdateInquiryStatus(InquiryStatus newStatus)
        {
            status = newStatus;
        }
        
        public string MakeTitle() => $"{status},{inquiryID},{boardgameName},{customerName},{customerEmail},{customerID},{creationDate}";
    }
}
