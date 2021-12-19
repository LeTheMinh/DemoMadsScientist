using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System;
using System.Reflection;
using UnityEngine.Events;

public static class DataTrigger
{
    private static Dictionary<string, UnityEvent<object>> dicOnvalueChange = new Dictionary<string, UnityEvent<object>>();
    public static void RegisterValuachange(string path,UnityAction<object> delegatValueChange)
    {
        if(dicOnvalueChange.ContainsKey(path))
        {
            dicOnvalueChange[path].AddListener(delegatValueChange);
        }
        else
        {
            dicOnvalueChange.Add(path, new UnityEvent<object>());
            dicOnvalueChange[path].AddListener(delegatValueChange);
        }
    }
    public static void UnRegisterValuachange(string path, UnityAction<object> delegatValueChange)
    {
        if (dicOnvalueChange.ContainsKey(path))
        {
            dicOnvalueChange[path].RemoveListener(delegatValueChange);
        }
     
    }
    //extention method
    public static void TriggerEventData(this object data,string path)
    {
        if (dicOnvalueChange.ContainsKey(path))
            dicOnvalueChange[path].Invoke(data);
    }

}
public class DataBaseModel : MonoBehaviour
{
    private PlayerData playerData;
    // Start is called before the first frame update
    public void CreateData(Action callback)
    {
        if(LoadData())
        {
            callback();
        }
        else
        {
            playerData = new PlayerData();
            PlayerInfo info = new PlayerInfo();
            info = ConfigManager.instance.configDefault.playerInfo;
            playerData.info = info;
            PlayerInventory inventory = new PlayerInventory();
            inventory.potion = ConfigManager.instance.configDefault.potion;
            GunData data_1 = new GunData();
            data_1.idGun = info.id_Gun1;
            data_1.level = 1;
            GunData data_2 = new GunData();
            data_2.idGun = info.id_Gun2;
            data_2.level = 1;
            inventory.dicGun.Add(info.id_Gun1.ToKey(), data_1);
            inventory.dicGun.Add(info.id_Gun2.ToKey(), data_2);
            playerData.inventory = inventory;
            SaveData();
            callback();
        }
    }
    #region READ
    public T ReadData<T>(string path)
    {
        object data;
        string[] s = path.Split('/');
        List<string> paths = new List<string>();
        paths.AddRange(s);
        ReadDataBypath(paths, playerData, out data);
        return (T)data;
    }
    // inventory/potion
    private void ReadDataBypath(List<string> paths,object dataIn, out object outData)
    {
        string p = paths[0];
        Type t = dataIn.GetType();
        FieldInfo field = t.GetField(p);
        if(paths.Count==1)
        {
            outData = field.GetValue(dataIn);
        }
        else
        {
            paths.RemoveAt(0);
            ReadDataBypath(paths, field.GetValue(dataIn), out outData);
        }
    }
    public T ReadDictionary<T>(string path,string key)
    {
        object data;
        string[] s = path.Split('/');
        List<string> paths = new List<string>();
        paths.AddRange(s);
        Dictionary<string, T> dic = new Dictionary<string, T>();
        ReadDataBypath(paths, playerData, out data);
        dic=(Dictionary<string, T>)data;
        T dataOut;
        dic.TryGetValue(key,out dataOut);
        return dataOut;
    }

    #endregion
    #region UPDATE
    public void UpdateData(string path,object dataNew,Action callBack=null)
    {
        string[] s = path.Split('/');
        List<string> paths = new List<string>();
        paths.AddRange(s);
        List<object> lisDataChange = new List<object>();
        UpdateDataBypath(paths, playerData, dataNew,ref lisDataChange, callBack);
        paths.Clear();
        paths.AddRange(s);
        string newPath = string.Empty;
        for(int i=0;i<paths.Count;i++)
        {
            if(i==0)
            {
                newPath = paths[i];
            }
            else
            {
                newPath = newPath + "/" + paths[i];
            }
            lisDataChange[i].TriggerEventData(newPath);
        }
        SaveData();
    }
    private void UpdateDataBypath(List<string> paths, object data,  object dataNew,ref List<object> lsDataChange, Action callBack = null)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);
    
        if (paths.Count == 1)
        {
            lsDataChange.Add(dataNew);
            field.SetValue(data, dataNew);
            callBack?.Invoke();
        }
        else
        {
            object dataAdd= field.GetValue(data);
            lsDataChange.Add(dataAdd);

            paths.RemoveAt(0);
            UpdateDataBypath(paths, dataAdd, dataNew,ref lsDataChange,callBack);
        }
    }
    public void UpdateDictionary<T>(string path,string key, T dataNew, Action callBack = null)
    {
        string[] s = path.Split('/');
        List<string> paths = new List<string>();
        paths.AddRange(s);
        List<object> lisDataChange = new List<object>();
        UpdateDataDictionaryBypath<T>(paths, playerData,key, dataNew, ref lisDataChange, callBack);
        paths.Clear();
        paths.AddRange(s);
        string newPath = string.Empty;
        for (int i = 0; i < paths.Count; i++)
        {
            if (i == 0)
            {
                newPath = paths[i];
            }
            else
            {
                newPath = newPath + "/" + paths[i];
            }
            lisDataChange[i].TriggerEventData(newPath);
        }
        dataNew.TriggerEventData(newPath + "/" + key);
        SaveData();
    }
    private void UpdateDataDictionaryBypath<T>(List<string> paths, object data,string key, T dataNew, ref List<object> lsDataChange, Action callBack = null)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);

        if (paths.Count == 1)
        {
            object dataField = field.GetValue(data);
            Dictionary<string, T> dic = (Dictionary<string, T>)dataField;
            dic[key] = dataNew;
            lsDataChange.Add(dataNew);
            field.SetValue(data, dic);
            callBack?.Invoke();
        }
        else
        {
            object dataAdd = field.GetValue(data);
            lsDataChange.Add(dataAdd);

            paths.RemoveAt(0);
            UpdateDataDictionaryBypath(paths, dataAdd,key, dataNew, ref lsDataChange, callBack);
        }
    }
    #endregion
    #region LOAD_SAVE
    private bool LoadData()
    {
        if(PlayerPrefs.HasKey(DataPath.DATAKEY))
        {
            string jsonString = PlayerPrefs.GetString(DataPath.DATAKEY);
            playerData = JsonConvert.DeserializeObject<PlayerData>(jsonString);
            return true;
        }
        return false;
    }
    private void SaveData()
    {
        string jsonString = JsonConvert.SerializeObject(playerData);
        PlayerPrefs.SetString(DataPath.DATAKEY, jsonString);
        PlayerPrefs.Save();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
    #endregion
}
