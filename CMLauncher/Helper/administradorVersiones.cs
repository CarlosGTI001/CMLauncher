using CMLauncher.Modelos;
using CMLauncher.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Helper
{
    static class administradorVersiones
    {
        static Settings Settings = new Settings();
        static string[] verificarVersiones()
        {
            string[] verificarVersiones;
            var path = Path.Combine(Settings.minecraftPath, "versions");
            verificarVersiones = Directory.GetDirectories(path);
            return verificarVersiones;
        }

        public static string[] obtenerJsonVersion()
        {
            var Directorios = verificarVersiones();
            descargarVersion descargarVersion = new descargarVersion();
            string[] versionesDisponibles = new string[0];
            for(var i = 0; i < Directorios.Length; i++)
            {
                versionesDisponibles = versionesDisponibles.Append(Directorios[i].Split('\\')[7]).ToArray();
            }
            return versionesDisponibles;
        }
    }
}
