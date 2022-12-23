using CMLauncher.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace CMLauncher.Helper
{
    static class generador
    {
        static Settings Configuracion = new Settings();
        public static string UUID()
        {
            //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            /// Codigo fuente obtenido de:                             ///
            ///    https://www.uuidgenerator.net/dev-corner/c-sharp    ///
            //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////
            Guid myuuid = Guid.NewGuid();
            string myuuidAsString = myuuid.ToString();

            return myuuidAsString.Replace("-", "").ToLower();
        }

        public static bool generarCarpetas()
        {
            var minecraftPath = Configuracion.minecraftPath;
            try
            {
                if (Directory.Exists(minecraftPath))
                {
                    if (Directory.Exists(minecraftPath + "assets"))
                    {
                        if (!Directory.Exists(minecraftPath + "assets\\indexes"))
                        {
                            Directory.CreateDirectory(minecraftPath + "assets\\indexes");
                        }
                        if (!Directory.Exists(minecraftPath + "assets\\objects"))
                        {
                            Directory.CreateDirectory(minecraftPath + "assets\\objects");
                        }
                        if (!Directory.Exists(minecraftPath + "assets\\objects"))
                        {
                            Directory.CreateDirectory(minecraftPath + "assets\\objects");
                        }
                        if (!Directory.Exists(minecraftPath + "assets\\skins"))
                        {
                            Directory.CreateDirectory(minecraftPath + "assets\\skins");
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(minecraftPath + "assets");
                        Directory.CreateDirectory(minecraftPath + "assets\\indexes");
                        Directory.CreateDirectory(minecraftPath + "assets\\log_configs");
                        Directory.CreateDirectory(minecraftPath + "assets\\objects");
                        Directory.CreateDirectory(minecraftPath + "assets\\skins");
                    }
                    if (!Directory.Exists("libraries"))
                    {
                        Directory.CreateDirectory(minecraftPath + "libraries");
                    }

                    if (!Directory.Exists("logs"))
                    {
                        Directory.CreateDirectory(minecraftPath + "logs");
                    }

                    if (!Directory.Exists("resourcepacks"))
                    {
                        Directory.CreateDirectory(minecraftPath + "resourcepacks");
                    }

                    if (!Directory.Exists("saves"))
                    {
                        Directory.CreateDirectory(minecraftPath + "saves");
                    }

                    if (!Directory.Exists("screenshots"))
                    {
                        Directory.CreateDirectory(minecraftPath + "screenshots");
                    }

                    if (!Directory.Exists("versions"))
                    {
                        Directory.CreateDirectory(minecraftPath + "versions");
                    }
                }
                else
                {
                    Directory.CreateDirectory(minecraftPath);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
