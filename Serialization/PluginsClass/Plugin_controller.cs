using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Windows.Forms;

namespace Serialization
{
    public class Plugin_Controller
    {
        string Get_dll_name(string path)
        {
            string[] buf = path.Split('\\');
            string test = buf[buf.Count() - 1].Remove(buf[buf.Count() - 1].Count() - 4);
            return buf[buf.Count() - 1].Remove(buf[buf.Count() - 1].Count() - 4);
        }

        public IPlugins Load_Plugin(Form1 form, string path)
        {
            ObjectHandle handle = Activator.CreateInstance(Get_dll_name(path), "Plugin");
            IPlugins plugin = (IPlugins)handle.Unwrap();
            return plugin;
        }
    }
}
