using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    // 以下属性需要在Unity里面赋值
    public float speed; // 飞船速度
    public float tilt; // 倾斜角度
    public Boundary boundary;// 移动范围


    // 子弹发射所需参数
    private float nextFire;
    public float fireRate;
    public GameObject shot;
    public Transform shotSqawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 子弹发射
        if(Input.GetButton("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot,shotSqawn.position,shotSqawn.rotation);
            GetComponent<AudioSource>().Play();
        }
	}

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 thisPosition = GetComponent<Rigidbody>().position;
        Vector3 thisVelocity = GetComponent<Rigidbody>().velocity;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // 飞船移动
        GetComponent<Rigidbody>().velocity = movement * speed;


        // 设置移动范围
        GetComponent<Rigidbody>().position = new Vector3(
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
        );

        // 添加倾斜
        GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f,thisVelocity.x * - tilt);


    }


}
