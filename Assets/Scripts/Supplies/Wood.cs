﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour, ICollectible, IStorable {

	public void Collect()
	{

		Tree t=this.gameObject.GetComponent<Tree> ();
		if (t != null) {
			t.Reset ();
		}
	}

	public void Store()
	{
<<<<<<< HEAD
		GameManager.Instance.player.Compartment = null;
		GameManager.Instance.Wood+=2;
=======
		GameManager.Instance.selectedPlayer.Compartment = null;
		GameManager.Instance.Wood+=3;
>>>>>>> 519a59c88d2c646938e1a788b9b63b212d6f3600
	}


}