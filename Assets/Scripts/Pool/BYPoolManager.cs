using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BYPoolManager : MonoBehaviour
{
    [SerializeField]
    public List<BYPool> pools;
    public static Dictionary<string, BYPool> dicPool = new Dictionary<string, BYPool>();
    // Start is called before the first frame update
    void Start()
    {
        dicPool.Clear();
        foreach(BYPool p in pools)
        {
            CreatePool(p);
            dicPool.Add(p.namePool,p);
        }
    }
     public static void AddNewPool(BYPool pool)
    {
        if (!dicPool.ContainsKey(pool.namePool))
        {
            CreatePool(pool);
            dicPool.Add(pool.namePool, pool);

        }
    }
    // Update is called once per frame
    private static void CreatePool(BYPool pool)
    {
        for(int i=0;i<pool.total;i++)
        {
            Transform trans = Instantiate(pool.prefab, Vector3.zero, Quaternion.identity);
            pool.elements.Add(trans);
            trans.gameObject.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        dicPool.Clear();
    }
}
