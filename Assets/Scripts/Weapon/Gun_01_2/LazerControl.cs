using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerControl : MonoBehaviour
{
    public Transform rootPos;
    public Transform impact;
    public Material matLazer;
    int index = 0;
    public LineRenderer lineLazer;
    private float timeCount;
    // Start is called before the first frame update
    void Start()
    {
        matLazer.SetTextureOffset("_MainTex", new Vector2(0, 0));
     
    }

    // Update is called once per frame
    void Update()
    {
        lineLazer.SetPosition(0, rootPos.position);
        lineLazer.SetPosition(1, impact.position);
        timeCount += Time.deltaTime;
        if(timeCount>=0.1f)
        {
            index++;
            if (index > 4)
                index = 1;
            matLazer.SetTextureOffset("_MainTex", new Vector2(0, 0.2f * index));
            timeCount = 0;
        }
    }

}
