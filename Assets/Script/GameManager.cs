using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public LevelGenerator levelGenerator;
    public Room[] room;
    private void Awake()
    {
        instance = this;
        //levelGenerator = new LevelGenerator();
        //levelGenerator.moveAndBuild();
    }

    private void Start()
    {
        for (int i = 0; i < levelGenerator.nbTotalRooms; i++)
        {
            
        }

    }

    void Update()
    {
        
    }       

    private onDeath(Room room)
    {

    }
}
