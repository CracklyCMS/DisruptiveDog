using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DynamicLineRenderer2D : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector2> points = new List<Vector2>(); // Store points in 2D space

    // Public array of transforms to add points from
    public Transform[] pointTransforms;

    // Index to keep track of which point in the array to add next
    private int currentPointIndex = 0;

    void Start()
    {
        // Get the LineRenderer component
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = pointTransforms.Length;
    }

    // Public method to add the next point from the array of transforms
    public void AddNextPointFromTransforms()
    {
        // Check if we still have points to add
        if (currentPointIndex < pointTransforms.Length)
        {
            // Get the position of the next point
            Vector3 newPoint = pointTransforms[currentPointIndex].position;

            // Add this point to the LineRenderer
            AddPoint(newPoint);

            // Move to the next point in the array for the next call
            currentPointIndex++;
        }
        else
        {
            Debug.Log("All points have been added.");
        }
    }

    // Add a single point to the LineRenderer from a Vector3 (only x and y are used)
    private void AddPoint(Vector3 newPoint)
    {
        // Convert the 3D position to 2D by using only x and y coordinates
        Vector2 point2D = new Vector2(newPoint.x, newPoint.y);
        points.Add(point2D);

        // Update the LineRenderer with the new point list
        lineRenderer.positionCount = points.Count;

        // Convert points back to Vector3 because LineRenderer uses Vector3 internally
        Vector3[] positions = new Vector3[points.Count];
        for (int i = 0; i < points.Count; i++)
        {
            positions[i] = new Vector3(points[i].x, points[i].y, -.25f); // Z-axis is 0 for 2D
        }
        lineRenderer.SetPositions(positions);
    }

    // Method to continuously update the LineRenderer points to follow the transforms
    private void UpdateLineRendererPositions()
    {
        // Create an array to store updated positions
        Vector3[] positions = new Vector3[pointTransforms.Length];

        // Loop through each transform and update the corresponding position
        for (int i = 0; i < pointTransforms.Length; i++)
        {
            Vector3 position = pointTransforms[i].position;
            positions[i] = new Vector3(position.x, position.y, -.25f); // Ensure the z position is 0 for 2D
        }

        // Update the LineRenderer with the new positions
        lineRenderer.SetPositions(positions);
    }

    // Example to add points manually via mouse click in 2D space (optional for testing)
    void Update()
    {
        UpdateLineRendererPositions();
        if (Input.GetMouseButtonDown(0)) // Left-click to add a point
        {
            AddNextPointFromTransforms();
        }
    }
}