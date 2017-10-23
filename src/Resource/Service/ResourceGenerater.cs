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
            var nameSpace = Util.GetAppSettings("NameSpace");

            GenerateChinese(resourceName, nameSpace, resourceList);
        }

        private static void GenerateChinese(string resourceName, string nameSpace, List<ResourceModel> resourceList)
        {
            string tempChineseResxFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", string.Format("{0}.resx", resourceName));
            Util.CreateFolder(tempChineseResxFile);

            using (var writer = new ResXResourceWriter(tempChineseResxFile))
            {
                foreach (var item in resourceList)
                    writer.AddResource(item.Key, item.Chinese);
            }

            string tempEnglishResxFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", string.Format("{0}.en-US.resx", resourceName));

            using (var writer = new ResXResourceWriter(tempEnglishResxFile))
            {
                foreach (var item in resourceList)
                    writer.AddResource(item.Key, item.English);
            }
            //繁体
            string tempTraditionalResxFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Temp", string.Format("{0}.zh-HK.resx", resourceName));

            using (var writer = new ResXResourceWriter(tempTraditionalResxFile))
            {
                foreach (var item in resourceList)
                    writer.AddResource(item.Key, item.Traditional);
            }


            string designChineseFilePath = tempChineseResxFile.Replace(".resx", ".designer.cs");

            var codeProvider = new Microsoft.CSharp.CSharpCodeProvider();

            var keyValues = new Dictionary<object, object>();
            using (ResXResourceReader rsxr = new ResXResourceReader(tempChineseResxFile))
            {
                rsxr.BasePath = new FileInfo(tempChineseResxFile).Directory.FullName;
                rsxr.UseResXDataNodes = true;

                foreach (DictionaryEntry entry in rsxr)
                    keyValues.Add(entry.Key, entry.Value);
            }

            string[] unmatchedElements;
            var code = System.Resources.Tools.StronglyTypedResourceBuilder.Create(
                           keyValues,
                           resourceName,
                           nameSpace,
                           codeProvider,
                           false,
                           out unmatchedElements);

            using (StreamWriter writer = new StreamWriter(designChineseFilePath, false, System.Text.Encoding.UTF8))
            {
                codeProvider.GenerateCodeFromCompileUnit(code, writer, new System.CodeDom.Compiler.CodeGeneratorOptions());
            }
        }
    }
}
