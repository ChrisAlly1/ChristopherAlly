using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Mob : MonoBehaviour {
    public enum State
    {
        Idle,
        Initialize,
        Setup,
        Spawnmob
    }
    public GameObject[] mobPrefabs; //an array to hold all of the prefabs of mobs we want to spawn
    public GameObject[] spawnPoints; // this array will hold a reference to all of the spawnpoints in the scene
    public State state; // this is our local variable to holds our current state

    void Awake()
    {
        state = Mob.State.Initialize;
    }
	// Use this for initialization
	IEnumerator Start () {
        while (true)
        {
            switch (state) {
                case State.Initialize:
                    Initialize();
                    break;
                case State.Setup:
                    Setup();
                    break;

                case State.Spawnmob:
                    Spawnmob();
                    break;

                case State.Idle:
                  
              

                    break;
              
              
            }
            yield return 0;
        }
	
	

	}
    private void Initialize()
    {
        //Debug.Log("initialize");
        if (!CheckForMobPrefabs())
            return;
        if (!CheckForSpawnPoints())
            return;

        state = Mob.State.Setup;
    }
    private void Setup()
    {
        Debug.Log("Setup");
        state = Mob.State.Spawnmob;
    }
    public void Spawnmob()
    {
        Debug.Log("Spawnmob");

        GameObject[] gos = SpawnPoints();
        for (int cnt = 0; cnt < gos.Length; cnt++ )
        {
            GameObject go = Instantiate(mobPrefabs[Random.Range(0, mobPrefabs.Length)],
                gos[cnt].transform.position,
                Quaternion.identity) as GameObject;
            go.transform.parent = gos[cnt].transform;

          
        }
            state = Mob.State.Idle;
    }

    //check to see that we have at least one mob prefab to spawn
    private bool CheckForMobPrefabs()
    {
        if (mobPrefabs.Length > 0)
            return true;
        else
            return false;
    }
    //check to see if we have atleast one spawn point to spawn mobs at

    private bool CheckForSpawnPoints()
    {
        if (spawnPoints.Length > 0)
            return true;
        else
            return false; 
        }

    private GameObject[] SpawnPoints()
    {
        List<GameObject> gos = new List<GameObject>();

        for(int cnt = 0; cnt < spawnPoints.Length; cnt++)
        {
            if(spawnPoints[cnt].transform.childCount == 0){
                Debug.Log("spawn points");
                gos.Add(spawnPoints[cnt]);
            }
        }
        return gos.ToArray();
    }

}

