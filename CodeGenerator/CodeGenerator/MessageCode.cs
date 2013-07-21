using System;

namespace SilentOrbit.ProtocolBuffers
{
    static class MessageCode
    {
        public static void GenerateClass(ProtoMessage m, CodeWriter cw)
        {
            //Do not generate class code for external classes
            /*if (m.OptionExternal)
            {
                cw.Comment("Written elsewhere");
                cw.Comment(m.OptionAccess + " " + m.OptionType + " " + m.CsNamespace + "_" + m.CsType + " {}");
                return;
            }*/

            //Default class
            cw.Summary(m.Comments);
            cw.Bracket(m.OptionAccess + " " + m.OptionType + " " + m.CsNamespace + "_" + m.CsType);

            GenerateEnums(m, cw);

            GenerateProperties(m, cw);

            if (m.OptionPreserveUnknown)
            {
                cw.Summary("Values for unknown fields.");
                cw.WriteLine("public List<KeyValue> PreservedFields;");
                cw.WriteLine();
            }
            
            if (m.OptionTriggers)
            {
                cw.Comment("protected virtual void BeforeSerialize() {}");
                cw.Comment("protected virtual void AfterDeserialize() {}");
                cw.WriteLine();
            }
            
            foreach (ProtoMessage sub in m.Messages.Values)
            {
                GenerateClass(sub, cw);
                cw.WriteLine();
            }
            cw.EndBracket();
            return;
        }

        static void GenerateEnums(ProtoMessage m, CodeWriter cw)
        {
            foreach (ProtoEnum me in m.Enums.Values)
            {
                GenerateEnum(me, cw);
            }
        }

        public static void GenerateEnum(ProtoEnum me, CodeWriter cw)
        {
            cw.Bracket("public class " + me.CsNamespace + "_" + me.CsType + "Enum");
            foreach (var epair in me.Enums)
            {
                cw.Summary(epair.Comment);
                cw.WriteLine("public const int " + epair.Name + " = " + epair.Value + ";");
            }
            cw.EndBracket();
            cw.WriteLine();
        }

        /// <summary>
        /// Generates the properties.
        /// </summary>
        /// <param name='template'>
        /// if true it will generate only properties that are not included by default, because of the [generate=false] option.
        /// </param>
        static void GenerateProperties(ProtoMessage m, CodeWriter cw)
        {
            foreach (Field f in m.Fields.Values)
            {
                if (f.OptionExternal)
                    cw.WriteLine("//" + GenerateProperty(f) + " // Implemented by user elsewhere");
                else
                {
                    if (f.Comments != null) 
                        cw.Summary(f.Comments);
                    cw.WriteLine(GenerateProperty(f));
                    cw.WriteLine();
                } 
                
            }

            //Wire format field ID
#if DEBUG
            cw.Comment("ProtocolBuffers wire field id");
            foreach (Field f in m.Fields.Values)
            {
                cw.WriteLine("public const int " + f.CsName + "FieldID = " + f.ID + ";");
            }
#endif
        }

        static string GenerateProperty(Field f)
        {
            string type = f.ProtoType.FullCsType;
            if (f.ProtoType is ProtoEnum)
            {
                type = "int";
            }
            if (f.OptionCodeType != null)
                type = f.OptionCodeType;
            if (f.Rule == FieldRule.Repeated)
                type = type + "[]";

            if (f.OptionReadOnly)
                return f.OptionAccess + " readonly " + type + " " + f.CsName + " = new " + type + "();";
            else if (f.ProtoType is ProtoMessage && f.ProtoType.OptionType == "struct")
                return f.OptionAccess + " " + type + " " + f.CsName + ";";
            else
            {
                string s = "#if !CITO\n internal\n#endif\n " + type + " " + f.CsName + ";" + Environment.NewLine;
                s += f.OptionAccess + " " + type + " " + "Get" + f.CsName + "() { return " + f.CsName + "; } " + Environment.NewLine;
                if (f.Rule != FieldRule.Repeated)
                {
                    s += f.OptionAccess + " void Set" + f.CsName + "(" + type + " value) { " + f.CsName + " = " + "value; } " + Environment.NewLine;
                }
                else
                {
                    s += f.OptionAccess + " void Set" + f.CsName + "(" + type + " value, int count, int length) { " + f.CsName + " = " + "value; " + f.CsName + "Count = count; " + f.CsName + "Length = length; } " + Environment.NewLine;
                    s += "#if !CITO\n internal\n#endif\n int" + " " + f.CsName + "Count;" + Environment.NewLine;
                    s += f.OptionAccess + " int Get" + f.CsName + "Count() { return " + f.CsName + "Count; } " + Environment.NewLine;
                    s += "#if !CITO\n internal\n#endif\n int" + " " + f.CsName + "Length;" + Environment.NewLine;
                    s += f.OptionAccess + " int Get" + f.CsName + "Length() { return " + f.CsName + "Length; } " + Environment.NewLine;
                    s += f.OptionAccess + " void " + f.CsName + "Add(" + type.Replace("[]", "") + " value)";
                    s += string.Format("{{if({0}Count >= {0}Length)\n", f.CsName);
                    s += "{\n";
                    s += string.Format("{0}[] {1}2 = new {0}[{1}Length*2];\n", type.Replace("[]", ""), f.CsName);
                    s += string.Format("{0}Length = {0}Length*2;\n", f.CsName);

                    s += string.Format("for(int i=0;i<{0}Count;i++)\n", f.CsName);
                    s += "{\n";
                    s += string.Format("{0}2[i] = {0}[i];\n", f.CsName);
                    s += "}\n";
                    s += string.Format("{0}={0}2;\n", f.CsName);

                    s += "}\n";
                    s += string.Format("{0}[{0}Count] = value;\n", f.CsName);
                    s += string.Format("{0}Count++;\n", f.CsName);
                    s += "}" + Environment.NewLine;
                }

                return s;
            }
        }
    }
}

