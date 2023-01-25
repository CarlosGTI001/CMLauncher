using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Modelos
{

    //public class Downloads
    //{
    //    public Lzma lzma { get; set; }
    //    public Raw raw { get; set; }
    //}

    //public class File
    //{
    //    public Downloads downloads { get; set; }
    //    public bool executable { get; set; }
    //    public string type { get; set; }
    //}

    public class Lzma
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class Raw
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class Root
    {
        public File file { get; set; }
    }

    public class Item
    {
        public string path { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }
}

