using UnityEngine;
using System.Collections;
public class MetroMovement : MonoBehaviour
{
    public float stopZ;
    public float forwardDistance;
    public float speed = 5f;
    public float waitTime = 30f;

    private float startZ;
    private float finalZ;

    public MetroDoors trainDoors; // Reference to MetroDoors script

    void Start()
    {
        startZ = transform.position.z;
        finalZ = stopZ + forwardDistance;
        StartCoroutine(MovementLoop());
    }

    IEnumerator MovementLoop()
    {
        while (true)
        {
            while (Mathf.Abs(transform.position.z - stopZ) > 0.1f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, stopZ, speed * Time.deltaTime));
                yield return null;
            }
            if (trainDoors != null)
            {
                yield return StartCoroutine(trainDoors.OpenDoorsAndWindows()); // ✅ FIXED
            }
            yield return new WaitForSeconds(waitTime - 2f);
            if (trainDoors != null)
            {
                yield return StartCoroutine(trainDoors.CloseDoorsAndWindows()); // ✅ FIXED
            }

            while (Mathf.Abs(transform.position.z - finalZ) > 0.1f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.MoveTowards(transform.position.z, finalZ, speed * Time.deltaTime));
                yield return null;
            }

            transform.position = new Vector3(transform.position.x, transform.position.y, startZ);
        }
    }
}
