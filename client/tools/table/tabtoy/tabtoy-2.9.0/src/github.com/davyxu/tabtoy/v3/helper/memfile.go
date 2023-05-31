package helper

import (
	"errors"
	"github.com/tealeg/xlsx"
)

type MemFileData struct {
	File      *xlsx.File
	TableName string
	FileName  string
}

type MemFile struct {
	dataByFileName map[string]*MemFileData
}

func (self *MemFile) VisitAllTable(callback func(data *MemFileData) bool) {

	for _, v := range self.dataByFileName {
		if !callback(v) {
			return
		}
	}
}

func (self *MemFile) AddFile(filename string, file *xlsx.File) (ret *MemFileData) {

	ret = &MemFileData{
		File:     file,
		FileName: filename,
	}

	self.dataByFileName[filename] = ret

	return
}

func (self *MemFile) CreateDefault(filename string) *xlsx.Sheet {

	f := xlsx.NewFile()
	sheet, _ := f.AddSheet("Default")

	self.AddFile(filename, sheet.File)

	return sheet
}

func (self *MemFile) GetFile(filename string) (TableFile, error) {

	if f, ok := self.dataByFileName[filename]; ok {
		return NewXlsxFile(f.File), nil
	}

	return nil, errors.New("file not found: " + filename)
}

func NewMemFile() *MemFile {
	return &MemFile{
		dataByFileName: make(map[string]*MemFileData),
	}
}
