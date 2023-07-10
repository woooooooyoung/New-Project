using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour
{
    public Material _material;
    [Range(0f, 1f)]
    public float h_Silder;

    private void Start()
    {
        _material = GetComponent<Image>().material;
    }
    private void Update()
    {
        SetValue(h_Silder);
    }
    public void SetValue(float value)
    {

        _material.SetFloat("_FillLevel", value);

    }
}
