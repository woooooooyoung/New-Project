using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CrusaderUI.Scripts;



public class MPController : MonoBehaviour
{
    public Material _material;
    [Range(0f, 1f)]
    public float m_Silder;

    private void Start()
    {
        _material = GetComponent<Image>().material;
    }
    private void Update()
    {
        SetValue(m_Silder);
    }
    public void SetValue(float value)
    {

        _material.SetFloat("_FillLevel", value);

    }
}

