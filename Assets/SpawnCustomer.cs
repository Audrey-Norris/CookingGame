using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{

    //INSTANTIATE PREFAB
    [SerializeField] GameObject prefab;
    //CAMERA
    [SerializeField] Camera cam;
    // Start is called before the first frame update

    public void spawnCustomer(Transform location) {
        Debug.Log("RUNNING");
        GameObject newSpawn = Instantiate(prefab, location.position, location.rotation);
        newSpawn.GetComponent<Billboard>().m_Camera = cam;

    }

}
