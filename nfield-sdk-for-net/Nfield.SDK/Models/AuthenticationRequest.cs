using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nfield.Models
{
    public class AuthenticationRequest
    {
        /// <summary>
        /// The domain to sign into
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The user password
        /// </summary>
        public string Password { get; set; }
    }
}
