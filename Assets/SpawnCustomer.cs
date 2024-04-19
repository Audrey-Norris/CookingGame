using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{

    //INSTANTIATE PREFAB
    [SerializeField] GameObject prefab;
    //CAMERA
    [SerializeField] Camera cam;
    [SerializeField] GameObject customerTarget;


    public void spawnCustomer(Transform location) {
        GameObject newSpawn = Instantiate(prefab, location.position, location.rotation);
        newSpawn.GetComponent<MoveForward>().target = customerTarget.transform;
        GetComponent<GameManager>().customer = newSpawn;
    }

}
