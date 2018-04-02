using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureManager : MonoBehaviour {

    [SerializeField]
    GameObject TreasurePrefab;

    public static bool ChestGrabbed = false;


	// Use this for initialization
	void Start ()
    {
        Vector3 position = new Vector3(Random.Range(5f, 55f), Random.Range(0f, 20f), Random.Range(5f, 55f));
        Instantiate(TreasurePrefab, position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update ()
    {
        SpawnChest();
    }
    private void SpawnChest()
    {
        if( ChestGrabbed == true)
        {
            //Instantiate(TreasurePrefab,  Vector3(Random.Range(5, 55), Random.Range(0, 20), Random.Range(5, 55));

            Vector3 position = new Vector3(Random.Range(5f, 55f), Random.Range(0f, 20f), Random.Range(5f, 55f));
            Instantiate(TreasurePrefab, position, Quaternion.identity);


            ChestGrabbed = false;
        }

    }
}
