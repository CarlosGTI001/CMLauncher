﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLauncher.Modelos
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class descargarVersion
    {
        public Arguments arguments { get; set; }
        public AssetIndex assetIndex { get; set; }
        public string assets { get; set; }
        public string complianceLevel { get; set; }
        public Downloads downloads { get; set; }
        public string id { get; set; }
        public JavaVersion javaVersion { get; set; }
        public List<Library> libraries { get; set; }
        public Logging logging { get; set; }
        public string mainClass { get; set; }
        public string minimumLauncherVersion { get; set; }
        public DateTime releaseTime { get; set; }
        public DateTime time { get; set; }
        public string type { get; set; }
    }

    public class Arguments
    {
        public List<object> game { get; set; }
        public List<object> jvm { get; set; }
    }

    public class Artifact
    {
        public string path { get; set; }
        public string sha1 { get; set; }
        public double size { get; set; }
        public string url { get; set; }
    }

    public class AssetIndex
    {
        public string id { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public int totalSize { get; set; }
        public string url { get; set; }
    }

    public class Client
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
        public string argument { get; set; }
        public File file { get; set; }
        public string type { get; set; }
    }

    public class ClientMappings
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class Downloads
    {
        public Client client { get; set; }
        public ClientMappings client_mappings { get; set; }
        public Server server { get; set; }
        public ServerMappings server_mappings { get; set; }
        public Artifact artifact { get; set; }
    }

    public class File
    {
        public string id { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class JavaVersion
    {
        public string component { get; set; }
        public string majorVersion { get; set; }
    }

    public class Library
    {
        public Downloads downloads { get; set; }
        public string name { get; set; }
        public List<Rule> rules { get; set; }
    }

    public class Logging
    {
        public Client client { get; set; }
    }

    public class Os
    {
        public string name { get; set; }
    }



    public class Rule
    {
        public string action { get; set; }
        public Os os { get; set; }
    }

    public class Server
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class ServerMappings
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }
}
