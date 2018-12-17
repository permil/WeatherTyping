using com.denasu.Common.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTypingPluginTsuki
{
    class PluginInfo : MarshalByRefObject, IPluginInfo
    {
        /// <summary>
        /// Version
        /// </summary>
        public virtual int Version
        {
            get
            {
                return 1;
            }
        }

        /// <summary>
        /// The name of this plugin
        /// </summary>
        public virtual string Name
        {
            get
            {
                return "Tsuki Layout Plugin";
            }
        }

        /// <summary>
        /// The author of this plugin
        /// </summary>
        public string Author
        {
            get
            {
                return "permil";
            }
        }

        /// <summary>
        /// Memo
        /// </summary>
        public virtual string Memo
        {
            get
            {
                return "Tsuki Layout Plugin";
            }
        }
    }
}
