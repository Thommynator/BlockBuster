using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{

    public AudioSource hitSound;

    private Rigidbody ballBody;

    // Start is called before the first frame update
    void Start()
    {
        ballBody = GameObject.Find("Ball").GetComponent<Rigidbody>();
        LeanTween.scale(this.gameObject, transform.localScale * 0.95f, Random.Range(0.1f, 0.5f)).setLoopPingPong();
        LeanTween.rotateZ(this.gameObject, Random.Range(-5, 5), Random.Range(0.4f, 0.8f)).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<BoxCollider>().enabled = false;

        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Ball")
        {
            hitSound.Play();
        }

        Vector3 offset = ballBody.velocity.normalized;
        offset.x = -offset.x;
        LeanTween.move(this.gameObject, transform.position - offset, 0.3f).setEaseOutElastic();
        LeanTween.alpha(this.gameObject, 0, 0.3f).setDestroyOnComplete(true);
    }
}
