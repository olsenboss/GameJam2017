﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CompleteProject;

public class Player : CharacterBase {

	private IStorable compartment;
	public Image Container;
	public Animator animator;
	private int hungerRate=1;


	public Transform itemHandle;

	void Start()
	{
		slider.gameObject.SetActive (false);
		StartCoroutine (HungerStrikes ());
		animator = GetComponent<Animator> ();
		//hungerRate = Random.Range (2, 4);
	}



	public IStorable Compartment
	{
		get{
			return compartment;

		}

		set {
			if (value is Wood) {
				Container.color = Color.green;
				compartment = value;
			} else if (value == null) {
				Container.color = new Color (255, 255, 255, 0);
				compartment = value;

			}
		}
	}

	IEnumerator HungerStrikes()
	{
		for(;;) {
			GetHungry (hungerRate);
			yield return new WaitForSeconds(1.0f);
			if (Hunger <= 0) {
				Die ();
				Hunger = 100;
			}
		}
	}

	new void Die()
	{
		Debug.Log ("Die");
		GameManager.Instance.GameOver ();
		return;
		ResetAnimations ();
		animator.SetTrigger ("Die");
		GameManager.Instance.SelectedPlayer = null;
		foreach (Player p in FindObjectsOfType<Player>()) {
			if (p != this) {
				GameManager.Instance.SelectedPlayer = p;
			}
		}
		if (GameManager.Instance.SelectedPlayer == null) {
			GameManager.Instance.GameOver ();
			Destroy (GetComponent<ClickToMove> ());
			Destroy (this);
		} else {
			Destroy (GetComponent<ClickToMove> ());
			Destroy (this);

		}
	}

	void ResetAnimations()
	{
		animator.SetBool("Walking", false);
		animator.SetBool("Idle", false);
		animator.SetBool("Chopping", false);
		animator.SetBool("Fishing", false);
		//anim.SetBool ("Carry", false);
	}
}
