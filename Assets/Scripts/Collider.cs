using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class Collider : MonoBehaviour {
    private Vector3 slowDownSpeed = new Vector3(0.15f, 0f, 0f);

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Car" && enabled) {
            if (this.GetComponent<Mover>().velocity[0] < -1 && other.transform.position.x < this.transform.position.x) // moving left and to the right of other car, also not moving too slow
            {
                this.GetComponent<Mover>().velocity = other.GetComponent<Mover>().velocity + slowDownSpeed;
            }
            else if (this.GetComponent<Mover>().velocity[0] > 1 && other.transform.position.x > this.transform.position.x) // moving right and to the left of other car, also not moving too slow
            {
                this.GetComponent<Mover>().velocity = other.GetComponent<Mover>().velocity - slowDownSpeed;
            }
        } else if (other.tag == "Player" && enabled) {
            //SceneManager.LoadScene("Lose");
            Destroy(other.gameObject);
            Debug.Log("player died");
            //other.gameObject.transform.position = new Vector3(-0.432281375f,-0.125747204f,-2.08516216f);
            
            


        } 
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
        
    }
}