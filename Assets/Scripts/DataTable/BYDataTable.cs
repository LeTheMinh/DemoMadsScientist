using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;

public class BYDataTableCreate : ScriptableObject
{
    public virtual void ImportData(TextAsset textData)
    {

    }

}
public abstract class RecordCompare<T> : IComparer<T>
{
    public int Compare(T x, T y)
    {
        return OnRecordCompare(x, y);
    }
    public abstract T MakeKeySearch(object key);
    public abstract int OnRecordCompare(T x, T y);

}
public abstract class BYDataTable<T> : BYDataTableCreate where T : class
{
    [SerializeField]
    protected List<T> records = new List<T>();
    public RecordCompare<T> recordCompare;
    private void OnEnable()
    {
        AddKeySearch();
    }
    public abstract void AddKeySearch();
    public override void ImportData(TextAsset textData)
    {
        records.Clear();
        Type dataType = typeof(T);
        FieldInfo[] fieldInfos = dataType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        List<List<string>> grids = GetDataCSV(textData);
        for (int i = 1; i < grids.Count; i++)
        {
            // data a record 
            string jsonString = "{";
            for (int j = 0; j < grids[i].Count; j++)
            {
                if (j > 0)
                {
                    jsonString += ",";
                }
                if (fieldInfos[j].FieldType == typeof(string))
                {
                    jsonString += "\"" + fieldInfos[j].Name + "\":\"" + grids[i][j].ToString() + "\"";
                }
                else
                {
                    jsonString += "\"" + fieldInfos[j].Name + "\":" + grids[i][j].ToString();
                }
            }
            jsonString += "}";
            // Debug.LogError(jsonString);
            T dataRecord = JsonUtility.FromJson<T>(jsonString);
            records.Add(dataRecord);
        }
        records.Sort(recordCompare);
    }
    private List<List<string>> GetDataCSV(TextAsset textAsset)
    {
        List<List<string>> grids = new List<List<string>>();
        string[] lines = textAsset.text.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            string s = lines[i];
            if (s.CompareTo(string.Empty) != 0)
            {
                string[] lineData = s.Split(',');
                List<string> data = new List<string>();
                foreach (string e in lineData)
                {
                    string newChar = Regex.Replace(e, @"\t|\n|\r", "");
                    data.Add(newChar);
                }
                grids.Add(data);
            }
        }
        return grids;
    }
    public T GetRecordByKeySearch(object key)
    {
        T item = recordCompare.MakeKeySearch(key);
        int index = records.BinarySearch(item, recordCompare);
        if (index < 0)
            return null;
        else
            return records[index];
    }
}
