using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class UserResponseDTO
    {
        public int UserId { get; set; }

        public string Username { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public string? FullName { get; set; } = null!;

        public string? Address { get; set; } = null!;

        public string? Introduction { get; set; }

        public string? AvatarUrl { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public short Role { get; set; }

        public DateTime CreatedAt { get; set; }

        public short Gentle { get; set; }

        public short Status { get; set; }

        public int FollowedCount { get; set; } = 0;

        public int FollowingCount { get; set; } = 0;

        public int PostCount { get; set; } = 0;

    }
}
