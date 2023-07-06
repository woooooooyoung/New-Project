using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Cube : MonoBehaviour
{
    /*[SerializeField] Rigidbody rigidbody;
    [SerializeField] Renderer renderer;

    [SerializeField] float upForce = 1f;
    [SerializeField] float sideForce = 0.1f;

    // 매개변수와 관계없이 활성화시 초기화로직 (OnDisable은 굳이 구현 안해도 됨)
    private void OnEnable() // 랜덤하게 위로 발사함
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(-upForce * 0.5f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);
        Vector3 force = new Vector3(xForce, yForce, zForce);
        rigidbody.velocity = force;

        Invoke(nameof(DeactiveDelay), 5);

    }

    // 들어온 매개변수에 대하여 바꿔야하는 로직
    public void Setup(Color color) 
    {
        renderer.material.color = color;
    }
    void DeactiveDelay() => gameObject.SetActive(false); // OnEnable에서 5초뒤에 gameObject 비활성화

    private void OnDisable()
    {
        objectPooler.RetuenTpPool(gameObject);
        CancelInvoke();
    }*/
}
