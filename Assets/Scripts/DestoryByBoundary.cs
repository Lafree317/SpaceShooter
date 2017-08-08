using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByBoundary : MonoBehaviour {
    // 移动出范围销毁对象
    private void OnTriggerExit(Collider other){
        Destroy(other.gameObject);
    }
}
