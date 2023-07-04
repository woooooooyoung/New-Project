using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MS1 : MonoBehaviour
{
    public bool deBug;
    public float spawnGizmo;
    public static MS1 instance;

    public GameObject enemy = null;
    public float xPos;
    public float zPos;
    private Vector3 RandomVector;

    public Queue<GameObject> queue = new Queue<GameObject>();

    private void Start()
    {
        instance = this;
        for (int i = 0; i <10; i++)
        {
        GameObject t_object = Instantiate(enemy, Vector3.zero, Quaternion.identity);
        queue.Enqueue(t_object);
        t_object.SetActive(false);
        }
        StartCoroutine(MonsterSpawn());
    }
    public void InsertQueue(GameObject p_object)
    {

        queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetQueue()
    {
        GameObject t_object = queue.Dequeue();
        t_object.SetActive(true);

        return t_object;
    }

    IEnumerator MonsterSpawn()
    {
        while (true)
        {
            if (queue.Count != 0)
            {
                xPos = Random.Range(-5, 5);
                zPos = Random.Range(-5, 5);
                RandomVector = new Vector3(xPos, 0.0f, zPos);
                GameObject t_object = GetQueue();
                t_object.transform.position = gameObject.transform.position + RandomVector;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (!deBug)
            return;


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnGizmo);

        //Gizmos.color = Color.white;
        //Gizmos.DrawWireSphere(transform.position, attackRang);
    }
    public override void Die()
    {

        gameObject.SetActive(false);
        //hpBar.SetActive(false);

        GetComponent<EnemyInformation>().enemies.Clear();
        GetComponent<EnemyInformation>().detected.Clear();

        MS1.instance.InsertQueue(gameObject);
    }

}
