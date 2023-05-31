package gosrc

// 报错行号+3
const templateText = `// Generated by github.com/davyxu/tabtoy
// DO NOT EDIT!!
// Version: {{.Version}}
package {{.PackageName}}

{{range $sn, $objName := $.Types.EnumNames}}
type {{$objName}} int32
const (	{{range $fi,$field := $.Types.AllFieldByName $objName}}
	{{$objName}}_{{$field.FieldName}} = {{$field.Value}} // {{$field.Name}} {{end}}
)

var (
	{{$objName}}MapperValueByName = map[string]int32{ {{range $fi,$field := $.Types.AllFieldByName $objName}}
		"{{$field.FieldName}}": {{$field.Value}}, // {{$field.Name}} {{end}}
	}

	{{$objName}}MapperNameByValue = map[int32]string{ {{range $fi,$field := $.Types.AllFieldByName $objName}}
		 {{$field.Value}}: "{{$field.FieldName}}", // {{$field.Name}} {{end}}
	}
)
{{end}}

{{range $sn, $objName := $.Types.StructNames}}
type {{$objName}} struct{ {{range $fi,$field := $.Types.AllFieldByName $objName}}
	{{$field.FieldName}} {{GoType $field}} {{GoTabTag $field}} {{end}}
}
{{end}}

// Combine struct
type {{.CombineStructName}} struct { {{range $ti, $tab := $.Datas.AllTables}}
	{{$tab.HeaderType}} []*{{$tab.HeaderType}} // table: {{$tab.HeaderType}} {{end}}

	// Indices {{range $ii, $idx := GetIndices $}}
	{{$idx.Table.HeaderType}}By{{$idx.FieldInfo.FieldName}} map[{{GoType $idx.FieldInfo}}]*{{$idx.Table.HeaderType}}	{{JsonTabOmit}} // table: {{$idx.Table.HeaderType}} {{end}}

	// Handlers
	postHandlers []func(*Table) {{JsonTabOmit}}
	preHandlers  []func(*Table) {{JsonTabOmit}}
}

{{if HasKeyValueTypes $}}
//{{range $ti, $name := GetKeyValueTypeNames $}} table: {{$name}}
func (self*{{$.CombineStructName}}) GetKeyValue_{{$name}}() *{{$name}}{
	return self.{{$name}}[0]
}
{{end}}{{end}}

// 注册加载后回调(用于构建数据)
func (self *Table) RegisterPostEntry(h func(*Table)) {

	if h == nil {
		panic("empty postload handler")
	}

	self.postHandlers = append(self.postHandlers, h)
}

// 注册加载前回调(用于清除数据)
func (self *Table) RegisterPreEntry(h func(*Table)) {

	if h == nil {
		panic("empty preload handler")
	}

	self.preHandlers = append(self.preHandlers, h)
}

// 调用PreHander，清除索引和数据
func (self *Table) ResetData() {

	for _, h := range self.preHandlers {
		h(self)
	}

	{{range $ti, $tab := $.Datas.AllTables}}
	self.{{$tab.HeaderType}} = self.{{$tab.HeaderType}}[0:0] {{end}}
	{{range $ii, $idx := GetIndices $}}
	self.{{$idx.Table.HeaderType}}By{{$idx.FieldInfo.FieldName}} = map[{{GoType $idx.FieldInfo}}]*{{$idx.Table.HeaderType}}{} {{end}}	
}

// 构建索引，调用PostHander
func (self *Table) BuildData() {
	{{range $ii, $idx := GetIndices $}}
	for _, v := range self.{{$idx.Table.HeaderType}} {
		self.{{$idx.Table.HeaderType}}By{{$idx.FieldInfo.FieldName}}[v.{{$idx.FieldInfo.FieldName}}] = v
	}{{end}}

	for _, h := range self.postHandlers {
		h(self)
	}
}

// 初始化表实例
func New{{.CombineStructName}}() *{{.CombineStructName}}{

	self := &{{.CombineStructName}}{}

	self.ResetData()

	return self
}
`