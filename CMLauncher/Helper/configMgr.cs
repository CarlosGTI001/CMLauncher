using CLauncher.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLauncher.Helper
{
    static public class configMgr
    {
        static public void actualizarConfiguracion(configClass config)
        {
            Settings settings = new Settings();
            settings.javaPath = config.javaPath;
            settings.minecraftPath = config.minecraftPath;
            settings.fullScreen = config.fullScreen;
            settings.ramMB = config.RamMax;
            settings.ramMin = config.RamMin;
            settings.resolutionX = config.x;
            settings.resolutionY = config.y;
            settings.Save();
        }
        public class configClass
        {
            public string minecraftPath;
            public int RamMax;
            public int RamMin;
            public int x;
            public int y;
            public bool fullScreen;
            public string javaPath;
        }
    }
}
