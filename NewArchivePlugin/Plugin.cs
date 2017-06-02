using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Serialization;
using NewArchivePlugin;


public class Plugin : IPlugins
    {
        public void Run(PluginApi api)
        {
            AddComponents maker = new AddComponents();
            maker.Create_Button(api);
        }

    }

