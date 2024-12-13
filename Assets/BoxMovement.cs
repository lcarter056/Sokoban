using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = transform.position; // Initially, set the target to the current position
    }

    // Update is called once per frame
    void Update()
    {
        // Move the box toward the target position smoothly
        transform.position = Vector3.MoveTowards(transform.position, target, 3f * Time.deltaTime); // Adjust speed as needed
    }

    // Call this method to set a new target position for the box
    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget; // Update the target position
    }
}
