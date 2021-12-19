using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StratergySample : MonoBehaviour
{
    public List<S_Behaviour> samples;
    private int index=-1;
    private S_Behaviour current;
    // Start is called before the first frame update
    void Start()
    {
        OnChanged();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.C))
        {
            OnChanged();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            current.Show();
        }
    }
    private void OnChanged()
    {
        index++;
        if (index >= samples.Count)
            index = 0;
        current = samples[index];
        
    }
}
