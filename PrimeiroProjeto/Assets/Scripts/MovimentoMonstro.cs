using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoMonstro : MonoBehaviour
{

	public float velocidade;
	public Transform chaoVerificador;
	public bool estaNoChao;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		Andar ();
	}

	void Andar ()
	{
		estaNoChao = Physics2D.Linecast (transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer ("Piso"));

		if (estaNoChao == true) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		}
	}
}
