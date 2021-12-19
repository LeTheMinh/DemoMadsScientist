using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeView : BaseView
{
    public Text nameLB;
    public Text potionLB;
    public override void OnSetup(ViewParam param)
    {
        nameLB.text = DataAPIController.instance.GetNameHero();
        potionLB.text = DataAPIController.instance.GetPotion().ToString();
     
        base.OnSetup(param);
    }
    private void OnInventoryChange(object dataChange)
    {
        Debug.LogError(dataChange.ToString());
    }
    private void OnPotionChange(object dataChange)
    {
        potionLB.text = dataChange.ToString();
    }
    public void OnPlayGame()
    {
        LoadSceneManager.instance.LoadSceneByIndex(2, ()=>
        {
            ViewManager.instance.SwitchView(ViewIndex.IngameView);
        });
      
    }
    public override void OnShowView()
    {
        DataTrigger.RegisterValuachange(DataPath.POTION, OnPotionChange);
        DataTrigger.RegisterValuachange(DataPath.INVENTORY, OnInventoryChange);
    }

    public override void OnHideView()
    {
        DataTrigger.UnRegisterValuachange(DataPath.POTION, OnPotionChange);
        DataTrigger.UnRegisterValuachange(DataPath.INVENTORY, OnInventoryChange);
    }
    public void OnWeaponView()
    {
        ViewManager.instance.SwitchView(ViewIndex.WeaponView);
    }
    public void OnShopView()
    {
      
        //DataAPIController.instance.UpdatePotion(300);
        ViewManager.instance.SwitchView(ViewIndex.ShopView);
    }
    public void OnQuestView()
    {
        ViewManager.instance.SwitchView(ViewIndex.QuestView);
    }
}
