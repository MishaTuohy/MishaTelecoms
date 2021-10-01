using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MishaTelecoms.API.Models.Requests.UserData.Post.Update
{
    public class UpdateUserPasswordHashRequest
    {
        public Guid Id { get; set; }
        public string PasswordHash { get; set; }
    }
}
