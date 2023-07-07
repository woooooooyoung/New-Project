using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    private void Start()
    {
        Enemy1 enemy1 = new Enemy1();
        Enemy2 enemy2 = new Enemy2();
        
        enemy1.A();
        enemy2.A();
        enemy1.B();
        enemy2.B();
        enemy1.C();
        enemy2.C();
        enemy1.Sound();
        enemy2.Sound();
        enemy1.information("aa", 10, 50, 10);
        
        
    }


}
abstract class Monster
{
    [Header("information")]
    public string name;
    public float health;
    public float damage;
    public float speed;

    public void information(string name, float health, float damage, float speed)
    {
        this.name = name;
        this.health = health;
        this.damage = damage;
        this.speed = speed;
    
    }
    public void A()
    {
        Debug.Log("A");
    }
    public void B()
    {
        Debug.Log("B");
    }
    public void C()
    {
        Debug.Log("C");
    }
    public abstract void Sound();
}
class Enemy1 : Monster
{
    public override void Sound()
    {
        Debug.Log("근접");
    }
}
class Enemy2 : Monster
{
    public override void Sound()
    {
        Debug.Log("원거리");
    }
}
