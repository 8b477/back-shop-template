using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Shop.DTO.User.Update
{
    public class UserRoleUpdateDTO
    {
        public UserRoleUpdateDTO(string role)
        {
            Role = role;
        }

        public string Role { get; init; }
    }
}
