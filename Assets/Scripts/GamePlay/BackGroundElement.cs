using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundElement : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.layer==8)
        {
            BackgroundControl.instance.LoadNewBG();
        }
    }
    // Start is called before the first frame update

}
