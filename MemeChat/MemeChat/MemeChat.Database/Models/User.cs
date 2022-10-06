﻿using MemeChat.Database.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MemeChat.Models
{
    public class User : ILoginCredentials
    {
        [Key]
        public Guid Id { get; set; } = Guid.Empty;
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 3)]
        public string Nickname { get; set; } = string.Empty;
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 100, MinimumLength = 12)]
        public string Password { get; set; } = string.Empty;
        [MaybeNull]
        [DataType(DataType.ImageUrl)]
        public string Avatar { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string About { get; set; } = string.Empty;
        [Required]
        public DateTime? DateOfBirth { get; set; } = DateTime.Today.AddYears(-16);
        [Required]
        internal DateTime CreatedAd { get; set; } = DateTime.UtcNow;

        public void Map(User user)
        {
            if (user == null)
            {
                return;
            }

            Nickname = user.Nickname;
            Name = user.Name;
            Email = user.Email;
            Password = user.Password;
            Avatar = user.Avatar;
            About = user.About;
            DateOfBirth = user.DateOfBirth;
        }
    }
}
