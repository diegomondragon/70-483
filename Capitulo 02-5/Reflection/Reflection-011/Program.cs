﻿using Microsoft.CSharp;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_011
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeCompileUnit compileUnit = new CodeCompileUnit();

            CodeNamespace myNamespace = new CodeNamespace("MyNamespace");

            myNamespace.Imports.Add(new CodeNamespaceImport("System"));

            CodeTypeDeclaration myclass = new CodeTypeDeclaration("MyClass");

            CodeEntryPointMethod start = new CodeEntryPointMethod();

            CodeMethodInvokeExpression cs1 = new CodeMethodInvokeExpression(
                new CodeTypeReferenceExpression("Console"),
                "WriteLine", new CodePrimitiveExpression("Hello World"));


            compileUnit.Namespaces.Add(myNamespace);
            myNamespace.Types.Add(myclass);
            myclass.Members.Add(start);
            start.Statements.Add(cs1);

            CSharpCodeProvider provider = new CSharpCodeProvider();

            using (StreamWriter sw = new StreamWriter("HelloWorld.cs", false))
            {
                IndentedTextWriter tw = new IndentedTextWriter(sw, "   ");
                provider.GenerateCodeFromCompileUnit(compileUnit, tw, new CodeGeneratorOptions());
                tw.Close();
            }

        }
    }
}
