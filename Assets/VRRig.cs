using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
	public Transform vrTarget;
	public Transform rigTarget;
	public Vector3 positionOffset;
	public Vector3 rotationOffset;
	
	public void Map()
	{
		rigTarget.position = vrTarget.TransformPoint(positionOffset);
		rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(rotationOffset);
	}
}

public class VRRig : MonoBehaviour
{	
	public VRMap head;
	public VRMap leftHand;
	public VRMap rightHand;

	public Transform headConstraint;
	public Vector3 headBodyOffset;
    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = headConstraint.position + headBodyOffset;
		// robot-kyle's blue vs. neck's green
		transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;
		
		head.Map();
		leftHand.Map();
		rightHand.Map();
    }
}
