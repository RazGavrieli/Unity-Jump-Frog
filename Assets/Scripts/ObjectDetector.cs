using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class ObjectDetector : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Car" && enabled) {
            Destroy(other.gameObject);
            //Debug.Log("a car was desctructed");

        }
        else if (other.tag == "Player" && enabled) {
            //SceneManager.LoadScene("Win");
            Destroy(other.gameObject);
            Debug.Log("player finished level");

        } 
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
        
    }
}