using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {


	public int maxHealth = 3;

	int _currentHealth;
	int currentHealth {

		get{
			return _currentHealth;
		}
		 set {
		 	_currentHealth = value;

		 	if(_currentHealth <=0) {
		 		Die();
		 	}
		 }
	}

	public void Die(){
		Destroy(gameObject);

	}
	// Use this for initialization
	void Start () {
		currentHealth  = maxHealth ;
	}
	public void TakeDamage(int amount = 1){
		currentHealth -=amount;
	} 
	
	// Update is called once per frame
	void Update () {
		
	}
}
