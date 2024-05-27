using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinusoidalLowerLeg : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private float phaseShift;
    [Space]
    [SerializeField] private HingeJoint upperHinge;
    [SerializeField] private float freezeAngle;
    [SerializeField] private float targetAngle;
    private HingeJoint joint;
    private JointSpring hingeSpring;
    private JointSpring targetSping;
    private float time;
    private float angle;
    private float currentAngleUp;

    void Start()
    {
        joint = GetComponent<HingeJoint>();
        hingeSpring = joint.spring;
        targetSping.targetPosition = targetAngle;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        SinusoidalMovement();
    }

    private void SinusoidalMovement()
    {
        angle = Mathf.Sin(time * frequency + phaseShift) * amplitude;
        if (joint.angle >= joint.limits.max || joint.angle <= joint.limits.min)
        {
            amplitude = -amplitude;
        }
        if(!Freeze())
        {
            hingeSpring.targetPosition = angle;
            joint.spring = hingeSpring;
        }
        
    }

    bool Freeze()
    {
        currentAngleUp = upperHinge.angle;
        /*Debug.Log(currentAngleUp);
        Debug.Log(currentAngleUp >= freezeAngle);*/
        if (currentAngleUp >= freezeAngle)
        {
            hingeSpring.targetPosition = targetAngle;
            joint.spring = hingeSpring;
            return true;
        }
        else
        {
            //joint.spring = hingeSpring;
            return false;
        }
    }
}
