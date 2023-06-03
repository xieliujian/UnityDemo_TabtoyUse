
echo off & color 0A

::指定起始文件夹

set CURDIR="./"
set SRCDIR="../../../../design/table/"
set TABTOY_DIR="../tabtoy/"

@REM set LUA_C_Init_DIR="../../../project/Assets/Lua/Cfg/"
@REM set LUA_S_Init_DIR="../../../../server/skynetServer/cfg/"

set LUA_C_DSTDIR="../../client/project/Assets/Lua/Cfg/"
set LUA_S_DSTDIR="../../server/leafServer/bin/luaCfg/"

set GO_S_DSTDIR="../../server/leafServer/src/server/cfg/"
set GO_S_DSTBINDIR="../../server/leafServer/bin/cfg/"

set CSHAPE_C_DSTDIR="../../client/project/Assets/Scripts/Table/"
set CSHAPE_C_DSTBINDIR="../../client/project/Assets/Package/Config/Table/"

@REM set IGNORE_FILE="Globals.xlsx"
@REM set LUA_C_DSTDIR_FROM_LUA_S_DSTDIR="../../../client/client/Assets/Lua/cfg/"

set PYTHON_MAIN_FILE=..\..\client\tools\table\tabtoy\tabtoy_export\dist\main.exe
set PYTHON_TSINFOEXPORT_MAIN_FILE="../../client/tools/table/tsinfoexport"

@REM echo "--------------------------------------------------------------------------"

@REM echo "delete LUA_C_Init_DIR"
@REM echo rd /s /q %LUA_C_Init_DIR%

@REM echo "delete LUA_S_Init_DIR"
@REM echo rd /s /q %LUA_S_Init_DIR%

@REM :: 参数 /R 表示需要遍历子文件夹,去掉表示不遍历子文件夹
@REM
@REM :: %%f 是一个变量,类似于迭代器,但是这个变量只能由一个字母组成,前面带上%%
@REM
@REM :: 括号中是通配符,可以指定后缀名,*.*表示所有文件

echo "--------------------------------------------------------------------------"

echo "cd SRCDIR"
cd %SRCDIR%

%PYTHON_MAIN_FILE% %TABTOY_DIR% %LUA_C_DSTDIR% %LUA_S_DSTDIR% %GO_S_DSTDIR% %GO_S_DSTBINDIR% %CSHAPE_C_DSTDIR% %CSHAPE_C_DSTBINDIR% 0

echo "--------------------------------------------------------------------------"

@REM echo "svn add LUA_S_DSTDIR"
@REM cd %LUA_S_DSTDIR%
@REM svn add . --no-ignore --force
@REM
@REM echo "svn add LUA_C_DSTDIR_FROM_LUA_S_DSTDIR"
@REM cd %LUA_C_DSTDIR_FROM_LUA_S_DSTDIR%
@REM svn add . --no-ignore --force

echo "tsinfoexport.bat"
cd %PYTHON_TSINFOEXPORT_MAIN_FILE%
./tsinfoexport.bat

pause


