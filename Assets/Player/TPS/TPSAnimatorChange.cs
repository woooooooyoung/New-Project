using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class TPSAnimatorChange : MonoBehaviour
{
    [SerializeField] GameObject GreatSword;
    [SerializeField] GameObject Rifle;
    [SerializeField] GameObject Sword;
    [SerializeField] GameObject Shield;

    private Animator animator;

    private enum WeaponChange { Idle, GreatSword, Rifle, Sword, Shield, SwordandShield }

    private WeaponChange weaponChange = WeaponChange.Idle;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        switch (weaponChange)
        {
            case WeaponChange.Idle:
                IdleChange();
                break;
            case WeaponChange.GreatSword:
                GreatSwordChange();
                break;
            case WeaponChange.Rifle:
                RifleChange();
                break;
            case WeaponChange.Sword:
                SwordChange();
                break;
            case WeaponChange.Shield:
                ShieldChange();
                break;
            case WeaponChange.SwordandShield:
                SwordandShieldChange();
                break;

        }
    }
    private void IdleChange()
    {
        IdleLayer();

        Debug.Log("기본");
        GreatSword.SetActive(false);
        Rifle.SetActive(false);
        Sword.SetActive(false);
        Shield.SetActive(false);
        if (Input.GetKey(KeyCode.Keypad0))
        {
            weaponChange = WeaponChange.Idle;
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            weaponChange = WeaponChange.GreatSword;
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            weaponChange = WeaponChange.Rifle;
        }
        else if (Input.GetKey(KeyCode.Keypad3))
        {
            weaponChange = WeaponChange.Sword;
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {
            weaponChange = WeaponChange.Shield;
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            weaponChange = WeaponChange.SwordandShield;
        }
    }
    private void GreatSwordChange()
    {
        GreatSwordLayer();

        Debug.Log("대검");
        GreatSword.SetActive(true);
        Rifle.SetActive(false);
        Sword.SetActive(false);
        Shield.SetActive(false);
        if (Input.GetKey(KeyCode.Keypad0))
        {
            weaponChange = WeaponChange.Idle;
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            weaponChange = WeaponChange.GreatSword;
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            weaponChange = WeaponChange.Rifle;
        }
        else if (Input.GetKey(KeyCode.Keypad3))
        {
            weaponChange = WeaponChange.Sword;
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {
            weaponChange = WeaponChange.Shield;
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            weaponChange = WeaponChange.SwordandShield;
        }
    }
    private void RifleChange()
    {
        RifleLayer();
        Aiming();

        Debug.Log("총");
        GreatSword.SetActive(false);
        Rifle.SetActive(true);
        Sword.SetActive(false);
        Shield.SetActive(false);
        if (Input.GetKey(KeyCode.Keypad0))
        {
            weaponChange = WeaponChange.Idle;
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            weaponChange = WeaponChange.GreatSword;
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            weaponChange = WeaponChange.Rifle;
        }
        else if (Input.GetKey(KeyCode.Keypad3))
        {
            weaponChange = WeaponChange.Sword;
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {
            weaponChange = WeaponChange.Shield;
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            weaponChange = WeaponChange.SwordandShield;
        }
    }
    private void SwordChange()
    {
        SwordLayer();

        Debug.Log("한손검");
        GreatSword.SetActive(false);
        Rifle.SetActive(false);
        Sword.SetActive(true);
        Shield.SetActive(false);
        if (Input.GetKey(KeyCode.Keypad0))
        {
            weaponChange = WeaponChange.Idle;
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            weaponChange = WeaponChange.GreatSword;
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            weaponChange = WeaponChange.Rifle;
        }
        else if (Input.GetKey(KeyCode.Keypad3))
        {
            weaponChange = WeaponChange.Sword;
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {
            weaponChange = WeaponChange.Shield;
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            weaponChange = WeaponChange.SwordandShield;
        }
    }
    private void ShieldChange()
    {
        ShieldLayer();

        Debug.Log("방패");
        GreatSword.SetActive(false);
        Rifle.SetActive(false);
        Sword.SetActive(false);
        Shield.SetActive(true);
        if (Input.GetKey(KeyCode.Keypad0))
        {
            weaponChange = WeaponChange.Idle;
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            weaponChange = WeaponChange.GreatSword;
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            weaponChange = WeaponChange.Rifle;
        }
        else if (Input.GetKey(KeyCode.Keypad3))
        {
            weaponChange = WeaponChange.Sword;
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {
            weaponChange = WeaponChange.Shield;
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            weaponChange = WeaponChange.SwordandShield;
        }
    }
    private void SwordandShieldChange()
    {
        SwordandShieldLayer();

        Debug.Log("검과 방패");
        GreatSword.SetActive(false);
        Rifle.SetActive(false);
        Sword.SetActive(true);
        Shield.SetActive(true);
        if (Input.GetKey(KeyCode.Keypad0))
        {
            weaponChange = WeaponChange.Idle;
        }
        else if (Input.GetKey(KeyCode.Keypad1))
        {
            weaponChange = WeaponChange.GreatSword;
        }
        else if (Input.GetKey(KeyCode.Keypad2))
        {
            weaponChange = WeaponChange.Rifle;
        }
        else if (Input.GetKey(KeyCode.Keypad3))
        {
            weaponChange = WeaponChange.Sword;
        }
        else if (Input.GetKey(KeyCode.Keypad4))
        {
            weaponChange = WeaponChange.Shield;
        }
        else if (Input.GetKey(KeyCode.Keypad5))
        {
            weaponChange = WeaponChange.SwordandShield;
        }
    }

    private void Aiming()
    {
        if (Input.GetMouseButton(1))
        {
            animator.SetLayerWeight(6, 1);
        }
        else
        {
            animator.SetLayerWeight(6, 0);
        }
    }
    private void IdleLayer()
    {
        animator.SetLayerWeight(1, 0);
        animator.SetLayerWeight(2, 0);
        animator.SetLayerWeight(3, 0);
        animator.SetLayerWeight(4, 0);
        animator.SetLayerWeight(5, 0);
    }
    private void GreatSwordLayer()
    {
        animator.SetLayerWeight(1, 1);
        animator.SetLayerWeight(2, 0);
        animator.SetLayerWeight(3, 0);
        animator.SetLayerWeight(4, 0);
        animator.SetLayerWeight(5, 0);
    }

    private void RifleLayer()
    {
        animator.SetLayerWeight(1, 0);
        animator.SetLayerWeight(2, 1);
        animator.SetLayerWeight(3, 0);
        animator.SetLayerWeight(4, 0);
        animator.SetLayerWeight(5, 0);
    }
    private void SwordLayer()
    {
        animator.SetLayerWeight(1, 0);
        animator.SetLayerWeight(2, 0);
        animator.SetLayerWeight(3, 1);
        animator.SetLayerWeight(4, 0);
        animator.SetLayerWeight(5, 0);
    }
    private void ShieldLayer()
    {
        animator.SetLayerWeight(1, 0);
        animator.SetLayerWeight(2, 0);
        animator.SetLayerWeight(3, 0);
        animator.SetLayerWeight(4, 1);
        animator.SetLayerWeight(5, 0);
    }
    private void SwordandShieldLayer()
    {
        animator.SetLayerWeight(1, 0);
        animator.SetLayerWeight(2, 0);
        animator.SetLayerWeight(3, 0);
        animator.SetLayerWeight(4, 0);
        animator.SetLayerWeight(5, 1);
    }
}
























