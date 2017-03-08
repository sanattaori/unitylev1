using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class BasicWepon : MonoBehaviour {


	public int maxClipSize = 5;
	private int ammoRemaining = 0;

	float maxRange = 100.0f;

	public bool playerControlled = true;
 
	public Text ammoRemainingLabel;

	public Transform shootPoint;

	public GameObject impactEffectPrefab;
	// Use this for initialization
	void Start () {
		ammoRemaining = maxClipSize;
		UpdateUI();
	}
	void UpdateUI(){
		if (ammoRemainingLabel != null){
			ammoRemainingLabel.text = ammoRemaining.ToString();
		}
	}

	void fire(){
		ammoRemaining -= 1;
		UpdateUI();

		RaycastHit hitInfo;

		var ray = new Ray(shootPoint.position,shootPoint.forward);
		bool hit = Physics.Raycast(ray,out hitInfo,maxRange);

		if (hit) {
			var impactEffect = Instantiate(impactEffectPrefab);
			impactEffect.transform.position = hitInfo.point;

			var direction = Vector3.Reflect(shootPoint.forward ,hitInfo.normal);
			impactEffect.transform.forward = direction;

			Destroy(impactEffect,4);

			var damage = hitInfo.collider.GetComponentInParent<Damage>();
			if (damage != null) {
			damage.TakeDamage();
		}
		}
	}
	void Reload(){
		ammoRemaining = maxClipSize;
	
	}
	// Update is called once per frame
	void Update () {
		if (playerControlled == false){
			return;
		}
		if(CrossPlatformInputManager.GetButtonDown("Fire")) {
			if(ammoRemaining > 0){
				fire();

			}
			else{
				Reload();
			}
		}
		
	}
}
