using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallShake : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (!LeanTween.isTweening(this.gameObject))
        {
            LeanTween.scale(this.gameObject, transform.localScale * 0.9f, 0.2f)
                .setEaseInOutBounce()
                .setLoopPingPong(2);
        }
    }
}
