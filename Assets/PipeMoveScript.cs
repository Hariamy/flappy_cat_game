using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour {

    private float moveSpeed; //5
    private int actualScore;
    private float deadZone = -30;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        actualScore = logic.getScore();
        moveSpeed = 5 + actualScore/2;
    }

    // Update is called once per frame
    void Update() {
        var score = logic.getScore();

        if (actualScore < score &&  score < 100) {
            moveSpeed = 5 + score/2;
            actualScore = score;
        }

        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
    
        if (transform.position.x < deadZone) {
            
            Destroy(gameObject);
        }
    }
}
