using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public int knifeDamage; 
    public float speed;
    public Rigidbody2D rb;
   
    void Start()
    {        
        rb.velocity = transform.up * speed * Time.fixedDeltaTime;               
    }

    private void OnCollisionEnter2D(Collision2D collision) // Code dupliqué sur 3-4 script, {explosion, attaque joueur 1, attaque joueur 2, knife}
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            GameObject Enemy = collision.gameObject;
            Enemy.GetComponent<EnemyLife>().TakeDamage(knifeDamage);                       
        }
    }

    private void Update() // ça j'aime pas, ptet faire une cooroutine pour la destruction du knife
    {
        if(rb.velocity.y < 0f)
        {
            Destroy(gameObject);
        }
    }
}
