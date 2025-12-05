using DG.Tweening;
using UnityEngine;

public class UIPanel:MonoBehaviour
{
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField][Range(0.1f, 10f)] float fadeDuration;

    public float FadeDuration
    {
        get { return fadeDuration; }
        private set { fadeDuration = value; }
    }
    public void FadeIn()
    {
        if(canvasGroup != null)
            canvasGroup.DOFade(1, fadeDuration);
    }

    public void FadeOut()
    {
        if(canvasGroup != null)
            canvasGroup.DOFade(0, fadeDuration);
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

