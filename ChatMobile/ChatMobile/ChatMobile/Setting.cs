using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ChatMobile
{
    public class Setting
    {
        #region const

        public const string XmlProperty_IsFirstLogin = "IsFirstLogin";

        #endregion

        [XmlElement] public string Name;
        [XmlElement] public string Value;

        public Setting() { }

        public Setting(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
