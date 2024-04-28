
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace SwiftTools.Tests
{
    /// <summary>
    /// !!! WARNING 
    /// !!! Project structure test.
    /// !!! DON'T CHANGE IT! 
    /// !!! Changes may cause the solution to be rejected.
    /// </summary>
    public class ModelStructureTest
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// !!! WARNING 
        /// !!! Project structure test.
        /// !!! DON'T CHANGE IT! 
        /// !!! Changes may cause the solution to be rejected.
        /// </summary>
        [Test]
        public void StructureTest()
        {
            
            Assembly assembly;
            Type type;
            Type methodReturnType;
            MethodInfo method;
            int methodsCount;
            ParameterInfo parameter;
            int parametersCount;
            int constructorsCount;
            List<string> constructorParameterNameTypeDictionary;
            ConstructorInfo constructor;
            int fieldsCount;
            FieldInfo field;
            Type fieldReturnType;
            PropertyInfo property;
            int propertiesCount;
            Type propertyReturnType;
            assembly = Assembly.Load(Decode("U3dpZnRUb29scy5Nb2RlbCwgVmVyc2lvbj0xLjAuMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPW51bGw=") /*"SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null"*/ );
            Assert.IsNotNull(assembly, "Missing  SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");

                type = assembly.GetTypes().FirstOrDefault(x=>x.FullName == Decode("U3dpZnRUb29scy5Nb2RlbC5FbXB0eUxpbmVzRXhjZXB0aW9u") /*"SwiftTools.Model.EmptyLinesException"*/ );
                Assert.IsNotNull(type, "Missing assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.EmptyLinesException");
                    Assert.IsTrue(type.IsClass, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.EmptyLinesException is not class");
                    Assert.IsTrue(type.IsPublic, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.EmptyLinesException is not public class");
                        constructorParameterNameTypeDictionary = new List<string>();
                            constructorParameterNameTypeDictionary.Add("System.Int32[]");
                            constructor = type.GetConstructors().FirstOrDefault(x=>x.GetParameters().Select(y=>y.ParameterType.FullName).SequenceEqual(constructorParameterNameTypeDictionary));
                            Assert.IsNotNull(constructor, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.EmptyLinesException(Int32[] incorrectLines) does not exists");
                                parametersCount = constructor.GetParameters().Length;
                                Assert.AreEqual(1,parametersCount, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.EmptyLinesException(Int32[] incorrectLines)  parameters count has changed");
                                parameter = constructor.GetParameters().FirstOrDefault(x=>x.Name == Decode("aW5jb3JyZWN0TGluZXM=") /*"incorrectLines"*/  && x.ParameterType.FullName == "System.Int32[]");
                                Assert.IsNotNull(parameter, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.EmptyLinesException(Int32[] incorrectLines) parameter incorrectLines does not exists or does not have type System.Int32[]");

                type = assembly.GetTypes().FirstOrDefault(x=>x.FullName == Decode("U3dpZnRUb29scy5Nb2RlbC5JbmNvcnJlY3RDaGFy") /*"SwiftTools.Model.IncorrectChar"*/ );
                Assert.IsNotNull(type, "Missing assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar");
                    Assert.IsTrue(type.IsClass, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar is not class");
                    Assert.IsTrue(type.IsPublic, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar is not public class");
                        constructorParameterNameTypeDictionary = new List<string>();
                            constructor = type.GetConstructors().FirstOrDefault(x=>x.GetParameters().Select(y=>y.ParameterType.FullName).SequenceEqual(constructorParameterNameTypeDictionary));
                            Assert.IsNotNull(constructor, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar() does not exists");
                            property = type.GetProperties().Union(type.GetProperties().Where(x=>type.GetInterfaces().SelectMany(y=>y.GetProperties().Select(s=>s.Name)).Any(y => y == x.Name))).FirstOrDefault(x=>x.Name == Decode("SW5kZXg=") /*"Index"*/ );
                            Assert.IsNotNull(property, "property: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.Int32 Index does not exists");
                                method = type.GetMethods().FirstOrDefault(x=>x.Name == Decode("Z2V0X0luZGV4") /*"get_Index"*/ );                                Assert.IsNotNull(method, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_Index() does not exists");
                                Assert.IsTrue(method.IsPublic, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_Index() is not public");
                                methodReturnType = method.ReturnType;
                                Assert.AreEqual("System.Int32",methodReturnType.FullName, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_Index() return type has changed");
                                method = type.GetMethods().FirstOrDefault(x=>x.Name == Decode("Z2V0X0luZGV4") /*"get_Index"*/ );                                Assert.IsNotNull(method, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_Index() does not exists");
                                Assert.IsTrue(method.IsPublic, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_Index() is not public");
                                methodReturnType = method.ReturnType;
                                Assert.AreEqual("System.Int32",methodReturnType.FullName, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_Index() return type has changed");
                            propertyReturnType = property.PropertyType;
                            Assert.AreEqual("System.Int32",propertyReturnType.FullName, "property: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.Int32 Index  type has changed");
                            property = type.GetProperties().Union(type.GetProperties().Where(x=>type.GetInterfaces().SelectMany(y=>y.GetProperties().Select(s=>s.Name)).Any(y => y == x.Name))).FirstOrDefault(x=>x.Name == Decode("SW5jb3JyZWN0Q2hhcmFjdGVy") /*"IncorrectCharacter"*/ );
                            Assert.IsNotNull(property, "property: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.Char IncorrectCharacter does not exists");
                                method = type.GetMethods().FirstOrDefault(x=>x.Name == Decode("Z2V0X0luY29ycmVjdENoYXJhY3Rlcg==") /*"get_IncorrectCharacter"*/ );                                Assert.IsNotNull(method, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_IncorrectCharacter() does not exists");
                                Assert.IsTrue(method.IsPublic, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_IncorrectCharacter() is not public");
                                methodReturnType = method.ReturnType;
                                Assert.AreEqual("System.Char",methodReturnType.FullName, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_IncorrectCharacter() return type has changed");
                                method = type.GetMethods().FirstOrDefault(x=>x.Name == Decode("Z2V0X0luY29ycmVjdENoYXJhY3Rlcg==") /*"get_IncorrectCharacter"*/ );                                Assert.IsNotNull(method, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_IncorrectCharacter() does not exists");
                                Assert.IsTrue(method.IsPublic, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_IncorrectCharacter() is not public");
                                methodReturnType = method.ReturnType;
                                Assert.AreEqual("System.Char",methodReturnType.FullName, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.get_IncorrectCharacter() return type has changed");
                            propertyReturnType = property.PropertyType;
                            Assert.AreEqual("System.Char",propertyReturnType.FullName, "property: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectChar.Char IncorrectCharacter  type has changed");

                type = assembly.GetTypes().FirstOrDefault(x=>x.FullName == Decode("U3dpZnRUb29scy5Nb2RlbC5JbmNvcnJlY3RMaW5lc0V4Y2VwdGlvbg==") /*"SwiftTools.Model.IncorrectLinesException"*/ );
                Assert.IsNotNull(type, "Missing assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectLinesException");
                    Assert.IsTrue(type.IsClass, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectLinesException is not class");
                    Assert.IsTrue(type.IsPublic, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectLinesException is not public class");
                        constructorParameterNameTypeDictionary = new List<string>();
                            constructorParameterNameTypeDictionary.Add("System.Int32[]");
                            constructor = type.GetConstructors().FirstOrDefault(x=>x.GetParameters().Select(y=>y.ParameterType.FullName).SequenceEqual(constructorParameterNameTypeDictionary));
                            Assert.IsNotNull(constructor, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectLinesException(Int32[] incorrectLines) does not exists");
                                parametersCount = constructor.GetParameters().Length;
                                Assert.AreEqual(1,parametersCount, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectLinesException(Int32[] incorrectLines)  parameters count has changed");
                                parameter = constructor.GetParameters().FirstOrDefault(x=>x.Name == Decode("aW5jb3JyZWN0TGluZXM=") /*"incorrectLines"*/  && x.ParameterType.FullName == "System.Int32[]");
                                Assert.IsNotNull(parameter, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.IncorrectLinesException(Int32[] incorrectLines) parameter incorrectLines does not exists or does not have type System.Int32[]");

                type = assembly.GetTypes().FirstOrDefault(x=>x.FullName == Decode("U3dpZnRUb29scy5Nb2RlbC5NVDEwMU1lc3NhZ2U=") /*"SwiftTools.Model.MT101Message"*/ );
                Assert.IsNotNull(type, "Missing assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message");
                    Assert.IsTrue(type.IsClass, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message is not class");
                    Assert.IsTrue(type.IsPublic, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message is not public class");
                        constructorParameterNameTypeDictionary = new List<string>();
                            constructor = type.GetConstructors().FirstOrDefault(x=>x.GetParameters().Select(y=>y.ParameterType.FullName).SequenceEqual(constructorParameterNameTypeDictionary));
                            Assert.IsNotNull(constructor, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message() does not exists");
                            property = type.GetProperties().Union(type.GetProperties().Where(x=>type.GetInterfaces().SelectMany(y=>y.GetProperties().Select(s=>s.Name)).Any(y => y == x.Name))).FirstOrDefault(x=>x.Name == Decode("UmF3") /*"Raw"*/ );
                            Assert.IsNotNull(property, "property: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message.String Raw does not exists");
                                method = type.GetMethods().FirstOrDefault(x=>x.Name == Decode("Z2V0X1Jhdw==") /*"get_Raw"*/ );                                Assert.IsNotNull(method, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message.get_Raw() does not exists");
                                Assert.IsTrue(method.IsPublic, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message.get_Raw() is not public");
                                methodReturnType = method.ReturnType;
                                Assert.AreEqual("System.String",methodReturnType.FullName, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message.get_Raw() return type has changed");
                                method = type.GetMethods().FirstOrDefault(x=>x.Name == Decode("Z2V0X1Jhdw==") /*"get_Raw"*/ );                                Assert.IsNotNull(method, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message.get_Raw() does not exists");
                                Assert.IsTrue(method.IsPublic, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message.get_Raw() is not public");
                                methodReturnType = method.ReturnType;
                                Assert.AreEqual("System.String",methodReturnType.FullName, "method: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message.get_Raw() return type has changed");
                            propertyReturnType = property.PropertyType;
                            Assert.AreEqual("System.String",propertyReturnType.FullName, "property: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MT101Message.String Raw  type has changed");

                type = assembly.GetTypes().FirstOrDefault(x=>x.FullName == Decode("U3dpZnRUb29scy5Nb2RlbC5NVEZvcm1hdEV4Y2VwdGlvbg==") /*"SwiftTools.Model.MTFormatException"*/ );
                Assert.IsNotNull(type, "Missing assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MTFormatException");
                    Assert.IsTrue(type.IsClass, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MTFormatException is not class");
                    Assert.IsTrue(type.IsPublic, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MTFormatException is not public class");
                        constructorParameterNameTypeDictionary = new List<string>();
                            constructor = type.GetConstructors().FirstOrDefault(x=>x.GetParameters().Select(y=>y.ParameterType.FullName).SequenceEqual(constructorParameterNameTypeDictionary));
                            Assert.IsNotNull(constructor, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.MTFormatException() does not exists");

                type = assembly.GetTypes().FirstOrDefault(x=>x.FullName == Decode("U3dpZnRUb29scy5Nb2RlbC5Ob0RhdGFFeGNlcHRpb24=") /*"SwiftTools.Model.NoDataException"*/ );
                Assert.IsNotNull(type, "Missing assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NoDataException");
                    Assert.IsTrue(type.IsClass, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NoDataException is not class");
                    Assert.IsTrue(type.IsPublic, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NoDataException is not public class");
                        constructorParameterNameTypeDictionary = new List<string>();
                            constructor = type.GetConstructors().FirstOrDefault(x=>x.GetParameters().Select(y=>y.ParameterType.FullName).SequenceEqual(constructorParameterNameTypeDictionary));
                            Assert.IsNotNull(constructor, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NoDataException() does not exists");

                type = assembly.GetTypes().FirstOrDefault(x=>x.FullName == Decode("U3dpZnRUb29scy5Nb2RlbC5Ob3RBbGxvd2VkQ2hhcmFjdGVyc0V4Y2VwdGlvbg==") /*"SwiftTools.Model.NotAllowedCharactersException"*/ );
                Assert.IsNotNull(type, "Missing assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NotAllowedCharactersException");
                    Assert.IsTrue(type.IsClass, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NotAllowedCharactersException is not class");
                    Assert.IsTrue(type.IsPublic, "assembly: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NotAllowedCharactersException is not public class");
                        constructorParameterNameTypeDictionary = new List<string>();
                            constructorParameterNameTypeDictionary.Add("SwiftTools.Model.IncorrectChar[]");
                            constructor = type.GetConstructors().FirstOrDefault(x=>x.GetParameters().Select(y=>y.ParameterType.FullName).SequenceEqual(constructorParameterNameTypeDictionary));
                            Assert.IsNotNull(constructor, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NotAllowedCharactersException(IncorrectChar[] incorrectChars) does not exists");
                                parametersCount = constructor.GetParameters().Length;
                                Assert.AreEqual(1,parametersCount, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NotAllowedCharactersException(IncorrectChar[] incorrectChars)  parameters count has changed");
                                parameter = constructor.GetParameters().FirstOrDefault(x=>x.Name == Decode("aW5jb3JyZWN0Q2hhcnM=") /*"incorrectChars"*/  && x.ParameterType.FullName == "SwiftTools.Model.IncorrectChar[]");
                                Assert.IsNotNull(parameter, "constructor: SwiftTools.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null:SwiftTools.Model.NotAllowedCharactersException(IncorrectChar[] incorrectChars) parameter incorrectChars does not exists or does not have type SwiftTools.Model.IncorrectChar[]");


        }

        /// <summary>
        /// !!! WARNING 
        /// !!! Project structure test.
        /// !!! DON'T CHANGE IT! 
        /// !!! Changes may cause the solution to be rejected.
        /// </summary>
        private string Decode(string text)
        {
            return System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(text));
        }
    }
}
