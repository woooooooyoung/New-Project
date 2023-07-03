using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asdas : MonoBehaviour
{
    public int A1;
    public int A2;
    private void OnEnable()
    {
        A1++;
    }
    private void OnDisable()
    {
        A2++;
    }
}
