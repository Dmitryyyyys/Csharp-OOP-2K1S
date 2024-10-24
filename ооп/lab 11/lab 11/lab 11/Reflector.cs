using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Laba_11
{
    public static class Reflector
    {
        const string nameSpace = "Laba_11.";
        public const string pathW = "C:\\labs\\ооп\\lab 11\\lab 11\\lab 11\\fileR.txt";
        public const string pathR = "C:\\labs\\ооп\\lab 11\\lab 11\\lab 11\\fileW.txt";
        public static StreamWriter file = new(pathW, false);
        public static StreamReader fileR = new(pathR);


        public static void GetAssembly(string classname)
        {
            try
            {
                var TypeAssembly = nameSpace + classname;
                var mitype = Type.GetType(TypeAssembly, false, true);
                using (StreamWriter file = new StreamWriter(pathW, false))
                {
                    file.WriteLine($"{TypeAssembly}.Assembly: {mitype.Assembly}");
                }
                Console.WriteLine("Write assembly to file");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
        }

        public static void GetConstructor(string classname)
        {
            try
            {
                classname = nameSpace + classname;
                Type classType = Type.GetType(classname, false, true);
                using (StreamWriter file = new StreamWriter(pathW, false))
                {
                    file.WriteLine($"\nPublic Constructors of {classname}:");
                    if (classType.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Length == 0)
                    {
                        file.WriteLine("\tNo public constructors");
                    }
                    else
                    {
                        file.WriteLine($"\nPuclic Constructors count {classType.GetConstructors(BindingFlags.Public).Length}:");
                        foreach (var constructor in classType.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
                        {
                            file.WriteLine($"\t {constructor}");
                        }
                    }
                }
                Console.WriteLine("Write constructors to file");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
        }


        public static void GetMethods(string classname)
        {
            try
            {
                var typeName = nameSpace + classname;
                Type classType = Type.GetType(typeName, false, true);
                using (StreamWriter file = new StreamWriter(pathW, false))
                {
                    file.WriteLine($"\nPublic Methods of {classname}:");

                    var methods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
                    if (methods.Length == 0)
                    {
                        file.WriteLine("\tNo public methods");
                    }
                    else
                    {
                        file.WriteLine($"\nPublic Methods count {methods.Length}:");
                        foreach (var method in methods)
                        {
                            file.WriteLine($"\t {method}");
                        }
                    }
                    Console.WriteLine("Write methods to file");
                    file.WriteLine("\n");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void GetFields(string classname)
        {
            try
            {
                var typeName = nameSpace + classname;
                Type classType = Type.GetType(typeName, false, true);
                using (StreamWriter file = new StreamWriter(pathW, false))
                {
                    file.WriteLine("Fields:");
                    foreach (var field in classType.GetFields())
                    {
                        file.WriteLine(field);
                    }
                    Console.WriteLine("Write fields to file");
                    file.WriteLine("\n");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void GetProperties(string classname)
        {
            try
            {
                var typeName = nameSpace + classname;
                Type classType = Type.GetType(typeName, false, true);
                using (StreamWriter file = new StreamWriter(pathW, false))
                {
                    file.WriteLine("Properties:");
                    foreach (var property in classType.GetProperties())
                    {
                        file.WriteLine(property);
                    }
                    Console.WriteLine("Write properties to file");
                    file.WriteLine("\n");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void GetInterfaces(string classname)
        {
            try
            {
                var typeName = nameSpace + classname;
                Type classType = Type.GetType(typeName, false, true);
                using (StreamWriter file = new StreamWriter(pathW, false))
                {
                    file.WriteLine("Interfaces:");
                    foreach (var inter in classType.GetInterfaces())
                    {
                        file.WriteLine(inter);
                    }
                    Console.WriteLine("Write interfaces to file");
                    file.WriteLine("\n");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void GetMethodsByParam(string classname, string param)
        {
            try
            {
                var typeName = nameSpace + classname;
                Type classType = Type.GetType(typeName, false, true);
                using (StreamWriter file = new StreamWriter(pathW, false))
                {
                    file.WriteLine("Param Methods:");
                    foreach (var method in classType.GetMethods())
                    {
                        foreach (var parametr in method.GetParameters())
                        {
                            if (parametr.ParameterType.Name == param)
                            {
                                file.WriteLine(method);
                            }
                        }
                    }
                    Console.WriteLine("Write Param Methods to file");
                    file.WriteLine("\n");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while writing to the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void CallMethod(Type type, string methodName, object[] parameters)
        {
            try
            {
                var method = type.GetMethod(methodName);
                method.Invoke(null, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static void Invoke(string name, string method)
        {
            try
            {
                var param = new List<string>
        {
            fileR.ReadLine(),
            fileR.ReadLine(),
            fileR.ReadLine()
        };
                var parms = new object[] { param };
                var type = Type.GetType(name);
                var obj = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(method);
                var result = methodInfo.Invoke(obj, parms);
                Console.WriteLine(result);
                Console.WriteLine("\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"An error occurred while reading from the file: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public static object Create(string name, object[] parm)
        {
            try
            {
                var TypeName = nameSpace + name;
                var miType = Type.GetType(TypeName, false, true);
                var obj = Activator.CreateInstance(miType, parm);
                Console.WriteLine(obj.ToString());
                return obj;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}

