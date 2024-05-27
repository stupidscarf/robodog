using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class LowerLegFreeze : MonoBehaviour
{
    [SerializeField] private HingeJoint upperHinge;
    [SerializeField] private float freezeAngle;
    private HingeJoint lowerHinge;
    private JointSpring originalSpring;
    private JointSpring zeroSping;
    private float currentAngleUp;

    void Start()
    {
        lowerHinge = GetComponent<HingeJoint>();
        originalSpring = lowerHinge.spring;
        zeroSping.spring = 0;
    }

    void FixedUpdate()
    {
        currentAngleUp = upperHinge.angle;
        Debug.Log(currentAngleUp);
        Debug.Log(currentAngleUp >= freezeAngle);
        if (currentAngleUp >= freezeAngle)
        {
            lowerHinge.spring = zeroSping;
        }
        else
        {
            lowerHinge.spring = originalSpring;
        }
    }
}
