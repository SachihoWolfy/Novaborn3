using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/* Usage:
 * Put a game object in the variable via the editor and It'll do it's thing.
 * This script will show you the velocity of a game object.
 */
public class VelocityDebug : MonoBehaviour
{
    public GameObject subject;
    Rigidbody subjectRB;
    Vector3 velocity;
    public TextMeshProUGUI velocityInfoText;
    // Start is called before the first frame update
    void Start()
    {
        // checking to see if the Object has a rigidbody so stuff don't break.
        if(subject.GetComponent<Rigidbody>() != null)
        {
            subjectRB = subject.GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("Don't try to fool the VelocityDebug hud with an object that doesn't have a Rigidbody. \nObject in question: " + subject.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (subjectRB != null)
        {
            velocity = subjectRB.velocity;
            velocityInfoText.text = "VelMagnitude: " + velocity.magnitude + "\nVx: " + velocity.x + "\nVy: " + velocity.y + "\nVz: " + velocity.z;
        }
    }
}
