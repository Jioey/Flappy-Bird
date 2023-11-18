using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeScript : MonoBehaviour
{

    public float moveSpeed;

    void Update() {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x < -1.3f) {
            Destroy(gameObject);
        }        
    }
}
