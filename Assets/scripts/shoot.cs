﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class shoot : MonoBehaviour {


	public Transform[] spawn_positions;

	public float fire_speed = 20;
    public float fire_interval = 1;
    public GameObject pool;
	private float fire_interval_time;

    void Start(){
        fire_interval_time = fire_interval;
    }

	void Update () {
		if(Input.GetButton("Fire1")){
			if(fire_interval_time <= 0){
                for(int i = 0; i < spawn_positions.Length; i++){
                    GameObject bullet = pool.GetComponent<object_pooler>().get_pooled_object();
                    if(bullet == null) return;

                    bullet.transform.position = spawn_positions[i].position;
                    bullet.transform.rotation = spawn_positions[i].rotation;
                    bullet.GetComponent<movement>().direction = spawn_positions[i].forward;
                    bullet.SetActive(true);
                }

				fire_interval_time = fire_interval;
			}
		}
		fire_interval_time = fire_interval_time - (Time.deltaTime * fire_speed);
	}
}
