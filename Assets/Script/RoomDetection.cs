using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDetection : MonoBehaviour
{

    //--------------------------------------------------------------------------------
    // Je pense qu'il y a moyen d'ameliorer ce script en evitant la duplication de code
    //--------------------------------------------------------------------------------

    public GameObject cam1;
    public GameObject cam2;

    public Vector3 velocity;
    public float timeOffSet;
    public Vector3 posOffSet;

    public bool onRoom;
    public bool roomFini;

    public int nbMonstreInRoom;


    void Start()
    {
        // Le BAZOOKAAA (mais la j'ai le droit pcq c'est cool)
        cam1 = GameObject.FindGameObjectWithTag("Camera1");
        cam2 = GameObject.FindGameObjectWithTag("Camera2");


        // Recupéré le nombre de mosnter

            //nbMonstreInRoom = qqch dans le Level generator

    }

    void Update() // Pas très optimiser cette fonction uptade pcq elle est duplique pour toute les rooms
    {
        if(onRoom == true)
        {
            //Grosse ligne de code avec des parametre modifer dans l'inspecteur 
            cam1.transform.position = Vector3.SmoothDamp(cam1.transform.position, transform.GetComponentInParent<Transform>().position + posOffSet, ref velocity, timeOffSet);
            // Mais normalement elle est doit marcher aussi si on va à gauche ou à droite
        }

        if(roomFini == true)
        {
            Debug.Log("room fini");
        }
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
           onRoom = true;                      
        }

        if (collision.CompareTag("Player2"))
        {
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            onRoom = false;
        }

        if (collision.CompareTag("Player2"))
        {

        }
    }    
}
