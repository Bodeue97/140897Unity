using UnityEngine;

public class SquarePath : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 720f; // Adjust the rotation speed here
    private Rigidbody rb;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private Vector3[] waypoints;
    private int currentWaypoint = 0;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Set the initial position of the object at x=0 and z=0
        transform.position = new Vector3(0f, 0f, 0f);

        // Define the waypoints for the square path
        waypoints = new Vector3[] {
            new Vector3(10f, 0f, 0f),
            new Vector3(10f, 0f, 10f),
            new Vector3(0f, 0f, 10f),
            new Vector3(0f, 0f, 0f)
        };

        // Set the initial target position and rotation
        targetPosition = waypoints[0];
        targetRotation = Quaternion.LookRotation(waypoints[1] - waypoints[0]);
        isMoving = true;
    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            // Move towards the current target position
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            rb.MovePosition(newPosition);

            // Rotate towards the current target rotation
            Quaternion newRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            rb.MoveRotation(newRotation);

            // Check if the object reached the current waypoint/target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                // Move to the next waypoint in the array
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                targetPosition = waypoints[currentWaypoint];

                // Update the target rotation based on the next waypoint
                int nextWaypoint = (currentWaypoint + 1) % waypoints.Length;
                targetRotation = Quaternion.LookRotation(waypoints[nextWaypoint] - targetPosition);
            }
        }
    }
}
