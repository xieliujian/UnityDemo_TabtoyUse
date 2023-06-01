
echo off & color 0A

::指定起始文件夹
set TsInfoCfg_DIR="../../../../design/table/"
set TsInfoCfg_Name="TsInfo.xlsx"
::set TsInfoEnumLuaName = "TsInfoEnum.lua"

set LUA_C_DSTDIR="../../../../client/project/Assets/Lua/Cfg/"
set LUA_S_DSTDIR="../../../../server/skynetServer/cfg/"
set GO_S_DSTDIR="../../../../server/leafServer/src/server/cfg/"

@REM set LUA_C_DSTDIR_FROM_LUA_S_DSTDIR="../../client/client/Assets/Lua/Cfg/"

set PYTHON_MAIN_FILE=main.exe

echo "--------------------------------------------------------------------------"

%PYTHON_MAIN_FILE% %TsInfoCfg_DIR% %TsInfoCfg_Name% %LUA_C_DSTDIR% %LUA_S_DSTDIR% %GO_S_DSTDIR%

echo "--------------------------------------------------------------------------"

::echo "svn add LUA_S_DSTDIR"
::cd %LUA_S_DSTDIR%
::svn add %TsInfoEnumLuaName% --no-ignore --force

::echo "svn add LUA_C_DSTDIR_FROM_LUA_S_DSTDIR"
::cd %LUA_C_DSTDIR_FROM_LUA_S_DSTDIR%
::svn add %TsInfoEnumLuaName% --no-ignore --force

pause


