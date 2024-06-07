using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastShadow : MonoBehaviour
{
    public GameObject shadowPrefab;
    public GameObject Object;
    GameObject currentShadow;
    // Start is called before the first frame update
    void Start()
    {
        currentShadow = Instantiate(shadowPrefab, Object.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Object != null)
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out hit, Mathf.Infinity))
            {
                //Debug.DrawRay(transform.position, -Vector3.up * hit.distance, Color.yellow);
                currentShadow.transform.position = hit.point;
                currentShadow.transform.up = hit.normal;
            }
        }
    }
}
