using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class CarSpawner: MonoBehaviour {
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] string direction;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 3f;

    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minSpeed = 1f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxSpeed = 3f;

    void Start() {
         this.StartCoroutine(SpawnRoutine());    // co-routines
    }

    IEnumerator SpawnRoutine() {    // co-routines
        while (true) {
            float timeBetweenSpawnsInSeconds = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            yield return new WaitForSeconds(timeBetweenSpawnsInSeconds);       // co-routines

            Vector3 positionOfSpawnedObject = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);

            float speed = Random.Range(minSpeed, maxSpeed);
            if (direction == "right")
                newObject.GetComponent<Mover>().velocity = new Vector3(speed, 0f, 0f);
            else if (direction == "left")
                newObject.GetComponent<Mover>().velocity = new Vector3(-speed, 0f, 0f);

            newObject.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            //Debug.Log("car was constructed");

        }
    }
}
