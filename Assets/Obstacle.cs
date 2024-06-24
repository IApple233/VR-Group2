using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
	public Vector3 startPoint;
	public Vector3 endPoint;
	public float velocity;
	public Text msg;
	private Vector3 direction;
	private float state;
	private float effector = 1f;
	
    // Start is called before the first frame update
    void Start()
    {
        if (startPoint == null)
		{
			startPoint = transform.position;
		} else 
		{
			transform.position = startPoint;
		}
        if (endPoint == null)
		{
			endPoint = transform.position;
		}
		if (velocity == null || velocity > 1 || velocity < 0)
		{
			velocity = 0.02f;
		}
		direction = endPoint - startPoint;
		state = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		state += velocity * effector;
        if (state >= 1 || state <= 0) 
		{
			effector *= -1;
		}
		transform.Translate(direction * velocity * effector);
			
    }
	
	private void OnCollisionEnter(Collision col)
	{
		if (col.transform.name == "XR Origin")
		{
			msg.text = "Failed!";
		}
	}
}
