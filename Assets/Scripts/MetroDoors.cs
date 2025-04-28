using System.Collections;
using UnityEngine;

public class MetroDoors : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public Transform leftWindow;
    public Transform rightWindow;
    public float doorSpeed = 2f;
    private Vector3 leftDoorClosedPosition;
    private Vector3 rightDoorClosedPosition;
    private Vector3 leftWindowClosedPosition;
    private Vector3 rightWindowClosedPosition;

    void Start()
    {
        // Save closed positions
        leftDoorClosedPosition = leftDoor.position;
        rightDoorClosedPosition = rightDoor.position;
        leftWindowClosedPosition = leftWindow.position;
        rightWindowClosedPosition = rightWindow.position;
    }

    public IEnumerator OpenDoorsAndWindows()
    {
        // Save the latest closed positions before opening
        leftDoorClosedPosition = leftDoor.position;
        rightDoorClosedPosition = rightDoor.position;
        leftWindowClosedPosition = leftWindow.position;
        rightWindowClosedPosition = rightWindow.position;

        // Define open positions
        Vector3 leftDoorOpenPosition = leftDoor.position + new Vector3(0.1f, 0, -1.0f);
        Vector3 rightDoorOpenPosition = rightDoor.position + new Vector3(0.1f, 0, 1.0f);
        Vector3 leftWindowOpenPosition = leftWindow.position + new Vector3(0.1f, 0, -1.0f);
        Vector3 rightWindowOpenPosition = rightWindow.position + new Vector3(0.1f, 0, 1.0f);

        // Move doors and windows to open position
        yield return MoveComponents(leftDoorOpenPosition, rightDoorOpenPosition, leftWindowOpenPosition, rightWindowOpenPosition);
    }

    public IEnumerator CloseDoorsAndWindows()
    {
        // Close to the most recent closed position
        yield return MoveComponents(leftDoorClosedPosition, rightDoorClosedPosition, leftWindowClosedPosition, rightWindowClosedPosition);
    }

    private IEnumerator MoveComponents(Vector3 leftDoorTarget, Vector3 rightDoorTarget, Vector3 leftWindowTarget, Vector3 rightWindowTarget)
    {
        float elapsedTime = 0f;
        Vector3 startLeftDoor = leftDoor.position;
        Vector3 startRightDoor = rightDoor.position;
        Vector3 startLeftWindow = leftWindow.position;
        Vector3 startRightWindow = rightWindow.position;

        while (elapsedTime < 1f)
        {
            leftDoor.position = Vector3.Lerp(startLeftDoor, leftDoorTarget, elapsedTime * doorSpeed);
            rightDoor.position = Vector3.Lerp(startRightDoor, rightDoorTarget, elapsedTime * doorSpeed);
            leftWindow.position = Vector3.Lerp(startLeftWindow, leftWindowTarget, elapsedTime * doorSpeed);
            rightWindow.position = Vector3.Lerp(startRightWindow, rightWindowTarget, elapsedTime * doorSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        leftDoor.position = leftDoorTarget;
        rightDoor.position = rightDoorTarget;
        leftWindow.position = leftWindowTarget;
        rightWindow.position = rightWindowTarget;
    }
}
