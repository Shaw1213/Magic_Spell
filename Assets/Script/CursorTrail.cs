using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class MouseFollower : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> points;
    public GameObject followerObject;
    private bool isDrawing = false;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
        points = new List<Vector3>();
    }

    void Update()
    {
        // Check if the mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            isDrawing = true;
            points.Clear(); // Clear the points list when starting a new line
            lineRenderer.positionCount = 0; // Reset the LineRenderer
        }

        // Check if the mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            isDrawing = false;
        }

        // If the mouse button is pressed, update the line
        if (isDrawing)
        {
            // Get the mouse position in screen coordinates
            Vector3 mousePosition = Input.mousePosition;

            // Convert the mouse position to world coordinates
            mousePosition.z = Mathf.Abs(Camera.main.transform.position.z);
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0;

            // Update the position of the follower object to follow the mouse
            if (followerObject != null)
            {
                followerObject.transform.position = mousePosition;
            }

            // Add the mouse position to the list of points if it has moved
            if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], mousePosition) > 0.1f)
            {
                points.Add(mousePosition);

                // Update the LineRenderer with the new set of points
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPositions(points.ToArray());
            }
        }
    }
}
