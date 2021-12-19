using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogEquip : BaseDialog
{
    public Image iconGun_1;
    public Image iconGun_2;
    private DialogEquipParam equipParam;

    public void OnClose()
    {
        DialogManager.instance.HideDialog(this.index);
    }
    public void ChoseSlot(int index)
    {
        DataAPIController.instance.SetGunEquip(equipParam.idGun, index);
        DialogManager.instance.HideDialog(this.index);
    }
    public override void OnSetup(DialogParam param)
    {
        equipParam = (DialogEquipParam)param;
        PlayerInfo info = DataAPIController.instance.GetPlayerInfo();
        SetData(info);
    }
    private void SetData(PlayerInfo info)
    {
        ConfigWeaponRecord cf_1 = ConfigManager.instance.configWeapon.GetRecordByKeySearch(info.id_Gun1);
        iconGun_1.sprite = SpriteLibControl.instance.GetSpriteByName(cf_1.Prefab);
        ConfigWeaponRecord cf_2 = ConfigManager.instance.configWeapon.GetRecordByKeySearch(info.id_Gun2);
        iconGun_2.sprite = SpriteLibControl.instance.GetSpriteByName(cf_2.Prefab);
    }
}
