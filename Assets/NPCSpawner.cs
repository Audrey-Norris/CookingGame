using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{

    [SerializeField] GameObject NPCPrefab;

    [SerializeField] GameObject movePosition;

    //TESTING
    public void Start() {
        SpawnNPC();
    }


    public void SpawnNPC() {
        if (NPCPrefab != null) {
            Vector3 position = transform.position;
            GameObject npc = Instantiate(NPCPrefab, position, Quaternion.identity);
            npc.GetComponent<NPCManager>().moveLocation = movePosition.transform;
        }
    }
}
