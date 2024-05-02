//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Smarc
{
    [Serializable]
    public class SMTaskMsg : Message
    {
        public const string k_RosMessageName = "smarc_msgs/SMTask";
        public override string RosMessageName => k_RosMessageName;

        //  This holds the id of the task
        public ulong task_id;
        //  Termination condition WP: X. Set to zero if not used
        public double x;
        //  Termination condition WP: Y. Set to zero if not used
        public double y;
        //  Termination condition WP: depth. Set to zero if not used
        public double depth;
        //  Termination condition WP: altitude. Set to zero if not used
        public double altitude;
        //  Termination condition WP: Yaw. Set to zero if not used
        public double theta;
        //  Termination condition: maximum duration of the task. Set to zero if not used
        public BuiltinInterfaces.DurationMsg max_duration;
        //  Action server topic
        public string action_topic;
        //  Additional arguments to the action server call
        public string action_arguments;

        public SMTaskMsg()
        {
            this.task_id = 0;
            this.x = 0.0;
            this.y = 0.0;
            this.depth = 0.0;
            this.altitude = 0.0;
            this.theta = 0.0;
            this.max_duration = new BuiltinInterfaces.DurationMsg();
            this.action_topic = "";
            this.action_arguments = "";
        }

        public SMTaskMsg(ulong task_id, double x, double y, double depth, double altitude, double theta, BuiltinInterfaces.DurationMsg max_duration, string action_topic, string action_arguments)
        {
            this.task_id = task_id;
            this.x = x;
            this.y = y;
            this.depth = depth;
            this.altitude = altitude;
            this.theta = theta;
            this.max_duration = max_duration;
            this.action_topic = action_topic;
            this.action_arguments = action_arguments;
        }

        public static SMTaskMsg Deserialize(MessageDeserializer deserializer) => new SMTaskMsg(deserializer);

        private SMTaskMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.task_id);
            deserializer.Read(out this.x);
            deserializer.Read(out this.y);
            deserializer.Read(out this.depth);
            deserializer.Read(out this.altitude);
            deserializer.Read(out this.theta);
            this.max_duration = BuiltinInterfaces.DurationMsg.Deserialize(deserializer);
            deserializer.Read(out this.action_topic);
            deserializer.Read(out this.action_arguments);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.task_id);
            serializer.Write(this.x);
            serializer.Write(this.y);
            serializer.Write(this.depth);
            serializer.Write(this.altitude);
            serializer.Write(this.theta);
            serializer.Write(this.max_duration);
            serializer.Write(this.action_topic);
            serializer.Write(this.action_arguments);
        }

        public override string ToString()
        {
            return "SMTaskMsg: " +
            "\ntask_id: " + task_id.ToString() +
            "\nx: " + x.ToString() +
            "\ny: " + y.ToString() +
            "\ndepth: " + depth.ToString() +
            "\naltitude: " + altitude.ToString() +
            "\ntheta: " + theta.ToString() +
            "\nmax_duration: " + max_duration.ToString() +
            "\naction_topic: " + action_topic.ToString() +
            "\naction_arguments: " + action_arguments.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}