using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public Transform target; 
    [SerializeField] Billboard Billboard;
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move() {
        while (true) {
            // Calculate the direction to the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Calculate the distance to the target
            float distanceToTarget = Vector3.Distance(transform.position, target.position);

            // Move the object towards the target
            if (distanceToTarget > 0.1f) // Check if the object is not already at the target
            {
                transform.position += direction * speed * Time.deltaTime;
            } else {
                // If the object is close enough to the target, break out of the loop
                break;
            }

            // Wait for the next frame
            yield return null;
        }

        // Movement completed
        Debug.Log("Movement completed!");
        Billboard.enabled = true;
    }

}
