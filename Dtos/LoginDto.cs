﻿namespace NetflixApiClone.Dtos
{
    public class LoginDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
