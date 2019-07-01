using System;
using JustInfo.Domain.Models;

namespace JustInfo.Domain.Communications
{
    public class ScrapResponse : BaseResponse
    {
       public Scrap Scrap { get; set; }

        private ScrapResponse(bool success, string message, Scrap scrap) : base(success, message)
        {
            Scrap = scrap;
        }

        public ScrapResponse(Scrap scrap) : this(true, string.Empty, scrap)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ScrapResponse(string message) : this(false, message, null)
        {
        }
    }
}
