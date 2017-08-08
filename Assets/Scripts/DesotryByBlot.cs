using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesotryByBlot : MonoBehaviour {

	public GameObject ememyExplosion;
    public int score;
	private GameController gameController;
	// Use this for initialization
	void Start() {
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		} else {
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			Instantiate(ememyExplosion, other.transform.position, other.transform.rotation);
			Destroy(gameObject);
			Destroy(other.gameObject);
            gameController.addScore(score);
		}

	}
}
