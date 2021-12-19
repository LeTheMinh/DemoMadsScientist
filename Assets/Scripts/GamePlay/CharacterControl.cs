using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public Transform anchorFront;
    [HideInInspector]
    public Transform trans;
    public float speedMove=1;
    private float speed = 1;
    private WeaponBehaviour currentWeapon;
    // Start is called before the first frame update
    private void Awake()
    {
        trans = transform;
        MissionControl.instance.OnMoveEvent += (isMove) =>
         {
             speed = isMove ? 1 : 0;
             
         };
        gameObject.GetComponent<WeaponControl>().OnChangeGun += (weapon) =>
        {
            currentWeapon = weapon;
        };
    }
  
    public void OnDamage(BulletInitData data)
    {
        currentWeapon.dataBinding.Hit = true;
        currentWeapon.OnDamage(data);
    }
    // Update is called once per frame
    void Update()
    {
       
        
        trans.Translate(Vector2.right * Time.deltaTime * speedMove* speed);
    }

    

}
