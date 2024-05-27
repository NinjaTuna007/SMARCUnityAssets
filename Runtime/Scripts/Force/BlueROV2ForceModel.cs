using System;
using DefaultNamespace.LookUpTable;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using UnityEngine;

namespace DefaultNamespace
{
    public class BlueROV2ForceModel : MonoBehaviour
    {
        public ArticulationBody mainBody;
        public ArticulationBody propeller_front_left_top;
        public ArticulationBody propeller_front_right_top;
        public ArticulationBody propeller_back_left_top;
        public ArticulationBody propeller_back_right_top;
        public ArticulationBody propeller_front_left_bottom;
        public ArticulationBody propeller_front_right_bottom;
        public ArticulationBody propeller_back_left_bottom;
        public ArticulationBody propeller_back_right_bottom;

        public void Start()
        {
            mainBody.inertiaTensor = Vector3.one; //Can set inertia hera
            // Do any "Once at startup" stuff here.
        }

        public void FixedUpdate()
        {
            var mainBodyVelocity = mainBody.velocity;
            var mainBodyAngularVelocity = mainBody.angularVelocity;
            var mainBodyMass = mainBody.mass;
            

            var inverseTransformDirection_local = transform.InverseTransformDirection(mainBody.velocity);
            var transformAngularVelocity_local = transform.InverseTransformDirection(mainBody.angularVelocity);
            
            //An additional transform. From Unity RUF to a more appropriate frame of reference.
            var velocity_CorrectCoordinateFrame = inverseTransformDirection_local.To<NED>().ToDense(); // Might need to revisit. Rel. velocity in point m block.
            var angularVelocity_CorrectCoordinateFrame = FRD.ConvertAngularVelocityFromRUF(transformAngularVelocity_local).ToDense();

            // Do calculations here
            
            // Resulting force and torque vectors

            var resultingForce = Vector3.zero;
            var resultingTorque = Vector3.zero;
            
            mainBody.AddRelativeForce(resultingForce);
            mainBody.AddRelativeTorque(resultingTorque);
            
            // Set RPMs for Visuals
            propeller_front_left_top.SetDriveTargetVelocity(ArticulationDriveAxis.X, 0); 
            propeller_front_right_top.SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            propeller_back_left_top.SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            propeller_back_right_top.SetDriveTargetVelocity(ArticulationDriveAxis.X, 0);
            
            propeller_front_left_bottom.SetDriveTargetVelocity(ArticulationDriveAxis.Z, 0); 
            propeller_front_right_bottom.SetDriveTargetVelocity(ArticulationDriveAxis.Z, 0);
            propeller_back_left_bottom.SetDriveTargetVelocity(ArticulationDriveAxis.Z, 0);
            propeller_back_right_bottom.SetDriveTargetVelocity(ArticulationDriveAxis.Z, 0);
        }
    }
}