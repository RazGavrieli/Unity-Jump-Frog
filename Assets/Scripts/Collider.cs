using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component destroys its object whenever it triggers a 2D collider with the given tag.
 */
public class Collider : MonoBehaviour {
    private Vector3 slowDownSpeed = new Vector3(0.15f, 0f, 0f);

    [SerializeField] private AudioSource squish;


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
            //Destroy(other.gameObject);
            other.transform.position = new Vector3(0.408513784f,-3.9173196793f,-2.18516207f);
            squish.Play();
            Debug.Log("player died");
        } 
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
        
    }
}