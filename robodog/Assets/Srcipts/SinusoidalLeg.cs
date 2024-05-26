using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HingeJoint))]
public class SinusoidalLeg : MonoBehaviour
{  
    [SerializeField] private float amplitude;
    [SerializeField] private float frequency;
    [SerializeField] private float phaseShift;
    private HingeJoint joint;
    private JointSpring hingeSpring;
    private float time;
    private float angle;

    void Start()
    {
        joint = GetComponent<HingeJoint>();
        hingeSpring = joint.spring;
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;
        angle = Mathf.Sin(time * frequency + phaseShift) * amplitude;
        if (joint.angle >= joint.limits.max || joint.angle <= joint.limits.min)
        {
            amplitude = -amplitude;
        }
        hingeSpring.targetPosition = angle;
        joint.spring = hingeSpring;
    }
}
