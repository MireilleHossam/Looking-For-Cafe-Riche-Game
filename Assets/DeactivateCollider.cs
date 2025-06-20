using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateCollider : MonoBehaviour
{
    [Header("Assign the object you want to hide")]
    public GameObject objectToHide;

    [Header("Tag of the player (default: Player)")]
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (objectToHide != null)
            {
                objectToHide.SetActive(false);
                Debug.Log(objectToHide.name + " has been hidden.");
            }
        }
    }

}
