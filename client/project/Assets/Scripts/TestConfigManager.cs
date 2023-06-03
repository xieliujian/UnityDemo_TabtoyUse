using gtm;
using gtmGame;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConfigManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResourceLoad resLoad = new ResourceLoad();
        resLoad.isInitAssetBundleLoad = false;
        resLoad.DoInit();

        ConfigManager configMgr = new ConfigManager();
        configMgr.DoInit();
    }
     
    // Update is called once per frame
    void Update()
    {
        
    }
}
