using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour {

	public float velocidade;
	public bool estaNoChao;
	public float forcaPulo;
	public Rigidbody2D rb;
	public Transform chaoVerificador;
	private Animator animator;
	public Transform spritePlayer;

	// Use this for initialization
	void Start () {
		animator = spritePlayer.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		Movimentacao();
	}

	void Movimentacao() {
		animator.SetFloat("Movimento", Mathf.Abs (Input.GetAxisRaw ("Horizontal")));

		if (Input.GetAxisRaw("Horizontal") > 0 ) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 0);
		}

		if (Input.GetAxisRaw("Horizontal") < 0 ) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2(0, 180);
		}	

		estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
		animator.SetBool ("chao", estaNoChao);

		if ((Input.GetAxisRaw ("Vertical") > 0) && (estaNoChao == true)) {
			rb.AddForce (transform.up * forcaPulo);
		}

	}
}
                          	 	 	 	