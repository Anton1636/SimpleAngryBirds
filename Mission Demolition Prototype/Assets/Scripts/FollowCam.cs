using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject PDI;
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    [Header("Set Dynamically")]
    public float camZ;

    private void Awake()
    {
        camZ = this.transform.position.z;
    }

    private void FixedUpdate()
    {
        //if(PDI == null)
        //{
        //    return;
        //}

        //Vector3 destination = PDI.transform.position;

        Vector3 destination;

        if(PDI == null)
            {
            destination = Vector3.zero;
        }
        else
        {
            destination = PDI.transform.position;
            if(PDI.tag == "Projectile")
            {
                if(PDI.GetComponent<Rigidbody>().IsSleeping())
                {
                    PDI = null;
                    return;
                }
            }
        }

        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camZ;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
}
