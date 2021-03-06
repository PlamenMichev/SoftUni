﻿namespace VaporStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using VaporStore.Data.Enums;

    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public PurchaseType Type { get; set; }

        [Required]
        [RegularExpression(@"[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}")]
        public string ProductKey { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public int CardId { get; set; }
        public Card Card { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}