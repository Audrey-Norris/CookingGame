using UnityEngine;

public class Interact : MonoBehaviour {
    public Transform targetObject; // The target object to check proximity to
    public float interactionDistance = 2f; // The distance threshold for interaction

    public bool isInteract() {
        Debug.Log("Running!" + targetObject.transform);
        // Calculate the distance between this object and the target object
        float distanceToTarget = Vector3.Distance(transform.position, targetObject.position);
        Debug.Log(distanceToTarget);
        // Check if the distance is below the interaction distance
        if (distanceToTarget <= interactionDistance) {
            return true;

        } else {
            return false;
        }
    }
}