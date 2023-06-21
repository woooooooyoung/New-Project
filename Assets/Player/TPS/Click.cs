using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] Color normal;
    [SerializeField] Color onMouse;

    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
            Debug.Log("Å¬¸¯");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        render.material.color = onMouse;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        render.material.color = normal;
    }
}
