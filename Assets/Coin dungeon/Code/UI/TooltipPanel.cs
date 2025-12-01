using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipPanel : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler
{
    [SerializeField] Tooltip tooltip;
    [SerializeField] public string tooltipTitle;
    [SerializeField] public string tooltipDescription;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (tooltipTitle != null && tooltipDescription != null && tooltip != null)
        {
            tooltip.gameObject.SetActive(true);
            tooltip.SetText(tooltipTitle, tooltipDescription);
        }
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        var pos = Input.mousePosition;
        pos.z = 10;
        tooltip.SetPosition(Camera.main.ScreenToWorldPoint(pos));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if(tooltip != null)
            tooltip.gameObject.SetActive(false);
    }

    private void OnValidate()
    {
        if (tooltip != null) return;

        var finded = FindFirstObjectByType<Tooltip>();

        if (finded != null) tooltip = finded;
        else Debug.LogError($"No tooltip object for TooltipPanel! {gameObject.name}");

    }

}
