using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
	private bool Open = false;
	void Start()
	{

	}

	public void OpenYes(bool Open)
	{
		this.Open = Open;
	}

	public bool OpenYes()
	{
		return Open;
	}
}