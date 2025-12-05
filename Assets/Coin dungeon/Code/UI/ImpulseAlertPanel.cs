using UnityEngine;

public class ImpulseAlertPanel : MonoBehaviour
{
    [SerializeField][Range(0.1f, 5f)] float impulseSpeed;
    [SerializeField][Range(0, 3)] int baseScale;
    private void Update()
    {
        var scaleValue = baseScale + Mathf.PingPong(Time.time * impulseSpeed, 1f);

        transform.localScale = Vector3.one* scaleValue;
    }



}