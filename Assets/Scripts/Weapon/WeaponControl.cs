using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
  
    public List<WeaponBehaviour> wepons;
    private int index = -1;
    public WeaponBehaviour currentWeapon;
    public event Action<WeaponBehaviour> OnChangeGun;
    public Transform anchorGun;
    private bool islockGun;
    // Start is called before the first frame update
    void Start()
    {
        PlayerInfo playerInfo = DataAPIController.instance.GetPlayerInfo();

        ConfigWeaponRecord cfWeapon_1 = ConfigManager.instance.configWeapon.GetRecordByKeySearch(playerInfo.id_Gun1);
        GameObject gunObject_1 = Instantiate(Resources.Load("Weapon/" + cfWeapon_1.Prefab, typeof(GameObject))) as GameObject;
        gunObject_1.transform.SetParent(anchorGun, false);
        gunObject_1.SetActive(false);
        WeaponBehaviour wp_1 = gunObject_1.GetComponent<WeaponBehaviour>();
        wp_1.Setup(new WeaponDataInit { configWP = cfWeapon_1 });
        wepons.Add(wp_1);

        ConfigWeaponRecord cfWeapon_2 = ConfigManager.instance.configWeapon.GetRecordByKeySearch(playerInfo.id_Gun2);
        GameObject gunObject_2 = Instantiate(Resources.Load("Weapon/" + cfWeapon_2.Prefab, typeof(GameObject))) as GameObject;
        gunObject_2.transform.SetParent(anchorGun, false);
        gunObject_2.SetActive(false);
        WeaponBehaviour wp_2 = gunObject_2.GetComponent<WeaponBehaviour>();
        wp_2.Setup(new WeaponDataInit { configWP = cfWeapon_2 });
        wepons.Add(wp_2);

        OnChanged();
        InputManager.onTouchHandle.AddListener(OnTouchHandle);
        InputManager.OnEventChangeGun.AddListener(() =>
        {
            DataAPIController.instance.OnChangeGunIngame();
            OnChanged();
        });

        MissionControl.instance.OnMoveEvent += (isMove) =>
        {
            islockGun = isMove;
            if(isMove)
                currentWeapon.OnFire(false, Vector2.zero);
        };
    }

    private void OnTouchHandle(bool istouch, Vector2 point)
    {
        if (!islockGun)
            currentWeapon.OnFire(istouch, point);
    }


    private void OnChanged()
    {

        index++;
        if (index >= wepons.Count)
            index = 0;
        if (currentWeapon != wepons[index])
        {
            currentWeapon?.gameObject.SetActive(false);
            currentWeapon = wepons[index];
            OnChangeGun?.Invoke(currentWeapon);
            currentWeapon.gameObject.SetActive(true);
            currentWeapon.OnReady();
        }

       

    }
}
