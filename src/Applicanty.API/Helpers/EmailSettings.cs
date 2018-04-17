using System;

namespace Applicanty.API.Helpers
{
    public class EmailSettings
    {
        public String PrimaryDomain { get; set; }

        public int PrimaryPort { get; set; }

        public String FromEmail { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }

        public String ToEmail { get; set; }
    }
}
