using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RosMessageTypes.Moveit;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;

public class DisplayTrajectorySubscriber : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/display_planned_path";

    // LineRenderer to visualize the path
    private LineRenderer lineRenderer;

    void Start()
    {
        // Initialize ROS connection and LineRenderer component
        ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<DisplayTrajectoryMsg>(topicName, DisplayTrajectoryCallback);

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 0; // Initial count
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.blue;
    }

    void DisplayTrajectoryCallback(DisplayTrajectoryMsg msg)
    {
        if (msg.trajectory.Length == 0 || msg.trajectory[0].joint_trajectory.points.Length == 0)
        {
            Debug.LogWarning("No trajectory data received!");
            return;
        }

        // Extract positions from the trajectory message
        List<Vector3> positions = new List<Vector3>();

        foreach (var point in msg.trajectory[0].joint_trajectory.points)
        {
            float x = (float)point.positions[0]; // Example for the first joint position
            float y = (float)point.positions[1];
            float z = (float)point.positions[2];

            positions.Add(new Vector3(x, y, z));
        }

        // Update LineRenderer positions
        lineRenderer.positionCount = positions.Count;
        lineRenderer.SetPositions(positions.ToArray());
    }
}
