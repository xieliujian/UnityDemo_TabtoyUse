// Generated by github.com/davyxu/tabtoy
// Version: 2.9.0

using gtmInterface;
using System.IO;
using tabtoy;

namespace gtmGame
{
    public class ConfigManager : IConfigManager
    {
        public HeroCfg herocfg = new HeroCfg();

        public ItemCfg itemcfg = new ItemCfg();

        public SceneCfg scenecfg = new SceneCfg();

        public ServerListCfg serverlistcfg = new ServerListCfg();

        public TsInfoCfg tsinfocfg = new TsInfoCfg();

        public override void DoInit()
        {
            InitHeroCfg();
            InitItemCfg();
            InitSceneCfg();
            InitServerListCfg();
            InitTsInfoCfg();
        }

        public override void DoClose()
        {
        }

        public override void DoUpdate()
        {
        }

        private void InitHeroCfg()
        {
            byte[] bytes = IResourceLoad.instance.LoadResourceSync("config/table/", "hero" , ".bytes", IResourceType.Bytes) as byte[];
            MemoryStream stream = new MemoryStream(bytes);
            var reader = new tabtoy.DataReader(stream);

            var result = reader.ReadHeader(herocfg.GetBuildID());
            if (result != FileState.OK)
            {
                ILogSystem.instance.LogError(LogCategory.GameLogic, "herocfg combine file crack!");
                return;
            }

            HeroCfg.Deserialize(herocfg, reader);
        }

        private void InitItemCfg()
        {
            byte[] bytes = IResourceLoad.instance.LoadResourceSync("config/table/", "item" , ".bytes", IResourceType.Bytes) as byte[];
            MemoryStream stream = new MemoryStream(bytes);
            var reader = new tabtoy.DataReader(stream);

            var result = reader.ReadHeader(itemcfg.GetBuildID());
            if (result != FileState.OK)
            {
                ILogSystem.instance.LogError(LogCategory.GameLogic, "itemcfg combine file crack!");
                return;
            }

            ItemCfg.Deserialize(itemcfg, reader);
        }

        private void InitSceneCfg()
        {
            byte[] bytes = IResourceLoad.instance.LoadResourceSync("config/table/", "scene" , ".bytes", IResourceType.Bytes) as byte[];
            MemoryStream stream = new MemoryStream(bytes);
            var reader = new tabtoy.DataReader(stream);

            var result = reader.ReadHeader(scenecfg.GetBuildID());
            if (result != FileState.OK)
            {
                ILogSystem.instance.LogError(LogCategory.GameLogic, "scenecfg combine file crack!");
                return;
            }

            SceneCfg.Deserialize(scenecfg, reader);
        }

        private void InitServerListCfg()
        {
            byte[] bytes = IResourceLoad.instance.LoadResourceSync("config/table/", "serverlist" , ".bytes", IResourceType.Bytes) as byte[];
            MemoryStream stream = new MemoryStream(bytes);
            var reader = new tabtoy.DataReader(stream);

            var result = reader.ReadHeader(serverlistcfg.GetBuildID());
            if (result != FileState.OK)
            {
                ILogSystem.instance.LogError(LogCategory.GameLogic, "serverlistcfg combine file crack!");
                return;
            }

            ServerListCfg.Deserialize(serverlistcfg, reader);
        }

        private void InitTsInfoCfg()
        {
            byte[] bytes = IResourceLoad.instance.LoadResourceSync("config/table/", "tsinfo" , ".bytes", IResourceType.Bytes) as byte[];
            MemoryStream stream = new MemoryStream(bytes);
            var reader = new tabtoy.DataReader(stream);

            var result = reader.ReadHeader(tsinfocfg.GetBuildID());
            if (result != FileState.OK)
            {
                ILogSystem.instance.LogError(LogCategory.GameLogic, "tsinfocfg combine file crack!");
                return;
            }

            TsInfoCfg.Deserialize(tsinfocfg, reader);
        }

    }
}

