// Generated by github.com/davyxu/tabtoy
// Version: 2.9.0

package table

import (
    HeroTable "Server/cfg/Hero"
    ItemTable "Server/cfg/Item"
    SceneTable "Server/cfg/Scene"
    ServerListTable "Server/cfg/ServerList"
    TsInfoTable "Server/cfg/TsInfo"
)

var (
    HeroCfg HeroTable.ConfigTable
    ItemCfg ItemTable.ConfigTable
    SceneCfg SceneTable.ConfigTable
    ServerListCfg ServerListTable.ConfigTable
    TsInfoCfg TsInfoTable.ConfigTable
)

func LoadTables() {
    HeroCfg := HeroTable.NewConfigTable()

    if err := HeroCfg.Load("cfg/Hero.json"); err != nil {
        panic(err)
    }

    ItemCfg := ItemTable.NewConfigTable()

    if err := ItemCfg.Load("cfg/Item.json"); err != nil {
        panic(err)
    }

    SceneCfg := SceneTable.NewConfigTable()

    if err := SceneCfg.Load("cfg/Scene.json"); err != nil {
        panic(err)
    }

    ServerListCfg := ServerListTable.NewConfigTable()

    if err := ServerListCfg.Load("cfg/ServerList.json"); err != nil {
        panic(err)
    }

    TsInfoCfg := TsInfoTable.NewConfigTable()

    if err := TsInfoCfg.Load("cfg/TsInfo.json"); err != nil {
        panic(err)
    }

}

