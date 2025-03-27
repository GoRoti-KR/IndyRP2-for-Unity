# Neuromeka IndyRP2-for-Unity

[![License](https://img.shields.io/badge/license-Apache--2.0-green.svg)](LICENSE.md)
![ROS](https://img.shields.io/badge/ros2-humble-brightgreen)
![Unity](https://img.shields.io/badge/unity-2020.2+-brightgreen)
<br/>
<br/>
![IndyRP2 in Unity](https://github.com/user-attachments/assets/70268b65-3850-4238-981f-52c98a251c70)
<br/>

This project visualizes real-time trajectories of real-world IndyRP2 (WSL2-ubuntu22.04) in Unity (Windows 11)

> Indy RP2 Control Reference : https://github.com/neuromeka-robotics/indy-ros2 <br/>
> Unity Side Reference : https://github.com/Unity-Technologies/Unity-Robotics-Hub

---

## Introduction
Figuring out the robot's real-time location is thought to be the starting point for applying the digital twin in industrial environments. Although Gazbo is used a lot for robot control, we think it would be better to proceed in Unity considering its scalability, so we are going to make simulation SW in Unity for IndyRP2, a cooperative robot.

| SW | Ver |
|---|---|
| OS | Window 11 / WSL2(Ubuntu 22.04) |
| Unity version | Unity 22.3.28f1 |
| Robot | Neuromeka Indy RP2 |
<br/>

## Getting Started
### [Unity Side (Window 11)](https://github.com/GoRoti-KR/IndyRP2-for-Unity/blob/main/0_Unity%20Setting%20(Window%2011).md)
Used URDF Importer, ROS TCP Connector, ROS TCP Endpoint
<br/>

### [IndyRP2 Side (WSL2)](https://github.com/GoRoti-KR/IndyRP2-for-Unity/blob/main/1_IndyRP2%20Setting%20(WSL2-ROS2%20Humble))
Install Indy-ros2 Package [link](https://github.com/neuromeka-robotics/indy-ros2/blob/humble-indyDCP3/README.md)
<br/>
<br/>


## Documentation

| Tutorial | Description |
|---|---|
| [ROS–Unity Integration](tutorials/ros_unity_integration/README.md) | A set of component-level tutorials showing how to set up communication between ROS and Unity |
| [URDF Importer](tutorials/urdf_importer/urdf_tutorial.md) | Steps on using the Unity package for loading [URDF](http://wiki.ros.org/urdf) files |
| [Indy-Ros2](https://github.com/neuromeka-robotics/indy-ros2/blob/humble-indyDCP3/README.md) | Describes how to control real IndyRP2 with ROS2 Humble |
<br/>

## Component Repos(Unity Side)

| Repo | Functionality |
|---|---|
| [ROS TCP Endpoint](https://github.com/Unity-Technologies/ROS-TCP-Endpoint) | ROS node for sending/receiving messages from Unity |
| [ROS TCP Connector](https://github.com/Unity-Technologies/ROS-TCP-Connector) | Unity package for sending, receiving, and visualizing messages from ROS |
| [URDF Importer](https://github.com/Unity-Technologies/URDF-Importer) | Unity package for loading [URDF](http://wiki.ros.org/urdf) files |
<br/>

## Additional Resources

### Commit
- (October 7, 2024) Visualizes real-time trajectories of real-world IndyRP2 (WSL2-ubuntu22.04) in Unity (Windows 11) [Beta]
<br/>

### Plan
- (---- -, 2025) Control real Robot(Indy RP2) in Unity
- (---- -. 2025) Reinforcement learning by Unity MLAgent
