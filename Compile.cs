using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Globalization;

namespace FinalLFA
{
    public class Compile
    {
        public void CompileFile()
        {
            var Provider = CodeDomProvider.CreateProvider("CSharp");
            var Parameters = new CompilerParameters()
            {
                GenerateExecutable = true,
                OutputAssembly = "FileCode",
                GenerateInMemory = false,
                TreatWarningsAsErrors = false
            };
            CompilerResults Results = Provider.CompileAssemblyFromFile(Parameters, "");
            
            if (Results.Errors.Count > 0)
            {
                var errors = "";

                foreach (CompilerError CompErr in Results.Errors)
                {
                    errors = errors + "Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber + ", '" + CompErr.ErrorText + ";\n";
                }
            }
        }

        
    }
        
}
