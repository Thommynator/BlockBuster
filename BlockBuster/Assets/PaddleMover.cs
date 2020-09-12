using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMover : MonoBehaviour
{
    private Camera cam;

    private Vector2 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, -cam.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 limitedPosition = LimitToScreenBounds(Input.mousePosition);
        Vector2 targetPosition = new Vector3(limitedPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.2f);
    }

    Vector2 LimitToScreenBounds(Vector2 position)
    {
        Vector2 limitedPosition = cam.ScreenToWorldPoint(new Vector3(position.x, position.y, -cam.transform.position.z));
        limitedPosition.x = Mathf.Clamp(limitedPosition.x, -screenBounds.x, screenBounds.x);
        limitedPosition.y = Mathf.Clamp(limitedPosition.y, -screenBounds.y, screenBounds.y);
        return limitedPosition;
    }
}
