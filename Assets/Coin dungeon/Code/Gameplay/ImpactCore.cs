using DG.Tweening;
using UnityEngine;

class ImpactCore
{
    public static void Shake()
    {
        Camera.main.transform.DOShakePosition(0.5f);
    }
    

}

