using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private Camera mainCam;


    private IObjectPool<Bullet> pool; // Pool ���
    private void Awake()
    {
        // �ؿ� ���� �Լ����� Pool�� ������ �Ű������� �־��ְ�, ���� ������ ������Ʈ �ִ밹���� �־��� (maxSize: n)
        pool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, OnDestroyBullet, maxSize: 200); // Pool ���
    }
    private void Start()
    {
        mainCam = Camera.main;

    }
    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit))
            {
                    var direction = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                // �Ѿ��� ���� �����ؼ� ���
                //var bullet =Instantiate(bulletPrefab, transform.position + direction.normalized, Quaternion.identity).GetComponent<Bullet>();
                var bullet = pool.Get(); // �Ѿ��� ������ȭ �ؼ� �Ѿ� ������Ʈ�� �����ϴ� �κ��� �ڵ带 ������Ʈ Ǯ�� ����ϵ��� �ڵ带 ����
                bullet.transform.position = transform.position + direction.normalized;
                bullet.Shoot(direction.normalized);
            }
        }
    }
    private Bullet CreateBullet() // Bullet ������ ȣ�� �Լ�
    {
        Bullet bullet = Instantiate(bulletPrefab).GetComponent<Bullet>();   // ������ �ִ� ���������� Bullet ����
        bullet.SetManagedPool(pool);                                        // ������ Bullet������Ʈ�� �ڽ��� ��ϵǾ�� �� Pool
        return bullet;                                                      // ��ȯ
    }
    private void OnGetBullet(Bullet bullet)                                 // ������Ʈ�� Pool�� ������ �� ���� �Լ�
    {
        bullet.gameObject.SetActive(true);
    }
    private void OnReleaseBullet(Bullet bullet)                             // ������Ʈ�� Pool�� ������ �� ���� �Լ�
    {
        bullet.gameObject.SetActive(false);
    }
    private void OnDestroyBullet(Bullet bullet)                             // ������Ʈ�� Pool���� �ı��� �� ���� �Լ�
    {
        Destroy(bullet.gameObject);
    }
}
