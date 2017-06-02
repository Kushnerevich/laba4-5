
using MyPlugin;
using Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public class Plugin : IPlugins
{

    public void Run(PluginApi api) 
    {
        AddComponents maker = new AddComponents();
        maker.Create_tabPage(api);

    }
}
