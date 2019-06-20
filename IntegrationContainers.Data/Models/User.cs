using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationContainers.Data.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public ICollection<UserTeam> UserTeams { get; set; }
    }

}
