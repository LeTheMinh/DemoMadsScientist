using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponHandle 
{
    void Init(WeaponBehaviour weaponBehaviour);
    void FireHandle();
    void ReloadHandle();
}
