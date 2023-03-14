using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour {

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool catIsAlive = true;
    public AudioSource source;
    public AudioClip clip;
    public ParticleSystem colisionPS;
    public ParticleSystem jumpPS;

    // Start is called before the first frame update
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && catIsAlive) {
            myRigidbody.velocity = Vector2.up * flapStrength;
            
            var em = jumpPS.emission;

            em.enabled = true;
            jumpPS.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (catIsAlive) {
            var em = colisionPS.emission;

            em.enabled = true;
            colisionPS.Play();

            logic.gameOver();
            source.PlayOneShot(clip);
        }
        catIsAlive = false;
    }
}
