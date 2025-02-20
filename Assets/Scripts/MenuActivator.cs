using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivator : MonoBehaviour
{
    [SerializeField] private PlayerActions playerActions;
    [SerializeField] private bool isActive = false;
    [SerializeField] private Canvas inventory;

    void Awake() {
        playerActions = new PlayerActions();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleInventory();
    }

    public void ToggleInventory() {
        bool actionPressed = playerActions.Actions.Inventory.WasReleasedThisFrame();
        if(actionPressed) {
            if (isActive) {
                inventory.enabled = false;
                isActive = false;
                inventory.gameObject.GetComponent<InventoryCanvas>().RemoveAllItems();
            } else {
                inventory.enabled = true;
                isActive = true;
                inventory.gameObject.GetComponent<InventoryCanvas>().PopulateItems();
            }
        }

    }

    private void OnEnable() {
        playerActions.Actions.Enable();
    }

    private void OnDisable() {
        playerActions.Actions.Disable();
    }
}
