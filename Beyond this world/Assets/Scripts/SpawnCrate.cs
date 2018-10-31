using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrate : MonoBehaviour {

    public GameObject crate;
    public Lever lever;

    public void Spawn()
    {
        GameObject spawnedCrate = Instantiate(crate, gameObject.transform);
        lever.spawnedCrate = spawnedCrate;
    }
}
