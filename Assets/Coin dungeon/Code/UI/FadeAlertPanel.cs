using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

public class FadeAlertPanel:MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] [Range(0.1f,5f)] float fadeSpeed;

    private void Update()
    {
        canvasGroup.alpha = 1 * Mathf.Abs(Mathf.Sin(Time.time*fadeSpeed)); 
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
            Debug.Log($"FadeAlertPanel {gameObject.name} does not have a 'Canvas group' component. It will not use Fade methods.");
        }
    }

}
