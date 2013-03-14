using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nfield.Models
{
    public enum AuthenticationStatus
    {
        /// <summary>
        /// Not signed in, credentials incorrect
        /// </summary>
        None = 0,

        /// <summary>
        /// Password is expired
        /// </summary>
        PasswordExpired = 1,

        /// <summary>
        /// Signed in successfully for the first time
        /// </summary>
        FirstSignIn = 2,

        /// <summary>
        /// Signed in, password expires soon
        /// </summary>
        PasswordAboutToExpire = 3,

        /// <summary>
        /// Signed in successfully
        /// </summary>
        Success = 4,
    }
}
