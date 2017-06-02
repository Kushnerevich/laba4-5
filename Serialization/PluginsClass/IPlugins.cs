using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization
{
    public interface IPlugins
    {
        void Run(PluginApi api);
    }
}
