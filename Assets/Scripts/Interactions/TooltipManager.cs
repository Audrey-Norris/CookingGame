using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TooltipManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] public bool isActive = false;

    [SerializeField] private GameObject toolTip;

    public void Start() {
        if(this.GetComponent<ItemInfo>().GetMenu().GetComponent<SpiceManager>()) {
            toolTip = this.GetComponent<ItemInfo>().GetMenu().GetComponentInChildren<ToolTipInfo>().gameObject;
        } else if(this.GetComponent<ItemInfo>().GetMenu().GetComponent<InventoryCanvas>()) {
            toolTip = this.GetComponent<ItemInfo>().GetMenu().GetComponentInChildren<ToolTipInfo>().gameObject;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isActive) {
            ShowTooltip();
        } else {
            if (!toolTip.GetComponent<ToolTipInfo>().isActive) {
                HideTooltip();
            }
        } 
    }

    public void ShowTooltip() {
        if(this.GetComponent<ItemInfo>().GetMenu().GetComponent<SpiceManager>()) {
            toolTip.transform.GetChild(0).gameObject.SetActive(true);
        }
        toolTip.GetComponent<ToolTipInfo>().LoadInfo(this.gameObject);
    }

    public void HideTooltip() {
        toolTip.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        isActive = true;
        toolTip.GetComponent<ToolTipInfo>().isActive = true;
    }

    public void OnPointerExit(PointerEventData eventData) {
        isActive = false;
        toolTip.GetComponent<ToolTipInfo>().isActive = false;
    }
}
