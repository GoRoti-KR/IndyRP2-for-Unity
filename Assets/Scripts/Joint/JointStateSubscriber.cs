using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Sensor;  // ROS 메시지 타입 네임스페이스

public class JointStateSubscriber : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/indy_rp2/joint_states";  // ROS2 토픽 이름 설정
    public GameObject[] robotJoints;  // Unity에서 사용할 로봇 관절 오브젝트 배열

    void Start()
    {
        // ROS와의 연결 설정
        ros = ROSConnection.instance;
        ros.Subscribe<JointStateMsg>(topicName, UpdateJointStates);
    }

    void UpdateJointStates(JointStateMsg jointState)
    {
        // 수신한 메시지의 각 관절 위치를 Unity의 로봇 모델에 적용
        for (int i = 0; i < jointState.position.Length; i++)
        {
            float position = (float)jointState.position[i];
            robotJoints[i].transform.localRotation = Quaternion.Euler(0, position * Mathf.Rad2Deg, 0);
        }
    }
}
