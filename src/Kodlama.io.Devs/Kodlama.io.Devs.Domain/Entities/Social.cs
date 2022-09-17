using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Domain.Entities
{
    public class Social : Entity
    {
        public int DeveloperId { get; set; }
        public string GitHubProfile { get; set; }
        public Developer Developer { get; set; }

        public Social()
        {

        }

        public Social(int developerId, string gitHubProfile) : this()
        {
            DeveloperId = developerId;
            GitHubProfile = gitHubProfile;
        }
    }
}
