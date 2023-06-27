using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AnimatorChange : MonoBehaviour
{
    [SerializeField] GameObject GreatSword;
    [SerializeField] GameObject Rifle;
    [SerializeField] GameObject Sword;
    [SerializeField] GameObject Shield;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        GreatSwordGet();
        RifleGet();
        SwordGet();
        ShieldGet();
        SwordandShieldGet();
    }

    private void GreatSwordGet()
    {
        if (GreatSword.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                GreatSword.SetActive(false);
                GreatSwordLayer();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                GreatSword.SetActive(true);
                Rifle.SetActive(false);
                Sword.SetActive(false);
                Shield.SetActive(false);
                GreatSwordLayer();
            }
        }
    }
    private void RifleGet()
    {
        if (Rifle.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Rifle.SetActive(false);
                RifleLayer();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                GreatSword.SetActive(false);
                Rifle.SetActive(true);
                Sword.SetActive(false);
                Shield.SetActive(false);
                RifleLayer();
            }
        }
    }
    private void SwordGet()
    {
        if (Sword.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Sword.SetActive(false);
                SwordLayer();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                GreatSword.SetActive(false);
                Rifle.SetActive(false);
                Sword.SetActive(true);
                Shield.SetActive(false);
                SwordLayer();
            }
        }
    }
    private void ShieldGet()
    {
        if (Shield.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                Shield.SetActive(false);
                ShieldLayer();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                GreatSword.SetActive(false);
                Rifle.SetActive(false);
                Sword.SetActive(false);
                Shield.SetActive(true);
                ShieldLayer();
            }
        }
    }
    private void SwordandShieldGet()
    {
        if (Sword.activeSelf || Shield.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Shield.SetActive(false); 
                Sword.SetActive(false);
                SwordandShieldLayer();
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                GreatSword.SetActive(false);
                Rifle.SetActive(false);
                Sword.SetActive(true);
                Shield.SetActive(true);
                SwordandShieldLayer();
            }
        }

        
        //if (Sword.activeSelf && Shield.activeSelf)
        //{
        //    if (Input.GetKeyDown(KeyCode.Y))
        //    {
        //        Shield.SetActive(false);
        //        Sword.SetActive(false);
        //        SwordandShieldLayer();
        //    }
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Y))
        //    {
        //        GreatSword.SetActive(false);
        //        Rifle.SetActive(false);
        //        Shield.SetActive(true);
        //        Shield.SetActive(true);
        //        SwordandShieldLayer();
        //    }
        //
        //}
    }
    private void GreatSwordLayer()
    {
        if (GreatSword.activeSelf)
        {
            animator.SetBool("GreatSword", true);
            animator.SetLayerWeight(1, 1);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(4, 0);
            animator.SetLayerWeight(5, 0);
        }
        else
        {
            animator.SetBool("GreatSword", false);
            animator.SetLayerWeight(1, 0);
        }
    }

    private void RifleLayer()
    {
        if (Rifle.activeSelf)
        {
            animator.SetBool("Rifle", true);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 1);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(4, 0);
            animator.SetLayerWeight(5, 0);
        }
        else
        {
            animator.SetBool("Rifle", false);
            animator.SetLayerWeight(2, 0);
        }
    }
    private void SwordLayer()
    {
        if (Sword.activeSelf)
        {
            animator.SetBool("Sword", true);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 1);
            animator.SetLayerWeight(4, 0);
            animator.SetLayerWeight(5, 0);
        }
        else
        {
            animator.SetBool("Sword", false);
            animator.SetLayerWeight(3, 0);
        }
    }
    private void ShieldLayer()
    {
        if (Shield.activeSelf)
        {
            animator.SetBool("Shield", true);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(4, 1);
            animator.SetLayerWeight(5, 0);
        }
        else
        {
            animator.SetBool("Shield", false);
            animator.SetLayerWeight(4, 0);
        }
    }
    private void SwordandShieldLayer()
    {
        if (Sword.activeSelf || Shield.activeSelf)
        {
            animator.SetBool("Sword&Shield", true);
            animator.SetLayerWeight(1, 0);
            animator.SetLayerWeight(2, 0);
            animator.SetLayerWeight(3, 0);
            animator.SetLayerWeight(4, 0);
            animator.SetLayerWeight(5, 1);
        }
        else
        {
            animator.SetBool("Sword&Shield", false);
            animator.SetLayerWeight(5, 0);
        }
    }
}






















