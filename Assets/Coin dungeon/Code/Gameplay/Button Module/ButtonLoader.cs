using UnityEngine;
using Zenject;

public class ButtonLoader:MonoBehaviour
{
    [Inject] ButtonAnimation buttonAnimation;
    public void ShowButtons()
    {
        buttonAnimation.DoShowAnim();
    }

    public void HideButtons()
    {
        buttonAnimation.DoHideAnim();
    }
}
