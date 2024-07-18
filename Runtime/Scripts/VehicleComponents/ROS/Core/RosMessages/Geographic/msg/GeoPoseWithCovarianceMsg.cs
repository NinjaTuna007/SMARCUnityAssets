//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Geographic
{
    [Serializable]
    public class GeoPoseWithCovarianceMsg : Message
    {
        public const string k_RosMessageName = "geographic_msgs/GeoPoseWithCovariance";
        public override string RosMessageName => k_RosMessageName;

        //  Geographic pose, using the WGS 84 reference ellipsoid.
        // 
        //  Orientation uses the East-North-Up (ENU) frame of reference.
        //  (But, what about singularities at the poles?)
        public GeoPoseMsg pose;
        //  Row-major representation of the 6x6 covariance matrix
        //  The orientation parameters use a fixed-axis representation.
        //  In order, the parameters are:
        //  (Lat, Lon, Alt, rotation about E (East) axis, rotation about N (North) axis, rotation about U (Up) axis)
        public double[] covariance;

        public GeoPoseWithCovarianceMsg()
        {
            this.pose = new GeoPoseMsg();
            this.covariance = new double[36];
        }

        public GeoPoseWithCovarianceMsg(GeoPoseMsg pose, double[] covariance)
        {
            this.pose = pose;
            this.covariance = covariance;
        }

        public static GeoPoseWithCovarianceMsg Deserialize(MessageDeserializer deserializer) => new GeoPoseWithCovarianceMsg(deserializer);

        private GeoPoseWithCovarianceMsg(MessageDeserializer deserializer)
        {
            this.pose = GeoPoseMsg.Deserialize(deserializer);
            deserializer.Read(out this.covariance, sizeof(double), 36);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.pose);
            serializer.Write(this.covariance);
        }

        public override string ToString()
        {
            return "GeoPoseWithCovarianceMsg: " +
            "\npose: " + pose.ToString() +
            "\ncovariance: " + System.String.Join(", ", covariance.ToList());
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