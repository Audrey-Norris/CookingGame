using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Item testItem;

    public void Start() {
        
        if(testItem is Material) {
            Material mat = testItem as Material;
            Debug.Log("Material: " + mat.qualities);
        }
    }
}
