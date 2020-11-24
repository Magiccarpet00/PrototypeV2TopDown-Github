using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public int maxShield;
    public int currentShield;
    
    public GameObject explosionPrefab;
    
    void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;

        // Petite filoutrie pour detruire le shield si max shield = 0
        // De basse tous les ennemy on un shield mais sur Start je detruit tout hihi
        BreakShield();
    }

    public void TakeDamage(int damage)
    {
        if(currentShield > 0)
        {
            currentShield = currentShield - damage;
            BreakShield();

        }
        else
        {
            currentHealth = currentHealth - damage;
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    public void Die()
    {        
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);

        
    }

    public void BreakShield()
    {
        if (currentShield <= 0)
        {               
            // Truc trouver sur le web pour détruire un child 
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
        
    }
}
