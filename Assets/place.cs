using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class place : MonoBehaviour
{
	private bool onTarget = false;
	private bool onOthers = false;
	private int onTargetCnt = 0;
	public Text msg;
	
	private void OnCollisionEnter(Collision col)
	{
		if (col.transform.name == "Target Cube")
		{
			onTarget = true;
		} else {
			onOthers = true;
		}
	}
	
	private void OnCollisionExit(Collision col)
	{
		if (col.transform.name == "Target Cube")
		{
			onTarget = false;
		} else {
			onOthers = false;
		}
	}
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame (device-dependent)
    void Update()
    {
        
    }
	
    // Update is called once per physic-frame (fixed interval)
	void FixedUpdate()
	{
		if (onTarget && !onOthers && transform.parent != null)
		{
			onTargetCnt += 1;
			if (onTargetCnt % 100 == 0)
			{
				Debug.Log(onTargetCnt);
			}
		} else {
			onTargetCnt = 0;
		}
		if (onTargetCnt > 400)
		{
			msg.text = "Success!";
		}
	}
}
