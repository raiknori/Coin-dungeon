using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] FloorCore floor;
    [SerializeField] ButtonLoader buttonLoader;
    [SerializeField] bool recoverButton;
    [SerializeField] AudioManager audioManager;
    public void OnPointerClick(PointerEventData eventData)
    {

        audioManager.PlaySound("click");

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
