﻿namespace _0122.Models.DTO
{
    public class UserDTO
    {
        public string? Name { get; set; }
        public int Age { get; set; } = 29;

        public string? Email { get; set; }

        public IFormFile? Avataqr { get; set; }
    }
}
