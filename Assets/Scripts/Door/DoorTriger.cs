using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorTriger : MonoBehaviour
{
	public Canvas messageDoor;
	
	public Text Open;

	
	private Animator animator;
	
	public GameObject DoorPivot;

	
	void Start()
	{
		HandleMessage(false);
		animator = (Animator)DoorPivot.GetComponent<Animator>();
	}


	/**
	 * Metoda wywo³ywana w momencie wejœcia gracza w obszar obiektu.
	 */
	void OnTriggerEnter(Collider other)
	{
		Debug.Log("Player Enter");
		if (other.tag == "Player")
		{
			HandleMessage(true); 
			Door d = (Door)DoorPivot.GetComponent<Door>();
			SetState(d.OpenYes());
		}
	}

	
	void OnTriggerStay(Collider other)
	{
		Debug.Log("Player Stay");
		Door d = (Door)DoorPivot.GetComponent<Door>();

		
		if (messageDoor.enabled == true && Input.GetKeyDown(KeyCode.E))
		{
			Debug.Log("E");

			if (!d.OpenYes())
			{
				animator.SetTrigger("Open");
				d.OpenYes(true);
			}
			else
			{
				animator.SetTrigger("Close");
				d.OpenYes(false);
			}
			SetState(d.OpenYes()); 
		}

	}

	
	void OnTriggerExit(Collider other)
	{
		Debug.Log("Player Exit");
		if (other.tag == "Player")
		{
			
			HandleMessage(false);
		}
	}

	
	private void HandleMessage(bool val)
	{
		messageDoor.enabled = val;

	}

	
	private void SetState(bool val)
	{
		if (Open != null)
		{
			if (!val)
			{
				Open.text = "Press E to open ";
			}
			else
			{
				Open.text = "Press E to close";
			}
		}
	}

}