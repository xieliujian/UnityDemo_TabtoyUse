// Generated by github.com/davyxu/tabtoy
// Version: 2.9.0

using gtm;
using System.IO;
using tabtoy;

namespace gtmGame
{
    public class ConfigManager
    {
        public HeroCfg herocfg = new HeroCfg();

        public ItemCfg itemcfg = new ItemCfg();

        public SceneCfg scenecfg = new SceneCfg();

        public ServerListCfg serverlistcfg = new ServerListCfg();

        public TsInfoCfg tsinfocfg = new TsInfoCfg();

        public void DoInit()
        {
            InitHeroCfg();
            InitItemCfg();
            InitSceneCfg();
            InitServerListCfg();
            InitTsInfoCfg();
        }

        public void DoClose()
        {
        }

        public void DoUpdate()
        {
        }

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

        private void InitItemCfg()
        {
            byte[] bytes = ResourceLoad.instance.LoadResourceSync("Config/Table/", "item" , ".bytes", ResourceType.Bytes) as byte[];
            MemoryStream stream = new MemoryStream(bytes);
            var reader = new tabtoy.DataReader(stream);

            var result = reader.ReadHeader(itemcfg.GetBuildID());
            if (result != FileState.OK)
            {
                LogSystem.instance.LogError(LogCategory.GameLogic, "itemcfg combine file crack!");
                return;
            }

            ItemCfg.Deserialize(itemcfg, reader);
        }

        private void InitSceneCfg()
        {
            byte[] bytes = ResourceLoad.instance.LoadResourceSync("Config/Table/", "scene" , ".bytes", ResourceType.Bytes) as byte[];
            MemoryStream stream = new MemoryStream(bytes);
            var reader = new tabtoy.DataReader(stream);

            var result = reader.ReadHeader(scenecfg.GetBuildID());
            if (result != FileState.OK)
            {
                LogSystem.instance.LogError(LogCategory.GameLogic, "scenecfg combine file crack!");
                return;
            }

            SceneCfg.Deserialize(scenecfg, reader);
        }

        private void InitServerListCfg()
        {
            byte[] bytes = ResourceLoad.instance.LoadResourceSync("Config/Table/", "serverlist" , ".bytes", ResourceType.Bytes) as byte[];
            MemoryStream stream = new MemoryStream(bytes);
            var reader = new tabtoy.DataReader(stream);

            var result = reader.ReadHeader(serverlistcfg.GetBuildID());
            if (result != FileState.OK)
            {
                LogSystem.instance.LogError(LogCategory.GameLogic, "serverlistcfg combine file crack!");
                return;
            }

            ServerListCfg.Deserialize(serverlistcfg, reader);
        }

        private void InitTsInfoCfg()
        {
            byte[] bytes = ResourceLoad.instance.LoadResourceSync("Config/Table/", "tsinfo" , ".bytes", ResourceType.Bytes) as byte[];
            MemoryStream stream = new MemoryStream(bytes);
            var reader = new tabtoy.DataReader(stream);

            var result = reader.ReadHeader(tsinfocfg.GetBuildID());
            if (result != FileState.OK)
            {
                LogSystem.instance.LogError(LogCategory.GameLogic, "tsinfocfg combine file crack!");
                return;
            }

            TsInfoCfg.Deserialize(tsinfocfg, reader);
        }

    }
}
