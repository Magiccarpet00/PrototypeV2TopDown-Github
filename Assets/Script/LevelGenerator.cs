using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Variable room
    public GameObject[] roomPrefab;
    public float moveAmount = 14f;
    public int nbTotalRooms;

    //  Variable Paterne
    public GameObject[] paternePrefab;

    void Start()
    {
        moveAndBuild();
    }

    public void moveAndBuild()
    {
        for (int i = 0; i < nbTotalRooms; i++)
        {
            //Crée une nouvelle rooms
            Vector2 newPos = new Vector2(transform.position.x, transform.position.y + moveAmount);
            transform.position = newPos;
            Instantiate(roomPrefab[0], newPos, Quaternion.identity);
            Room room = roomPrefab[0].GetComponent<Room>();

            

            //Crée un paterne dans la room            
            int rngPaterne = Random.Range(0, paternePrefab.Length);
            Instantiate(paternePrefab[rngPaterne], newPos, Quaternion.identity);
            
            // Pour savoir ya combient de monstre dans la room 
            Paterne paterne = paternePrefab[rngPaterne].GetComponent<Paterne>();




            int nbMonstre = paterne.nbMonstre;

            // Association nombre de monstres dans la room au nb de monstre du paterne
            room.nbMonstre = paterne.nbMonstre;

            Debug.Log(nbMonstre);
            //mettre nbMonstre dans le tableau 

            //Ajouter des référenes à notre gameManager pour qu'il connaisse les rooms
            GameManager.instance.room[i] = room;

            // babybaby
            for (int j = 0; j < paterne.transform.GetChildCount(); j++)
            {
                Transform t = paterne.transform.GetChild(j);
                EnemyLocation enemyLocation = t.GetComponent<EnemyLocation>();
                enemyLocation.room = room;
            }
            
        }        
    }
}
