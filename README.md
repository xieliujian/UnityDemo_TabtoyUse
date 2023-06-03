
# 表格导出工具tabtoy的使用

## 通过tabtoy导出代码

`tabtoy.bat` 导出代码

## 代码

```cs

private void InitHeroCfg()
{
    byte[] bytes = ResourceLoad.instance.LoadResourceSync("Config/Table/", "hero" , ".bytes", ResourceType.Bytes) as byte[];
    MemoryStream stream = new MemoryStream(bytes);
    var reader = new tabtoy.DataReader(stream);

    var result = reader.ReadHeader(herocfg.GetBuildID());
    if (result != FileState.OK)
    {
        LogSystem.instance.LogError(LogCategory.GameLogic, "herocfg combine file crack!");
        return;
    }

    HeroCfg.Deserialize(herocfg, reader);
}

```

lua的TsInfoEnum代码，用于把ID转换为Key值

```lua

TsInfoEnum = {
    TS_Login_Failed = 100001,
    TS_Login_Success = 100002,
    TS_Login_CreateName_Failed = 100100,
    TS_Login_CreateName_Succeed = 100101,
    TS_Login_Account_Empty = 100200,
    TS_Login_Passward_Empty = 100201,
    TS_RegAcc_Success = 200001,
    TS_RegAcc_Failed = 200002,
    TS_RegAcc_Exist = 200003,
    TS_RegAcc_Test = 200004,
}

```