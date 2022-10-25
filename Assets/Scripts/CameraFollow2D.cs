using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public GameObject target;
    public float step;
    public float backAmount;
    private float lastRescale = 0;
    private bool needsRescale = false;
    private float targetRescale = 0;
    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        if(target.transform.localScale.x - lastRescale > step)
        {
            lastRescale +=step;
            targetRescale += backAmount;
            needsRescale = true;
        }
        if (needsRescale)
        {
            if(transform.position.z < -targetRescale)
            {
                needsRescale = false;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.back * backAmount, Time.deltaTime *2f);
            }
        }
    }
}
