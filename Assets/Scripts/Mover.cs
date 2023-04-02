using UnityEngine;

/**
 * This component moves its object in a fixed velocity.
 * NOTE: velocity is defined as speed+direction.
 *       speed is a number; velocity is a vector.
 */
public class Mover: MonoBehaviour {
    [Tooltip("Movement vector in meters per second")]
    [SerializeField] public Vector3 velocity; // public since other cars need to match speed, spawner need to set it

    void Update() {
        transform.position += velocity * Time.deltaTime;
    }
}
