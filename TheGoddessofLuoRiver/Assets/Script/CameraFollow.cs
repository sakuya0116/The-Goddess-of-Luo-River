using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform m_playerTransform;

    public float Ahead;

    public Vector3 targetPos;

    public float smooth;

    public float minmumX;
    public float maximumX;


    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(m_playerTransform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);

        if (transform.position.x < minmumX)
        {
            transform.position = new Vector3(minmumX, 0, -10);
        }

        if (transform.position.x > maximumX)
        {
            transform.position = new Vector3(maximumX, 0, -10);
        }
    }
}
