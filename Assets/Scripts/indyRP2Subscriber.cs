using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using JointStateMsg = RosMessageTypes.Sensor.JointStateMsg;
using System.Threading;

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
    private ROSConnection ros;

    // Start is called before the first frame update
    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.Subscribe<JointStateMsg>("/joint_states", Callback);

        joint = new ArticulationBody[6];
        joint[0] = joint_1;
        joint[1] = joint_2;
        joint[2] = joint_3;
        joint[3] = joint_4;
        joint[4] = joint_5;
        joint[5] = joint_6;
        joint[6] = joint_7;
    }

    void Callback(JointStateMsg msg)
    {
        for (int i = 0; i < 6; i++)
        {
            ArticulationDrive aDrive = joint[i].xDrive;
            aDrive.target = Mathf.Rad2Deg * (float)msg.position[i];
            joint[i].xDrive = aDrive;
        }
    }
}