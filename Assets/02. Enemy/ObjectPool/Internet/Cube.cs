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

    // �Ű������� ������� Ȱ��ȭ�� �ʱ�ȭ���� (OnDisable�� ���� ���� ���ص� ��)
    private void OnEnable() // �����ϰ� ���� �߻���
    {
        float xForce = Random.Range(-sideForce, sideForce);
        float yForce = Random.Range(-upForce * 0.5f, upForce);
        float zForce = Random.Range(-sideForce, sideForce);
        Vector3 force = new Vector3(xForce, yForce, zForce);
        rigidbody.velocity = force;

        Invoke(nameof(DeactiveDelay), 5);

    }

    // ���� �Ű������� ���Ͽ� �ٲ���ϴ� ����
    public void Setup(Color color) 
    {
        renderer.material.color = color;
    }
    void DeactiveDelay() => gameObject.SetActive(false); // OnEnable���� 5�ʵڿ� gameObject ��Ȱ��ȭ

    private void OnDisable()
    {
        objectPooler.RetuenTpPool(gameObject);
        CancelInvoke();
    }*/
}
