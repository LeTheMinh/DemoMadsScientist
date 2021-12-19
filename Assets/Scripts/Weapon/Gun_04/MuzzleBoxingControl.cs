using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleBoxingControl : MonoBehaviour
{
    [SerializeField] float timeHide;
    public void Fire()
    {
        if (!gameObject.activeInHierarchy)
        {
            gameObject.SetActive(true);
            Invoke("EndFire", timeHide);
        }
    }

    private void EndFire()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            CancelInvoke();
        }
    }
}
