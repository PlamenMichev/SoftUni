﻿using System.ComponentModel.DataAnnotations;

namespace SIS.MvcFramework
{
    public class IdentityUser<T>
    {
        public T Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [MaxLength(20)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
