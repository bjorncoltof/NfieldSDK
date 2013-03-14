using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nfield.Models
{
    /// <summary>
    /// Result of a sign in attempy
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        /// Status
        /// </summary>
        public AuthenticationStatus Status { get; set; }

        /// <summary>
        /// ID of the user, if signed in
        /// </summary>
        public string UserId { get; set; }
    }
}
