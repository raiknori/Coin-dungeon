using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UIPanel:MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    public void FadeIn()
    {
        if(canvasGroup != null)
            canvasGroup.DOFade(0, 1f);
    }

    public void FadeOut()
    {
        if(canvasGroup != null)
            canvasGroup.DOFade(1f, 0);
    }

    private void OnValidate()
    {
        if (canvasGroup != null) return;

        var component = gameObject.GetComponent<CanvasGroup>();

        if (component != null)
        {
            canvasGroup = component;
        }
        else
        {
            Debug.Log($"UIPanel {gameObject.name} does not have a 'Canvas group' component. It will not use Fade methods.");
        }
    }

}

