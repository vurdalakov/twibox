namespace Vurdalakov
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public static class AssemblyExtensions
    {
        public static String GetFilePathName(this Assembly assembly)
        {
            return new Uri(assembly.CodeBase).LocalPath;
        }

        public static String GetFilePath(this Assembly assembly)
        {
            return Path.GetDirectoryName(assembly.GetFilePathName());
        }

        public static String FindResourceFile(this Assembly assembly, String fileName)
        {
            var resourceNames = assembly.GetManifestResourceNames();
            return resourceNames.FirstOrDefault(resourceName => resourceName.EndsWithNoCase(fileName));
        }

        public static String ReadResourceTextFile(this Assembly assembly, String resourceName)
        {
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
    }
}
