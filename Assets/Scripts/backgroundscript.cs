﻿using UnityEngine;
using System.Collections;

public class backgroundscript : MonoBehaviour {

	public Transform[] Backgrounds;
	public float ParallaxScale;
	public float ParallaxReductionFactor;
	public float Smoothing;

	private Vector3 _lastPosition;


	// Use this for initialization
	public void Start () {
		_lastPosition = transform.position;
	}
	
	// Update is called once per frame
	public void Update () {
				var parallax = (_lastPosition.x - transform.position.x) * ParallaxScale;

				for (var i = 0; i < Backgrounds.Length; i++) {
						var backgroundTargetPosition = Backgrounds [1].position.x + parallax * (i * ParallaxReductionFactor + 1);
						Backgrounds [i].position = Vector3.Lerp (
				Backgrounds [i].position,
				new Vector3 (backgroundTargetPosition, Backgrounds [i].position.y, Backgrounds [i].position.z),
				Smoothing * Time.deltaTime);

				}
		}
}
