using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public enum Tttt { Idle, Idle1, Idle2 }
    Tttt tttt = Tttt.Idle;
    public float time = 0;
    public float time1;
    public float time2;
    
    private void Start()    
    {
        
    }
    private void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if (time <= time1)
        {
            StartCoroutine(Idle(time1));
            if (time <= time2)
            {
                StartCoroutine(Idle(time2));
                if (time < time2)
                {
                    time = 0;
                }
            }
        }
        
    }
    IEnumerator Idle(float time)
    {
        yield return new WaitForSeconds(time1);
        gameObject.SetActive(false);
        Debug.Log("10");
        Debug.Log(time1);
    }
    IEnumerator Idle1(float time1)
    {
        yield return new WaitForSeconds(time2);
        gameObject.SetActive(true);
        Debug.Log("20");
        Debug.Log(time2);
    }

}
