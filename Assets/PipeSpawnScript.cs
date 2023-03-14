using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject pipe;
    private float spawnRate; // 3
    private float timer = 0;
    private float heightOffset = 8;
    public LogicScript logic;

    // Start is called before the first frame update
    void Start() {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnRate = 3 - Mathf.Log(logic.getScore()+1, 2)/3;
        spawnPipe();
    }

    // Update is called once per frame
    void Update() {

        if (timer < spawnRate) {
            timer = timer + Time.deltaTime;
            // Debug.Log(timer.ToString());
        } else {
            var score = logic.getScore();
            if (score < 100) {
                spawnRate = 3 - Mathf.Log(score+1, 2)/3;
            }
            spawnPipe();
            timer = 0;
        }
    }

    void spawnPipe() {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Instantiate(
            pipe, 
            new Vector3(transform.position.x+15, Random.Range(lowestPoint, highestPoint), 0), 
            transform.rotation);

    }
}
