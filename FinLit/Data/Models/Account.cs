﻿using FinLit.Data.Interfaces;

namespace FinLit.Data.Models
{
    public class Account : IAccount
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Balance { get; set; }
        public required string Currency { get; set; }
        public int UserId { get; set; }
    }
}
