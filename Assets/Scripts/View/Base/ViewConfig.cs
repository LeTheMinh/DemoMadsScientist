using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ViewIndex
{
    EmptyView = 0,
    HomeView = 1,
    LoadingView = 2,
    IngameView = 3,
    WeaponView=4,
    QuestView=5,
    ShopView=6
}
public class ViewConfig
{
    public static ViewIndex[] viewIndices =
        {
            ViewIndex.EmptyView,
            ViewIndex.HomeView,
            ViewIndex.IngameView,
            ViewIndex.WeaponView,
            ViewIndex.ShopView,
            ViewIndex.QuestView
        };
}
public class ViewParam
{

}