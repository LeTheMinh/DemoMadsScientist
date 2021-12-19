using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopView : BaseView
{
    public Transform parentItem;
    public ItemShopView parefabItem;
    private List<ItemShopView> lsItems= new List<ItemShopView>();
    private int potion;
    public Text potionLB;
    // Start is called before the first frame update
    public override void OnSetup(ViewParam param)
    {

        potion = DataAPIController.instance.GetPotion();
        potionLB.text = potion.ToString();
        if (lsItems.Count<=0)
        {
            foreach(ConfigShopRecord e in ConfigManager.instance.configShop.GetAll())
            {
                ItemShopView item = Instantiate(parefabItem);
                lsItems.Add(item);
                item.Setup(e);
                item.transform.SetParent(parentItem, false);
            }
        }
        else
        {
            int i = 0;
            foreach (ConfigShopRecord e in ConfigManager.instance.configShop.GetAll())
            {
            
                lsItems[i].Setup(e);
                i++;
            }
        }
    }
    public override void OnShowView()
    {
        DataTrigger.RegisterValuachange(DataPath.POTION, OnPotionChange);
    }

    public override void OnHideView()
    {
        DataTrigger.UnRegisterValuachange(DataPath.POTION, OnPotionChange);
    }
    private void OnPotionChange(object dataChange)
    {
        potion = (int)dataChange;
        potionLB.text = potion.ToString();
    }
    public void OnBack()
    {
        ViewManager.instance.SwitchView(ViewIndex.HomeView);
    }
}
