using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    [SerializeField] private HingeJoint upHinge;
    [SerializeField] private HingeJoint downHinge;

    void Update()
    {
        changeAngle(upHinge, downHinge);
    }

    void changeAngle(HingeJoint upHinge, HingeJoint downHinge)
    {
        JointMotor motor = upHinge.motor;
        JointSpring spring = downHinge.spring;
        if (upHinge.angle <= upHinge.limits.min || upHinge.angle >= upHinge.limits.max)
        {
            motor.targetVelocity = -motor.targetVelocity;
            spring.targetPosition = -spring.targetPosition;
            upHinge.motor = motor;
            downHinge.spring = spring;
        }
    }
}
