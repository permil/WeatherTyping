using com.denasu.WeatherTyping.plugin.input;
using System;
using System.Collections.Generic;

namespace net.permil.WTPlugin.WeatherTypingPluginTsuki
{
    internal class KeyCustomTsukiV1 : MarshalByRefObject, IKeyCustom
    {
        Dictionary<string, WTKeyCode> _keyMap = new Dictionary<string, WTKeyCode>()
            {
                { KeyFilterTsukiV1.S1NAME, WTKeyCode.D },
                { KeyFilterTsukiV1.S2NAME, WTKeyCode.K },
                { KeyFilterTsukiV1.USNAME, WTKeyCode.Space },
            };

        public void SetMappedKey(string name, WTKeyCode keyCode)
        {
            _keyMap[name] = keyCode;
        }

        public WTKeyCode GetMappedKey(string name)
        {
            return _keyMap[name];
        }
    }
}
