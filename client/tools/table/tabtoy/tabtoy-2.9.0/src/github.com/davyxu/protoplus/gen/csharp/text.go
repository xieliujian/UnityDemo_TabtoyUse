package csharp

// 报错行号+7
const TemplateText = `// Generated by github.com/davyxu/protoplus
// DO NOT EDIT!
using System;
using System.Collections.Generic;
using ProtoPlus;

namespace {{.PackageName}}
{
	{{range $a, $enumobj := .Enums}}
	public enum {{.Name}} 
	{
		{{range .Fields}}
		{{.Name}} = {{PbTagNumber $enumobj .}}, {{end}}
	} {{end}}
	{{range $a, $obj := .Structs}}
	{{ObjectLeadingComment .}}
	public partial class {{$obj.Name}} : {{$.StructBase}} 
	{
		{{range .Fields}}public {{CSTypeNameFull .}} {{.Name}};
		{{end}}
		#region Serialize Code
		public void Init( )
		{   {{range .Fields}}{{if IsPrimitiveSlice .}}
			{{.Name}} = new {{CSTypeNameFull .}}();	{{end}}{{end}}
 			{{range .Fields}}{{if IsStruct .}}
			{{.Name}} = ({{CSTypeNameFull .}}) InputStream.CreateStruct(typeof({{CSTypeNameFull .}})); {{end}} {{end}}
		}

		public void Marshal(OutputStream stream)
		{ {{range .Fields}} 
			stream.Write{{CodecName .}}({{PbTagNumber $obj .}}, {{.Name}} ); {{end}}
		}

		public int GetSize()
		{
			int size = 0; {{range .Fields}} 
			size += OutputStream.Size{{CodecName .}}({{PbTagNumber $obj .}}, {{.Name}}); {{end}}
			return size;
		}

 		public bool Unmarshal(InputStream stream, int fieldNumber, WireFormat.WireType wt)
		{
		 	switch (fieldNumber)
            { {{range .Fields}}
			case {{PbTagNumber $obj .}}:	
				stream.Read{{CodecName .}}(wt, ref {{.Name}});
                break; {{end}}
			default:
				return true;
            }

            return false;
		}
		#endregion
	}
{{end}}

{{if .RegEntry}}
	public static class MessageMetaRegister
    {
		public static void RegisterGeneratedMeta(MessageMeta meta)
		{	{{range .Structs}}{{ if IsMessage .}}
            meta.RegisterMeta(new MetaInfo
            {
				Type = typeof({{.Name}}),	
				ID = {{StructMsgID .}}, 	
				SourcePeer = "{{GetSourcePeer .}}",
				TargetPeer = "{{GetTargetPeer .}}",
            });{{end}} {{end}}
		}
    }
{{end}}
}
`