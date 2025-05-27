﻿namespace MVC.Models
{
    public class NewSocks
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public SockSize Size { get; set; }
        public decimal Price { get; set; }
        public int OnStock { get; set; }
    }
}
