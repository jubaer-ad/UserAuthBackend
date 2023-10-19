﻿using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class LoginReq
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}