﻿namespace FinLit.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string PasswordHash { get; set; }

        public string? CreatedAt { get; set; }
    }
}
