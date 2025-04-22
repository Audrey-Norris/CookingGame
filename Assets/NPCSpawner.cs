using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{

    [SerializeField] GameObject NPCPrefab;

    [SerializeField] GameObject movePosition;

    [SerializeField] SoundEffectManager soundEffectManager;

    public void SpawnNPC() {
        if (NPCPrefab != null) {
            Vector3 position = transform.position;
            GameObject npc = Instantiate(NPCPrefab, position, Quaternion.identity);
            npc.GetComponent<NPCManager>().moveLocation = movePosition.transform;
            npc.GetComponent<NPCManager>().soundmanager = soundEffectManager;
            npc.transform.LookAt(movePosition.transform);
        }
    }
}
