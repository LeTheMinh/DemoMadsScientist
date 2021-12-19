using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemShopView : MonoBehaviour
{
    public Image iconShop;
    public Image iconValue;
    public Text valueLB;
    public Text costDolaLB;
    public Text costPotionLB;
    public Button btnDola;
    public Button btnPotion;
    public Button btnaAds;
    private ConfigShopRecord cf;
    // Start is called before the first frame update
    public void Setup(ConfigShopRecord cf)
    {
        this.cf = cf;
        iconShop.overrideSprite = SpriteLibControl.instance.GetSpriteByName(cf.Icon);
        iconValue.overrideSprite = SpriteLibControl.instance.GetSpriteByName(cf.Icon_Value);
        valueLB.text = cf.Value.ToString();

        costDolaLB.text = cf.Cost_dollar.ToString();
        costPotionLB.text = cf.Cost_potion.ToString();
        btnDola.gameObject.SetActive(false);
        btnPotion.gameObject.SetActive(false);
        btnaAds.gameObject.SetActive(false);
        if(cf.Cost_dollar==0&&cf.Cost_potion==0)
        {
            btnaAds.gameObject.SetActive(true);
        }
        else if(cf.Cost_dollar != 0)
        {
            btnDola.gameObject.SetActive(true);
        }
        else if (cf.Cost_potion != 0)
        {
            btnPotion.gameObject.SetActive(true);
        }
    }
    public void AddPotion()
    {
        DataAPIController.instance.BuyPotion(cf);
    }
}
