using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // lamda expression 
        DontDestroyOnLoad(gameObject);
        ConfigManager.instance.Init(InitConfigDone);
    }
    private void InitConfigDone()
    {
        DataAPIController.instance.InitData(InitDataDone);
    }
    private void InitDataDone()
    {
        LoadSceneManager.instance.LoadSceneByName("Buffer", () => {

            ViewManager.instance.SwitchView(ViewIndex.HomeView);
        });
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
