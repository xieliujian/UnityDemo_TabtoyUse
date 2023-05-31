#!/bin/sh

CURDIR="./"
SRCDIR="../../doc/"
TABTOY_DIR="../tools/tabtoy/"

LUA_C_Init_DIR="../../client/client/Assets/Lua/cfg/"
LUA_S_Init_DIR="../../server/skynetServer/cfg/"

LUA_C_DSTDIR="../client/client/Assets/Lua/cfg/"
LUA_S_DSTDIR="../server/skynetServer/cfg/"

GO_S_DSTDIR="../server/leafServer/src/server/cfg/"
GO_S_DSTBINDIR="../server/leafServer/bin/cfg/"

IGNORE_FILE="Globals.xlsx"

LUA_C_DSTDIR_FROM_LUA_S_DSTDIR="../../../client/client/Assets/Lua/cfg/"

PYTHON_MAIN_FILE="../tools/tabtoy/tabtoy_export/main.py"

echo "--------------------------------------------------------------------------"

echo "delete LUA_C_Init_DIR"
rm -rf $LUA_C_Init_DIR

echo "delete LUA_S_Init_DIR"
rm -rf $LUA_S_Init_DIR

# 参数 /R 表示需要遍历子文件夹,去掉表示不遍历子文件夹

# %%f 是一个变量,类似于迭代器,但是这个变量只能由一个字母组成,前面带上%%

# 括号中是通配符,可以指定后缀名,*.*表示所有文件


echo "--------------------------------------------------------------------------"

echo "cd SRCDIR"
cd $SRCDIR

python3 $PYTHON_MAIN_FILE $TABTOY_DIR $LUA_C_DSTDIR $LUA_S_DSTDIR $GO_S_DSTDIR $GO_S_DSTBINDIR "1"

echo "--------------------------------------------------------------------------"

echo "svn add LUA_S_DSTDIR"
cd $LUA_S_DSTDIR
svn add . --no-ignore --force

echo "svn add LUA_C_DSTDIR_FROM_LUA_S_DSTDIR"
cd $LUA_C_DSTDIR_FROM_LUA_S_DSTDIR
svn add . --no-ignore --force



