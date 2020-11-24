using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Variable room
    public GameObject[] room;
    public float moveAmount = 14f;
    public int nbTotalRooms;

    //  Variable Paterne
    public GameObject[] paterne;   

    void Start()
    {
        moveAndBuild();
    }    

    void moveAndBuild()
    {
        for (int i = 0; i < nbTotalRooms; i++)
        {
            //Crée une nouvelle rooms
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveAmount);
            transform.position = newPos;
            Instantiate(room[0], newPos, Quaternion.identity);

            //Crée un paterne dans la room
            
            int rngPaterne = Random.Range(0, paterne.Length);
            Instantiate(paterne[rngPaterne], newPos, Quaternion.identity);


            // Pour savoir ya combient de monstre dans la room 
            Paterne script = paterne[rngPaterne].GetComponent<Paterne>();
            int nbMonstre = script.nbMonstre;

            Debug.Log(nbMonstre);
            
        }        
    }
}
