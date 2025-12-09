using UnityEngine;

public class ButtonLoader:MonoBehaviour
{
    [SerializeField] ButtonAnimation buttonAnimation;
    public void ShowButtons()
    {
        buttonAnimation.DoShowAnim();
    }

    public void HideButtons()
    {
        buttonAnimation.DoHideAnim();
    }
}
