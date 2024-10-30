using Microsoft.VisualBasic.FileIO;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CommandParser
{
    public class CommandParser
    {
        public static SchemaStruct parse<SchemaStruct>(string[] args) where SchemaStruct : struct
        {
            Type type = typeof(SchemaStruct);
            
            SchemaStruct returnType = new SchemaStruct();

            Dictionary<string, string> fields = new Dictionary<string, string>();
            string key = null;
            foreach (string arg in args)
            {
                if (arg.StartsWith("--")) {
                    key = arg.TrimStart('-');
                }
                else
                {
                    fields.Add(key, arg);
                }
            }

            foreach (FieldInfo field in type.GetFields())
            {
                Type x = field.FieldType;
                string name = field.Name;

                if (field == null) { continue; }
                if (fields.ContainsKey(name))
                {
                    // TODO: make sure this cannot fail
                    var ValueForField = Convert.ChangeType(fields[name], x);
                    field.SetValueDirect(__makeref(returnType), ValueForField);
                }
            }

            return returnType;
        }
    }
}
