#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AffiseAttributionLib.Editor.Config;
using UnityEditor.Android;

namespace AffiseAttributionLib.Editor.Build
{
    internal class ModulesAndroidPostProcessBuild : IPostGenerateGradleAndroidProject
    {
        private const string GradleFile = "build.gradle";
        private const string ModulesComment = "//// BUILD SETTINGS AFFISE MODULES ////";

        public int callbackOrder => 1;

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            var gradlePath = GetBuildPath(path, GradleFile);
            AddDependencies(gradlePath);
        }

        private string GetBuildPath(string basePath, string path) => Path.Join(basePath, path);

        private void AddDependencies(string gradlePath)
        {
            var result = new List<string>();

            var dependencies = AffiseEditorConfig.GetDependencies().Item1;
            var allModulesNames = AffiseEditorConfig.GetAllModulesNames().Item1;

            var gradleContent = File.ReadAllText(gradlePath);
            var textLines = gradleContent
                .Replace("\r\n", "\n")
                .Replace("\r", "\n")
                .Split(new[] { '\n' });

            var inDependencies = false;
            var updated = false;

            foreach (var line in textLines) //line loop
            {
                if (line == "dependencies {")
                {
                    inDependencies = true;
                }
                else
                {
                    switch (inDependencies)
                    {
                        // add new dependencies at section end
                        case true when line == "}":
                        {
                            inDependencies = false;
                            result.Add($"    {ModulesComment}");
                            foreach (var dependency in dependencies) //dependencies loop
                            {
                                if (string.IsNullOrWhiteSpace(dependency.Module)) continue; //dependencies loop
                                // add new dependencies
                                result.Add($"    implementation '{dependency.Module}:{dependency.Version}'");
                                updated = true;
                            }
                            result.Add($"    {ModulesComment}");
                            break;
                        }
                        // remove all old dependencies
                        case true when allModulesNames.Any(name => line.Contains(name)):
                            updated = true;
                            continue; //line loop
                        case true when line.Contains(ModulesComment):
                            updated = true;
                            continue; //line loop
                    }
                }

                result.Add(line);
            }

            if (!updated) return;

            File.WriteAllText(gradlePath, string.Join("\n", result) + "\n");
        }
    }
}