using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    private GameMaster gm;

    private void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        print("triggered");
        if (other.CompareTag("Player")) {
            print("triggered in if");
            gm.lastCheckPointPos = transform.position;
        }
    }
}
