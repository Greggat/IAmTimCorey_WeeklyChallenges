using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge15_APIUsage
{
    class WebCache : IEquatable<WebCache>
    {
        public string RequestUrl { get; set; }
        public string Reponse { get; set; }

        public bool Equals(WebCache other)
        {
            if (other == null) return false;
            return (this.RequestUrl.Equals(other.RequestUrl));
        }
    }
}
