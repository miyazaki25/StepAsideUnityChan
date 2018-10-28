using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //画面外に出たオブジェクトを破壊
    void OnBecameInvisible()
    {
      Destroy(this.gameObject);
    }

}
