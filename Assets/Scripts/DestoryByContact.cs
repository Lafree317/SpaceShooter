using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContact : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
    public int score;
    private GameController gameController;

    private void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController>();
		} else {
			Debug.Log("Cannot find 'GameController' script");
		}
    }

    private void OnTriggerEnter(Collider other){
        

        if (other.tag == "Boundary"){
            return;
        }

        if(other.tag == "Asteroid"){
            return;
        }

        if (other.tag == "Enemy"){
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player"){
            Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
            gameController.GameOver();
        }else{
            gameController.addScore(score);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);

    }

}
