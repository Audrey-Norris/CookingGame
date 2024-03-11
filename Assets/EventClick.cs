using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler {



    private void Start() {

    }

    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log(eventData);
    }

    public void OnPointerUp(PointerEventData eventData) {
        Debug.Log(eventData);

    }

    public void OnPointerClick(PointerEventData eventData) {
        Debug.Log(eventData);

    }

    public void OnPointerEnter(PointerEventData eventData) {
        Debug.Log(eventData);

    }

    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log(eventData);

    }
}
