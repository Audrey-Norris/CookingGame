using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
{
    [SerializeField] bool isDragged = false;
    [SerializeField] bool isTooltip = false;

    //NEED TO ADD A DROP FUNCTIONALITY
    public void OnPointerClick(PointerEventData eventData) {
        if(isDragged) {

        } else {
            this.transform.parent = this.transform.parent.transform.parent.transform.parent;
            isDragged = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(isDragged) {
            FollowMouse();
        }
    }

    private void FollowMouse() {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
    }

    //When Entering activate tooltip and when leaving deactivate tooltip
    public void OnPointerEnter(PointerEventData eventData) {
        if(!isTooltip) {
            
        }
    }
}
