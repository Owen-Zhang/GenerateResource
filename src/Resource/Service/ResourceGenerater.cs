using Resource.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;

namespace Resource.Service
{
    internal class ResourceGenerater
    {
        internal static void GenerateResxFile(List<ResourceModel> resourceList)
        {
            var resourceName = Util.GetAppSettings("ResourceName");

            string tempResxFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", string.Format("{0}.resx", resourceName));
            Util.CreateFolder(tempResxFile);

            using (var writer = new ResXResourceWriter(tempResxFile))
            {
                foreach (var item in resourceList)
                    writer.AddResource(item.Key, item.Chinese);
            }
            string designFilePath = tempResxFile.Replace(".resx", ".designer.cs");

            var codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
            
            var keyValues = new Dictionary<object, object>();
            using (ResXResourceReader rsxr = new ResXResourceReader(tempResxFile))
            {
                rsxr.BasePath = new FileInfo(tempResxFile).Directory.FullName;
                rsxr.UseResXDataNodes = true;

                foreach (DictionaryEntry entry in rsxr)
                    keyValues.Add(entry.Key, entry.Value);
            }

            string[] unmatchedElements;
            var code = System.Resources.Tools.StronglyTypedResourceBuilder.Create(
                           keyValues,
                           resourceName,
                           Util.GetAppSettings("NameSpace"),
                           codeProvider,
                           false,
                           out unmatchedElements);

            using (StreamWriter writer = new StreamWriter(designFilePath, false, System.Text.Encoding.UTF8))
            {
                codeProvider.GenerateCodeFromCompileUnit(code, writer, new System.CodeDom.Compiler.CodeGeneratorOptions());
            }
        }
    }
}
