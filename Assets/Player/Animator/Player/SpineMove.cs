using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpineMove : MonoBehaviour
{
   /* Animator animator;
    Transform playerChestTr;
    Camera mainCameraTr;
    void Start()

    {

        animator = GetComponent<Animator>();

        if (animator)

            playerChestTr = animator.GetBoneTransform(HumanBodyBones.UpperChest); // 해당 본의 transform 가져오기

    }


    public void LateUpdate()

    {

        Operation_boneRotation();

    }





    Vector3 ChestOffset = new Vector3(0, -40, -100);

    Vector3 ChestDir = new Vector3();

    void Operation_boneRotation()

    {

        //카메라가 보고있는 방향

        ChestDir = mainCameraTr.position + mainCameraTr.forward * 50f;

        playerChestTr.LookAt(ChestDir); //상체를 카메라 보는방향으로 보기

        playerChestTr.rotation = playerChestTr.rotation * Quaternion.Euler(ChestOffset); // 상체가 꺽여 잇어 상체로테이션을 보정하기 

    }*/
}
