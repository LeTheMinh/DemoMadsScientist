using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BYDataTableMaker : MonoBehaviour
{
    // Start is called before the first frame update
    [MenuItem("Assets/BY/CreateBinaryDataFromCSV", false, 1)]
    public static void CreateBinaryDataFromCSV()
    {
       foreach(UnityEngine.Object e in Selection.objects)
        {
            ScriptableObject scriptableObject = ScriptableObject.CreateInstance(e.name);
            if(scriptableObject!=null)
            {
                AssetDatabase.CreateAsset(scriptableObject, "Assets/Resources/DataTable/" + e.name + ".asset");
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                BYDataTableCreate tableCreate = (BYDataTableCreate)scriptableObject;
                TextAsset textData = (TextAsset)e;
                tableCreate.ImportData(textData);
                EditorUtility.SetDirty(tableCreate);
            }
        }
    }
}
