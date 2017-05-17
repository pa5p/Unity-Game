using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar : MonoBehaviour {

	public float velocidade;

	public float forcaPulo = 100f;
	public Rigidbody2D rb;
	private Animator animator;
	public Transform spritePlayer;

	public LayerMask Piso;
	public bool estaNoChao;	

	public Vector2 pontoColisaoPiso = Vector2.zero;
	public float raio;
	public Color debugCorColisao = Color.red;

/// Declaraçoes
/// //////////////////////////////////////////////////////////////////////////////////////////////////////
/// Start e Update

	// Use this for initialization
	void Start () {
		animator = spritePlayer.GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		
		//transform.rotation = Quaternion.Euler(lockPos , transform.rotation.eulerAngles.y , lockPos);
		Movimentacao();
		EstaNoChao ();
		ControlarEntrada ();
	}

/// Start e Update
/// ////////////////////////////////////////////////////////////////////////////////////////////////////
/// Movimentacao
	 
	void Movimentacao() {
		animator.SetFloat ("Movimento", Mathf.Abs (Input.GetAxisRaw ("Horizontal")));

		if (Input.GetAxisRaw ("Horizontal") > 0) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 0);
		}

		if (Input.GetAxisRaw ("Horizontal") < 0) {
			transform.Translate (Vector2.right * velocidade * Time.deltaTime);
			transform.eulerAngles = new Vector2 (0, 180);
		}	
		animator.SetBool ("chao", estaNoChao);

	}

/// Movimentacao
/// //////////////////////////////////////////////////////////////////////////////////////////////////////

	private void EstaNoChao()
	{
		var pontoPosicao = pontoColisaoPiso;
		pontoPosicao.x += transform.position.x;
		pontoPosicao.y += transform.position.y;
		estaNoChao = Physics2D.OverlapCircle(pontoPosicao, raio, Piso);
	}

	void Pular()
	{
		if(estaNoChao && rb.velocity.y <= 0)
		{
			rb.AddForce (new Vector2( 0, forcaPulo));	
		}
	}

	private void ControlarEntrada()
	{
		if (Input.GetButtonDown ("Jump")) 
		{
			Pular();
		}			
	}

		void OnDrawGizmos()
		{
			Gizmos.color = debugCorColisao;
			var pontoPosicao = pontoColisaoPiso;
			pontoPosicao.x += transform.position.x;
			pontoPosicao.y += transform.position.y;
			Gizmos.DrawWireSphere (pontoPosicao, raio);
		}
////////////////////////////////////////////////////
}
                          	 	 	 	