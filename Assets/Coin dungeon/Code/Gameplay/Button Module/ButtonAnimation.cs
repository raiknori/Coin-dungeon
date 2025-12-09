using DG.Tweening;
using UnityEngine;

public class ButtonAnimation:MonoBehaviour
{
    [SerializeField] GameObject button1; [SerializeField] GameObject button2;

    [SerializeField] Transform buttonShowTransform;
    [SerializeField] Transform buttonHideTransform;


    [SerializeField][Range(0.3f, 3f)] float moveDuration;
    public float MoveDuration
    {
        get { return moveDuration; }

        private set { moveDuration = value; }
    }

    public void DoShowAnim()
    {
        button1.transform.DOMoveX(buttonShowTransform.position.x, moveDuration);
        button2.transform.DOMoveX(buttonShowTransform.position.x, moveDuration);
    }


    public void DoHideAnim()
    {
        button1.transform.DOMoveX(buttonHideTransform.position.x, moveDuration*0.3f);
        button2.transform.DOMoveX(buttonHideTransform.position.x, moveDuration*0.3f);

        Vector3 posBut1 = button1.transform.position;
        Vector3 posBut2 = button2.transform.position;

        posBut1.x = buttonHideTransform.position.x;
        posBut2.x = buttonHideTransform.position.x;


        button1.transform.position = posBut1;
        button2.transform.position = posBut2;
    }
}