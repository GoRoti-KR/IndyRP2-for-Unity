using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using JointStateMsg = RosMessageTypes.Sensor.JointStateMsg;

public class indyRP2Subscriber : MonoBehaviour
{
    public ArticulationBody joint_1;
    public ArticulationBody joint_2;
    public ArticulationBody joint_3;
    public ArticulationBody joint_4;
    public ArticulationBody joint_5;
    public ArticulationBody joint_6;
    public ArticulationBody joint_7;

    private ArticulationBody[] joint;
    private Dictionary<string, int> jointNameToIndex;
    private ROSConnection ros;

    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<JointStateMsg>("/joint_states", Callback);

        joint = new ArticulationBody[7];
        joint[0] = joint_1;
        joint[1] = joint_2;
        joint[2] = joint_3;
        joint[3] = joint_4;
        joint[4] = joint_5;
        joint[5] = joint_6;
        joint[6] = joint_7;

        // joint 이름을 인덱스와 매핑
        jointNameToIndex = new Dictionary<string, int>
        {
            { "joint0", 0 },
            { "joint1", 1 },
            { "joint2", 2 },
            { "joint3", 3 },
            { "joint4", 4 },
            { "joint5", 5 },
            { "joint6", 6 }
        };
    }

    void Callback(JointStateMsg msg)
    {
        for (int i = 0; i < msg.name.Length; i++)
        {
            // 이름에 해당하는 인덱스를 찾아 position 값을 적용
            if (jointNameToIndex.TryGetValue(msg.name[i], out int jointIndex))
            {
                ArticulationDrive aDrive = joint[jointIndex].xDrive;
                aDrive.target = Mathf.Rad2Deg * (float)msg.position[i];
                joint[jointIndex].xDrive = aDrive;
            }
        }
    }
}
