using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Modelos
{

    public class Availability
    {
        public int group { get; set; }
        public int progress { get; set; }
    }

    public class Gamecore
    {
        [JsonProperty("java-runtime-alpha")]
        public List<object> javaruntimealpha { get; set; }

        [JsonProperty("java-runtime-beta")]
        public List<object> javaruntimebeta { get; set; }

        [JsonProperty("java-runtime-gamma")]
        public List<object> javaruntimegamma { get; set; }

        [JsonProperty("jre-legacy")]
        public List<object> jrelegacy { get; set; }

        [JsonProperty("minecraft-java-exe")]
        public List<object> minecraftjavaexe { get; set; }
    }

    public class JavaRuntimeAlpha
    {
        public Availability availability { get; set; }
        public Manifest manifest { get; set; }
        public Version version { get; set; }
    }

    public class JavaRuntimeBetum
    {
        public Availability availability { get; set; }
        public Manifest manifest { get; set; }
        public Version version { get; set; }
    }

    public class JavaRuntimeGamma
    {
        public Availability availability { get; set; }
        public Manifest manifest { get; set; }
        public Version version { get; set; }
    }

    public class JreLegacy
    {
        public Availability availability { get; set; }
        public Manifest manifest { get; set; }
        public Version version { get; set; }
    }

    public class Linux
    {
        [JsonProperty("java-runtime-alpha")]
        public List<JavaRuntimeAlpha> javaruntimealpha { get; set; }

        [JsonProperty("java-runtime-beta")]
        public List<JavaRuntimeBetum> javaruntimebeta { get; set; }

        [JsonProperty("java-runtime-gamma")]
        public List<JavaRuntimeGamma> javaruntimegamma { get; set; }

        [JsonProperty("jre-legacy")]
        public List<JreLegacy> jrelegacy { get; set; }

        [JsonProperty("minecraft-java-exe")]
        public List<object> minecraftjavaexe { get; set; }
    }

    public class LinuxI386
    {
        [JsonProperty("java-runtime-alpha")]
        public List<object> javaruntimealpha { get; set; }

        [JsonProperty("java-runtime-beta")]
        public List<object> javaruntimebeta { get; set; }

        [JsonProperty("java-runtime-gamma")]
        public List<object> javaruntimegamma { get; set; }

        [JsonProperty("jre-legacy")]
        public List<JreLegacy> jrelegacy { get; set; }

        [JsonProperty("minecraft-java-exe")]
        public List<object> minecraftjavaexe { get; set; }
    }

    public class MacOs
    {
        [JsonProperty("java-runtime-alpha")]
        public List<JavaRuntimeAlpha> javaruntimealpha { get; set; }

        [JsonProperty("java-runtime-beta")]
        public List<JavaRuntimeBetum> javaruntimebeta { get; set; }

        [JsonProperty("java-runtime-gamma")]
        public List<JavaRuntimeGamma> javaruntimegamma { get; set; }

        [JsonProperty("jre-legacy")]
        public List<JreLegacy> jrelegacy { get; set; }

        [JsonProperty("minecraft-java-exe")]
        public List<object> minecraftjavaexe { get; set; }
    }

    public class MacOsArm64
    {
        [JsonProperty("java-runtime-alpha")]
        public List<object> javaruntimealpha { get; set; }

        [JsonProperty("java-runtime-beta")]
        public List<object> javaruntimebeta { get; set; }

        [JsonProperty("java-runtime-gamma")]
        public List<JavaRuntimeGamma> javaruntimegamma { get; set; }

        [JsonProperty("jre-legacy")]
        public List<object> jrelegacy { get; set; }

        [JsonProperty("minecraft-java-exe")]
        public List<object> minecraftjavaexe { get; set; }
    }

    public class Manifest
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class MinecraftJavaExe
    {
        public Availability availability { get; set; }
        public Manifest manifest { get; set; }
        public Version version { get; set; }
    }

    public class java
    {
        public Gamecore gamecore { get; set; }
        public Linux linux { get; set; }

        [JsonProperty("linux-i386")]
        public LinuxI386 linuxi386 { get; set; }

        [JsonProperty("mac-os")]
        public MacOs macos { get; set; }

        [JsonProperty("mac-os-arm64")]
        public MacOsArm64 macosarm64 { get; set; }

        [JsonProperty("windows-x64")]
        public WindowsX64 windowsx64 { get; set; }

        [JsonProperty("windows-x86")]
        public WindowsX86 windowsx86 { get; set; }
    }

    public class Version
    {
        public string name { get; set; }
        public DateTime released { get; set; }
    }

    public class WindowsX64
    {
        [JsonProperty("java-runtime-alpha")]
        public List<JavaRuntimeAlpha> javaruntimealpha { get; set; }

        [JsonProperty("java-runtime-beta")]
        public List<JavaRuntimeBetum> javaruntimebeta { get; set; }

        [JsonProperty("java-runtime-gamma")]
        public List<JavaRuntimeGamma> javaruntimegamma { get; set; }

        [JsonProperty("jre-legacy")]
        public List<JreLegacy> jrelegacy { get; set; }

        [JsonProperty("minecraft-java-exe")]
        public List<MinecraftJavaExe> minecraftjavaexe { get; set; }
    }

    public class WindowsX86
    {
        [JsonProperty("java-runtime-alpha")]
        public List<JavaRuntimeAlpha> javaruntimealpha { get; set; }

        [JsonProperty("java-runtime-beta")]
        public List<JavaRuntimeBetum> javaruntimebeta { get; set; }

        [JsonProperty("java-runtime-gamma")]
        public List<JavaRuntimeGamma> javaruntimegamma { get; set; }

        [JsonProperty("jre-legacy")]
        public List<JreLegacy> jrelegacy { get; set; }

        [JsonProperty("minecraft-java-exe")]
        public List<MinecraftJavaExe> minecraftjavaexe { get; set; }
    }

}
