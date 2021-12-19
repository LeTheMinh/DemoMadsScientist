using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DialogIndex
{
    DialogEquip,
    DialogMessage,
    DialogGameEnd,
    DialogPause
}
public class DialogParam
{

}
public class DialogEquipParam:DialogParam
{
    public int idGun;
}
public class DialogGameEndParam:DialogParam
{
    public int score;
}
public class DialogConfig
{
    public static DialogIndex[] indices = { DialogIndex.DialogEquip,DialogIndex.DialogGameEnd,DialogIndex.DialogPause };
}
