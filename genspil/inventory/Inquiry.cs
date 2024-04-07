﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genspil.inventory
{
    internal class Inquiry(Inquiry.InquiryStatus status, Customer customer, DateTime creationDate, Boardgame boardgame)
    {
        //Public Inquiry er en constructor der tager status, customerID og creationDate som parametre og opretter et Inquiry objekt.

        public InquiryStatus Status { get; set; } = status;
        public DateTime CreationDate { get; set; } = creationDate;
        public Boardgame Boardgame { get; set; } = boardgame;
        public Customer Customer { get; set; } = customer;
        //Status, CreationDate, Boardgame og Customer er properties der kan tilgås og ændres udefra.

        public enum InquiryStatus
        {
            Open,
            InProgress,
            Closed,
            Resolved
        }
        //InquiryStatus er en enum der indeholder de forskellige statusser et inquiry objekt kan have. Enum er en datatype der kan have en af en række foruddefinerede værdier.

    }
}