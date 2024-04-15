using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move() {
        GetComponent<Rigidbody>().velocity = transform.forward *2;
        yield return new WaitForSeconds(2);
    }

}
