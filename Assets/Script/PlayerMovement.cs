using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    public float moveSpeed;

    Vector2 movement;

    [SerializeField]
    Rigidbody2D rb;

    //Pour faire des explosion avec E
    public GameObject explosionPrefab;


    private void Awake()
    {
        //C'est un sorte d'assignation ?
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() //Détéction des inputs
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
    }

    private void FixedUpdate() //Gestion de la physique dans cette methode c'est plus cool
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
