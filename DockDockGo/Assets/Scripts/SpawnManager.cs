using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerShip;
    public GameObject station;
    private Vector3 shipSpawnPosition = new Vector3(0, 0, 0);
    private Vector3 stationSpawnPosition = new Vector3(0, 0, 50);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnNewPlayerShip()
    {
        //Adam: this is where you'll probably add a reference to your procedural script.

        Instantiate(playerShip, shipSpawnPosition, playerShip.transform.rotation);
    }
    public void SpawnNewStation()
    {
        Instantiate(station, stationSpawnPosition, station.transform.rotation);
    }
}
