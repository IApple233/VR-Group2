using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

#if ENABLE_VR || (UNITY_GAMECORE && INPUT_SYSTEM_1_4_OR_NEWER)
using UnityEngine.InputSystem.XR;
#endif

public class Hand : MonoBehaviour
{
	public GameObject robot;
	public string hand;
	private Animator _animator;
	
	[SerializeField]
	InputActionProperty m_InputActionProperty;
	
    // Start is called before the first frame update
    void Start()
    {
        InitalizeHand();
    }
	
	void InitalizeHand()
	{
		_animator     = robot.GetComponent<Animator>();
		// InputAction action = m_InputActionProperty.action;
		// action.performed += Callback;
	}

	void Callback(InputAction.CallbackContext obj)
	{
		var v = obj.ReadValue<float>();
		_animator.SetFloat(hand, v);
	}
	
    // Update is called once per frame
    void Update()
    {
		InputAction action = m_InputActionProperty.action;
		float v = action.ReadValue<float>();
		_animator.SetFloat(hand, v);
		// Debug.Log(v);
    }
}
