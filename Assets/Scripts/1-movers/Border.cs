using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script sends the object with the given tag to the other side of the map by a given coordinate

public class Border : MonoBehaviour
{

    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;
    [SerializeField] float MoveTo;
    [SerializeField] bool AxisX = true;
    [SerializeField] bool AxisY = false;



    private Vector3 CurrentLocation;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == triggeringTag)
        {
            CurrentLocation = other.transform.position;
            CheckAndMove(other);
        }
    }

    private void CheckAndMove(Collider2D other)
    {
        if (AxisX) other.transform.position = new Vector3(MoveTo, CurrentLocation.y, CurrentLocation.z);
        if (AxisY) other.transform.position = new Vector3(CurrentLocation.x, MoveTo, CurrentLocation.z);

    }
}
