using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;  // ROS �޽��� Ÿ�� ���ӽ����̽�

public class JointStateSubscriber : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/indy_rp2/joint_states";  // ROS2 ���� �̸� ����
    public GameObject[] robotJoints;  // Unity���� ����� �κ� ���� ������Ʈ �迭

    void Start()
    {
        // ROS���� ���� ����
        ros = ROSConnection.instance;
        ros.Subscribe<JointStateMsg>(topicName, UpdateJointStates);
    }

    void UpdateJointStates(JointStateMsg jointState)
    {
        // ������ �޽����� �� ���� ��ġ�� Unity�� �κ� �𵨿� ����
        for (int i = 0; i < jointState.position.Length; i++)
        {
            float position = (float)jointState.position[i];
            robotJoints[i].transform.localRotation = Quaternion.Euler(0, position * Mathf.Rad2Deg, 0);
        }
    }
}
