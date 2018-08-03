using System.Collections.Generic;

namespace ChatServer.Errors
{
    public class Errors : Dictionary<string, string>
    {
        #region Singleton

        private static volatile Errors _instance;
        private static object locker = new object();


        public static Errors Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null)
                            _instance = new Errors();
                    }
                }

                return _instance;
            }
        }

        #endregion


        private Errors()
        {
            this.Add("Error_ReceiverChatIdNull", "Receiver chat id is null");
        }

        public string GetErrorMessage(string errorId)
        {
            return this[errorId];
        }
    }
}