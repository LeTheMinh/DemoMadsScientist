using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.UI;

public class WeaponViewItem : MonoBehaviour
{
    public Image icon;
    public GameObject selectObject;
    public Text nameLB;
    private WeaponView parent;
    public GameObject lockObject;
    public ConfigWeaponRecord configWeapon;
    
    // Start is called before the first frame update
    public void Setup(ConfigWeaponRecord configWeapon, WeaponView parent)
    {
        this.parent = parent;
        icon.sprite = SpriteLibControl.instance.GetSpriteByName(configWeapon.Prefab);
        nameLB.text = configWeapon.Name;
        selectObject.SetActive(false);
        this.configWeapon = configWeapon;
    }
    public void OnSelectItem()
    {
        parent.OnItemSelect(this);
        selectObject.SetActive(true);
    }
    public void OnDeSelectItem()
    {
        selectObject.SetActive(false);
    }
}
