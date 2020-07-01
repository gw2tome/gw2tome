namespace JK.GuildWars2Api
{
    public class KeyStore
    {
        #region Singleton Pattern Implementation

        private static readonly object threadLock = new object();
        private static volatile KeyStore instance;

        private KeyStore()
        {
        }

        public static KeyStore Instance
        {
            get
            {
                if (instance != null) return instance;

                lock (threadLock)
                {
                    if (instance == null)
                    {
                        instance = new KeyStore();
                    }
                }

                return instance;
            }
        }

        #endregion

        public string Key { get; set; }
    }
}
