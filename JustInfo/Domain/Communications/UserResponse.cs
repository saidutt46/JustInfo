using System;
using JustInfo.Domain.Models;

namespace JustInfo.Domain.Communications
{
    public class UserResponse : BaseResponse
    {
        public UserInfo User { get; set; }

        private UserResponse(bool success, string message, UserInfo user) : base(success, message)
        {
            User = user;
        }

        public UserResponse(UserInfo user) : this(true, string.Empty, user)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public UserResponse(string message) : this(false, message, null)
        {
        }
    }
}
