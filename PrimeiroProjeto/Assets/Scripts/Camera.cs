using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

	public float velocidade;
	public Transform spritePlayer;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		Movimentacao();
	}

	void Movimentacao() {

		if (Input.GetAxisRaw("Horizontal") > 0 ) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}

		if (Input.GetAxisRaw("Horizontal") < 0 ) {
			transform.Translate (Vector2.left * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}	
	

	}
}