using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] FloorCore floor;
    [SerializeField] bool recoverButton;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(recoverButton)
        {
            floor.Recover();
        }
        else
        {
            floor.NextFloorRisk();
        }
    }
}