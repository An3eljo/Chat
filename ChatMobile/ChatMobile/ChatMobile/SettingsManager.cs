using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ChatMobile
{
    public class SettingsManager
    {
        #region Singleton

        private static volatile SettingsManager _instance;
        private static object locker = new object();

        private SettingsManager()
        {
            _settings = new List<Setting>();
        }

        public static SettingsManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null)
                            _instance = new SettingsManager();
                    }
                }

                return _instance;
            }
        }

        #endregion

        public List<Setting> Settings => _settings.ToList();

        private IList<Setting> _settings;

        public void Add(Setting setting)
        {
            _settings.Add(setting);
        }
    }
}
