using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using System;

public class CharacterDataBinding : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    private Spine.Skeleton skeleton;
    public AnimationReferenceAsset AnimKey_Walk;
    public AnimationReferenceAsset AnimKey_Idle;
    public AnimationReferenceAsset AnimKey_Fire;
    public AnimationReferenceAsset AnimKey_Hit;
    public AnimationReferenceAsset AnimKey_Dead;
    [SpineBone(dataField: "skeletonAnimation")]
    public string boneHGName;
    private Spine.Bone bone_HandGun;
    [SpineBone(dataField: "skeletonAnimation")]
    public string boneHLName;
    private Spine.Bone bone_HandLeft;
    [SpineBone(dataField: "skeletonAnimation")]
    public string boneHeadName;
    private Spine.Bone bone_Head;

    [Range(-20f, 50f)]
    public float angle = 0;
    public Transform anchorAim;
    public Transform anchorRotation;
    private AnimationReferenceAsset animLocomotion;
    public Action UpdateLocalAnim;
    private float speed;
    private float Speed
    {
        set
        {
             speed = Mathf.RoundToInt(value);
            animLocomotion = speed == 1 ? AnimKey_Walk : AnimKey_Idle;
            skeletonAnimation.AnimationState.SetAnimation(0, animLocomotion, true);

        }
    }
    public bool Fire
    {
        set
        {
            if (value)
            {
                skeletonAnimation.AnimationState.SetAnimation(0, AnimKey_Fire, false);
                skeletonAnimation.AnimationState.AddAnimation(0, animLocomotion, true, 0.17f);
            }

        }
    }
    public bool Hit
    {
        set
        {
            if (value)
            {
                skeletonAnimation.AnimationState.SetAnimation(0, AnimKey_Hit, false);
                skeletonAnimation.AnimationState.AddAnimation(0, animLocomotion, true, 0.17f);
            }

        }
    }
    public bool Dead
    {
        set
        {
            if (value)
            {
                skeletonAnimation.AnimationState.SetAnimation(0, AnimKey_Dead, false);
                skeletonAnimation.AnimationState.AddAnimation(0, animLocomotion, true, 0.17f);
            }

        }
    }
    private float timeDelay;
    void Awake()
    {
        skeleton = skeletonAnimation.Skeleton;

        MissionControl.instance.OnMoveEvent += (isMove) =>
        {
            Speed = isMove ? 1 : 0;
        };

    }

    // Start is called before the first frame update
    void Start()
    {
        bone_HandGun = skeletonAnimation.Skeleton.FindBone(boneHGName);
        bone_HandLeft = skeletonAnimation.Skeleton.FindBone(boneHLName);
        bone_Head = skeletonAnimation.Skeleton.FindBone(boneHeadName);
        skeletonAnimation.UpdateLocal += UpdateLocal;
    }
    void OnValidate()
    {
        bone_HandGun = skeletonAnimation.Skeleton.FindBone(boneHGName);
    }

    private void UpdateLocal(ISkeletonAnimation animated)
    {
        bone_HandGun.Rotation += angle;
        bone_HandLeft.Rotation += angle * 2.15f;
        bone_Head.Rotation += angle;


    }

    // Update is called once per frame
    public void Update()
    {
        if (speed == 0&&Input.GetMouseButton(0))
        {

            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            if (worldMousePosition.x >= anchorAim.position.x)
            {
                timeDelay += Time.deltaTime;
                worldMousePosition.z = anchorAim.position.z;

                Vector3 dir = worldMousePosition - anchorAim.position;

                //1.
                //dir.Normalize();
                //angle = Vector3.Angle(dir, anchorAim.right);
                //if (worldMousePosition.y < anchorAim.position.y)
                //    angle *= -1;
                //2. 
                //dir.Normalize();
                //angle = Vector3.Angle(dir, anchorAim.right);
                //float dot = Vector3.Dot(dir, anchorAim.up);
                //if (dot<0)
                //    angle *= -1;
                //3.
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                if (timeDelay > 0.01f)
                    UpdateLocalAnim?.Invoke();
            }
            else
            {
                timeDelay = 0;
                angle = 0;
            }


        }
        else
        {
            timeDelay = 0;
            angle = 0;
        }
        anchorRotation.localEulerAngles = new Vector3(anchorRotation.localEulerAngles.x, anchorRotation.localEulerAngles.y, bone_HandGun.Rotation);

    }
}
