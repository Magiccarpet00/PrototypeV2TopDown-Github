using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int explosionDamage;
    public Collider2D hitBox;

    [SerializeField]
    SpriteRenderer spriteRenderer;
    private void Start() //Pour le changer un peut l'axe de l'explosion, uniquement visuel
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        
        int rngX = Random.Range(0, 2);
        int rngY = Random.Range(0, 2);        
        if (rngX > 0)
        {
            spriteRenderer.flipX = true;
        }
        if (rngY > 0)
        {
            spriteRenderer.flipY = true;
        }
    }

    public void ExplosionStart()
    {           
        hitBox.enabled = true;
    }

    public void ExplotionEnd()
    {
        hitBox.enabled = false;
    }

    public void DestoyOpti()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            GameObject Enemy = collision.gameObject;
            Enemy.GetComponent<EnemyLife>().TakeDamage(explosionDamage);
        }
    }
}
