using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngameView : BaseView
{

    private WeaponControl weaponControl;
    private WeaponBehaviour currentWeapon;
    public Image iconGun;
    public Text gunAmo;
    public Image iconGun_2;
    public Text gunAmo_2;
    public Text distanceLB;
    public Image hpForground;
    public GameObject reloadObject;
    public Animator reloadProgress;
    // Start is called before the first frame update
    public override void OnSetup(ViewParam param)
    {
        if (weaponControl == null)
            weaponControl = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponControl>();
        WeaponControl_OnChangeGun(weaponControl.currentWeapon);

    }
    public override void OnShowView()
    {
        MissionControl.instance.OnScoreCalculator += OnScoreCalculator;
        weaponControl.OnChangeGun += WeaponControl_OnChangeGun;
    }

    private void OnScoreCalculator(int obj)
    {
        distanceLB.text = obj.ToString();
    }

    public override void OnHideView()
    {
        MissionControl.instance.OnScoreCalculator -= OnScoreCalculator;
        weaponControl.OnChangeGun -= WeaponControl_OnChangeGun;
    }
    
    private void WeaponControl_OnChangeGun(WeaponBehaviour obj)
    {
        if (currentWeapon != null)
        {
            iconGun_2.overrideSprite = currentWeapon.iconGun;
            gunAmo_2.text = currentWeapon.numberBullet.ToString() + "/" + currentWeapon.clipSize.ToString();
            currentWeapon.OnAmoUpdate -= CurrentWeapon_OnAmoUpdate;
            currentWeapon.OnHPUpdate -= CurrentWeapon_OnHPUpdate;
        }
        else
        {
            iconGun_2.overrideSprite = weaponControl.wepons[1].iconGun;
            gunAmo_2.text = weaponControl.wepons[1].numberBullet.ToString() + "/" + weaponControl.wepons[1].clipSize.ToString();
        }
        reloadObject.SetActive(false);
        currentWeapon = obj;
        iconGun.overrideSprite = currentWeapon.iconGun;
        currentWeapon.OnAmoUpdate += CurrentWeapon_OnAmoUpdate;
        CurrentWeapon_OnHPUpdate(currentWeapon.currentHP, currentWeapon.totalHP);

        currentWeapon.OnHPUpdate += CurrentWeapon_OnHPUpdate;
        currentWeapon.StartReload = (timeReload) =>
        {
            reloadObject.SetActive(true);
            reloadProgress.speed = 1f / timeReload;
            reloadProgress.SetTrigger("Reload");
        };
        currentWeapon.EndReloadReload = () =>
        {
            reloadObject.SetActive(false);
        };
    }

    private void CurrentWeapon_OnHPUpdate(int arg1, int arg2)
    {
        float value = (float)arg1 / (float)arg2;
        hpForground.fillAmount = value;
    }

    private void CurrentWeapon_OnAmoUpdate(int arg1, int arg2)
    {
        gunAmo.text = arg1.ToString() + "/" + arg2.ToString();
    }


    public void OnPointDown(BaseEventData eventData)
    {
        InputManager.instance.OnTouchScreen(true, ((PointerEventData)eventData).position);
    }
    public void OnPointUp(BaseEventData eventData)
    {
        InputManager.instance.OnTouchScreen(false, ((PointerEventData)eventData).position);
    }
    public void OnChangeGun()
    {
        InputManager.instance.OnChangeGun();
    }
    public void OnPauseGame()
    {
        DialogManager.instance.ShowDialog(DialogIndex.DialogPause);
    }
}
