using System;

namespace JK.GuildWars2Api
{
    public class NullKeyException : Exception
    {
        public NullKeyException()
            : base("Key must be present to make this API call.")
        {
        }
    }
}
