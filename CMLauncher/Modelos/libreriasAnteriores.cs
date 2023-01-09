using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Modelos
{
    public class libreriasAnteriores
    {
        public class Artifact
        {
            public string path { get; set; }
            public string sha1 { get; set; }
            public int size { get; set; }
            public string url { get; set; }
        }

        public class Downloads
        {
            public Artifact artifact { get; set; }
        }

        public class Library
        {
            public Downloads downloads { get; set; }
            public string name { get; set; }
        }

        public class Root
        {
            public List<Library> libraries { get; set; }
        }
    }
}
