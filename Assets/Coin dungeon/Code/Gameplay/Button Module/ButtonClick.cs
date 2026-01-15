using System.Drawing;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ButtonClick : MonoBehaviour, IPointerClickHandler
{

    [Inject] FloorCore floor;
    [Inject] ButtonLoader buttonLoader;
    [SerializeField] bool recoverButton;
    [Inject] AudioManager audioManager;
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
