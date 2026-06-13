// SharpOnvif
// Copyright (C) 2026 Lukas Volf
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace SharpOnvifClient
{
#if NET5_0_OR_GREATER
    internal static class XmlSerializerLoader
    {
        // XmlSerializer probes for pre-generated *.XmlSerializers.dll via Assembly.Load() by name.
        // In .NET Core, Assembly.Load() only resolves assemblies that are in deps.json; it does not
        // fall back to probing the app directory even if the file is physically present there.
        // When running from project references (not NuGet packages) the XmlSerializers assemblies
        // are copied to the output directory but are absent from deps.json, so Assembly.Load()
        // throws FileNotFoundException. This handler intercepts those failures and loads the DLL
        // directly from the app base directory, restoring the pre-generated serializer behavior.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2255", Justification = "Intentional: registers an AssemblyLoadContext resolver for pre-generated XmlSerializer assemblies in project-reference builds.")]
        [System.Runtime.CompilerServices.ModuleInitializer]
        internal static void Initialize()
        {
            System.Runtime.Loader.AssemblyLoadContext.Default.Resolving += (context, name) =>
            {
                if (!name.Name.EndsWith(".XmlSerializers", System.StringComparison.OrdinalIgnoreCase))
                    return null;

                string path = System.IO.Path.Combine(System.AppContext.BaseDirectory, name.Name + ".dll");
                return System.IO.File.Exists(path) ? context.LoadFromAssemblyPath(path) : null;
            };
        }
    }
#endif
}
