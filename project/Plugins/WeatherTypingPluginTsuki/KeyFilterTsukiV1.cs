using com.denasu.WeatherTyping.plugin.input;
using System;
using System.Collections.Generic;

namespace net.permil.WTPlugin.WeatherTypingPluginTsuki
{
    public class KeyFilterTsukiV1 : MarshalByRefObject, IKeyFilter
    {
        public const string S1NAME = "シフトキー1";
        public const string S2NAME = "シフトキー2";
        public const string USNAME = "アンシフトキー";

        private bool _shift = false;
        private int _middleShift = 0;

        public string Author { get { return "permil"; } }
        public string Name { get { return "月配列"; } }
        public string Memo { get { return "月配列用 Key Filter"; } }
        public int Version { get { return 1; } }
        public List<string> Language { get { return new List<string>(){ }; } }
        public IKeyCustom CreateKeyCustom() { return new KeyCustomTsukiV1(); }

        public List<string> GetNames()
        {
            return new List<string>()
            {
                S1NAME, // Left top of key label
                S2NAME, // Right top of key label
            };
        }

        private string _imAuthor;
        private string _imName;
        private int _imVersion;
        public void InputMethodInfo(string author, string name, int version)
        {
            _imAuthor = author;
            _imName = name;
            _imVersion = version;
        }
 
        public List<int> Convert(int physicalKey, bool pressed, long currentTime, IKeyCustom keyCustom)
        {
            List<int> result = new List<int>();

            if (physicalKey == (int)WTKeyCode.Shift)
            {
                _shift = pressed;
            }
            else if (pressed)
            {
                if (physicalKey == (int)keyCustom.GetMappedKey(S1NAME) && _middleShift == 0 && !_shift)
                {
                    _middleShift = 1;
                }
                else if (physicalKey == (int)keyCustom.GetMappedKey(S2NAME) && _middleShift == 0 && !_shift)
                {
                    _middleShift = 2;
                }
                else if (physicalKey == (int)keyCustom.GetMappedKey(USNAME) && _middleShift != 0 && !_shift)
                {
                    _middleShift = 0;
                }
                else
                {
                    if (_shift)
                    {
                        physicalKey |= (int)WTKeyCode.Shift;
                    }
                    else
                    {
                        switch (_middleShift)
                        {
                            case 1: physicalKey |= (int)WTKeyCode.Custom1; break;
                            case 2: physicalKey |= (int)WTKeyCode.Custom2; break;
                            default: break;
                        }
                        _middleShift = 0;
                    }
                    result.Add(physicalKey);
                }
            }

            return result;
        }
    }
}
