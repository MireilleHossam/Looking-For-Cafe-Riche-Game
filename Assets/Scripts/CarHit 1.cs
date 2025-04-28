using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHit : MonoBehaviour
{
    public Animator animator2;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Hitted : " + hit.gameObject.name);
        if (hit.gameObject.tag == "Car")
        {
            Debug.Log("Hitted by car : " + hit.gameObject.name);

            transform.GetComponent<Animator>().enabled = false;
            animator2.enabled = false;

        }
    }
}
