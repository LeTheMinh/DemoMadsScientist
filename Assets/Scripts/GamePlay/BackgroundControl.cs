using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundControl : Singleton<BackgroundControl>
{
    public float size_delta = 32.5f;
    private int count_BG = -1;
    public Transform anchor;
    private BackGroundElement currentBG;
    public List<BackGroundElement> backgrounds;
    public List<Transform> forgrounds_Top;
    private Transform current_top;
    public List<Transform> forgrounds_Bottom;
    private Transform current_bottom;
    // Start is called before the first frame update
    void Start()
    {
        LoadNewBG();
    }
    public void LoadNewBG()
    {
        BackGroundElement newBG = backgrounds.Where(x => x != currentBG).OrderBy(x => new Guid()).FirstOrDefault();
        newBG.gameObject.SetActive(true);
        count_BG++;
        newBG.transform.position = anchor.position + new Vector3(count_BG * size_delta, 0, 0);
        currentBG = newBG;
        //top
        Transform newBG_top = forgrounds_Top.Where(x => x != current_top).OrderBy(x => new Guid()).FirstOrDefault();
        newBG_top.gameObject.SetActive(true);
        newBG_top.transform.position = anchor.position + new Vector3(count_BG * size_delta, 8,0);
        current_top = newBG_top;
        //bg
        Transform newBG_bottom = forgrounds_Bottom.Where(x => x != current_bottom).OrderBy(x => new Guid()).FirstOrDefault();
        newBG_bottom.gameObject.SetActive(true);
        newBG_bottom.transform.position = anchor.position + new Vector3(count_BG * size_delta, 0, 0);
        current_bottom = newBG_bottom;
    }
    private bool OnSelected(Transform x)
    {
        return x != currentBG;
    }
    // Update is called once per frame

}
