using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] FloorCore floor;
    [SerializeField] ButtonLoader buttonLoader;
    [SerializeField] bool recoverButton;
    public void OnPointerClick(PointerEventData eventData)
    {
        //playSound;

        buttonLoader.HideButtons();

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
