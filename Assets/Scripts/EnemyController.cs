using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public float maxZ;
    public float tilt;
    public Transform shotSqawn;
    public GameObject shot;
    private bool canMove = true;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
        StartCoroutine(SpawnWaves());
	}
	
	// Update is called once per frame
	void Update () {

        if (this.transform.position.z < maxZ && canMove == true) {
			// 停止前后移动
			GetComponent<Rigidbody>().velocity = transform.forward * 0;
            canMove = false;
		}

		
	}
    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(1);

		// 发射子弹
		Instantiate(shot, shotSqawn.position, shotSqawn.rotation);

        yield return new WaitForSeconds(1);


		// 飞船左右移动
		Vector3 movement;

        float i = Random.Range(0.0f, 10.0f);
        if (i > 5){
            movement = new Vector3(1.0f, 0.0f, 0.0f);
        }else{
            movement = new Vector3(-1.0f, 0.0f, 0.0f);
        }

		GetComponent<Rigidbody>().velocity = movement * speed;
        Vector3 thisVelocity = GetComponent<Rigidbody>().velocity;
		// 添加倾斜
		GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, thisVelocity.x * -tilt);
        yield return new WaitForSeconds(2);
       
    }
}
