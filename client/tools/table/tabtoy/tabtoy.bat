
echo off & color 0A

::指定起始文件夹

set CURDIR="./"
set SRCDIR="../../../../design/table/"
set TABTOY_DIR="../table/tabtoy/"

set LUA_C_Init_DIR="../../client/client/Assets/Lua/Cfg/"
set LUA_S_Init_DIR="../../server/skynetServer/cfg/"

set LUA_C_DSTDIR="../client/client/Assets/Lua/Cfg/"
set LUA_S_DSTDIR="../server/skynetServer/cfg/"

set GO_S_DSTDIR="../server/leafServer/src/server/cfg/"
set GO_S_DSTBINDIR="../server/leafServer/bin/cfg/"

set CSHAPE_C_DSTDIR="../client/client/Assets/Scripts/Game/Table/"
set CSHAPE_C_DSTBINDIR="../client/client/Assets/Package/config/table/"

set IGNORE_FILE="Globals.xlsx"

set LUA_C_DSTDIR_FROM_LUA_S_DSTDIR="../../../client/client/Assets/Lua/cfg/"

set PYTHON_MAIN_FILE=..\tools\tabtoy\tabtoy_export\main.exe
set PYTHON_TsInfoExport_Main_File="../../../../../tools/tsinfoexport"

echo "--------------------------------------------------------------------------"

echo "delete LUA_C_Init_DIR"
echo rd /s /q %LUA_C_Init_DIR%

echo "delete LUA_S_Init_DIR"
echo rd /s /q %LUA_S_Init_DIR%

:: 参数 /R 表示需要遍历子文件夹,去掉表示不遍历子文件夹

:: %%f 是一个变量,类似于迭代器,但是这个变量只能由一个字母组成,前面带上%%

:: 括号中是通配符,可以指定后缀名,*.*表示所有文件


echo "--------------------------------------------------------------------------"

echo "cd SRCDIR"
cd %SRCDIR%

%PYTHON_MAIN_FILE% %TABTOY_DIR% %LUA_C_DSTDIR% %LUA_S_DSTDIR% %GO_S_DSTDIR% %GO_S_DSTBINDIR% %CSHAPE_C_DSTDIR% %CSHAPE_C_DSTBINDIR% 0

echo "--------------------------------------------------------------------------"

echo "svn add LUA_S_DSTDIR"
cd %LUA_S_DSTDIR%
svn add . --no-ignore --force

echo "svn add LUA_C_DSTDIR_FROM_LUA_S_DSTDIR"
cd %LUA_C_DSTDIR_FROM_LUA_S_DSTDIR%
svn add . --no-ignore --force

echo "tsinfoexport.bat"
cd %PYTHON_TsInfoExport_Main_File%
./tsinfoexport.bat

pause


