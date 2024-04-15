using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameObject spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpawnCustomer>().spawnCustomer(spawnLocation.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
