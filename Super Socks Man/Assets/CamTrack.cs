using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrack : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target.transform.position.x >= transform.position.x + 2)
        {
            //transform.position += new Vector3(target.transform.position.x - transform.position.x, 0, 0) * 3 * Time.deltaTime;

            transform.position = new Vector3(target.transform.position.x - 2, 0, -10);
        }
	}
}
