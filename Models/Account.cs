﻿namespace _10.Models
{
    public class Account
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? Phone { get; set; }

        public static List<Order> Orders = null;
        public bool AdminChecker { get; set; } = false;
    }
    public class Order
    {
        public int Orders { get; set; }
    }
}
