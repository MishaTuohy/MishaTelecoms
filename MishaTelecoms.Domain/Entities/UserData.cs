using System;
using System.Collections.Generic;
using System.Text;

namespace MishaTelecoms.Domain.Entities
{
    public class UserData
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public int Emailconfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberConfirmed { get; set; }
        public int TwoFactorEnabled { get; set; }
    }
}
