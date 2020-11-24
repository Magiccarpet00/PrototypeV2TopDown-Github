using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   
    public GameObject knifePrefab;
    public Animator animator;

    public bool onCoolDown;
    public float coolDownFloat;
        

    // l'axes Z qui permet une rotation pou le shoot
    public float zAxe;
    // Avec cette constante on ajuste l'angle de la rotation et j'aime bien -4f attention defois ça change, chelouuuuuu
    public float constantRotation;
        
    void Update()
    {
        if (Input.GetButton("Knife") && onCoolDown == false)
        {
            zAxe = Input.GetAxisRaw("Horizontal");
            StartCoroutine(Shoot());
        }       
    }

    IEnumerator Shoot()
    {
        onCoolDown = true;

        //L'objet knife est crée et le script knife prend le relais
        GameObject knife = Instantiate(knifePrefab, transform.position, Quaternion.Euler(0f, 0f, (zAxe * constantRotation)));

        // On joue l'annimation
        animator.SetTrigger("shoot");

        // La partie cooldown
        yield return new WaitForSeconds(coolDownFloat);
        onCoolDown = false;
        
    }    
}
