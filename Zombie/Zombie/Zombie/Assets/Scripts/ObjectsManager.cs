using UnityEngine;
using System.Collections.Generic;
public class ObjectsManager : MonoBehaviour
{
    public Rigidbody2D checker;
    public Transform playerTransform;
    public float offset;
    public float groundLength = 15;
    public int initialCountOfGrounds;
    public float backgroundLength = 63.8f;
    public int initialCountOfBG;
    public float minDistance = 15f;
    public float maxDistance = 73;
    public Transform lastSpawnedObject;
    public List<GameObject> objectsToBeSpawned;
    public Transform playerInteractablesParent;

    private Transform checkedGround;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 newPosition = checker.position;
        newPosition.x = playerTransform.position.x - offset;
        checker.position = newPosition;
    }
    public void OnTriggerEnter2D(Collider2D otherColider)
    {
        Transform checkedTransform = otherColider.GetComponent<Transform>();
        string tag = otherColider.tag;
        if (tag == "Background")
        {
            ChangePositionOfBackground(checkedTransform);
        }
        else if(tag == "Ground")
        {
            ChangePositionOfGround(checkedTransform);
        }
        else if(tag == "Enemies")
        {
            Destroy(otherColider.gameObject);
            int random = Random.Range(0, objectsToBeSpawned.Count);
            GameObject newObject = objectsToBeSpawned[random];
            Transform spawnedObject = Instantiate(newObject, playerInteractablesParent).GetComponent<Transform>();
            Vector2 newPosition = spawnedObject.position;
            newPosition.x = lastSpawnedObject.position.x + Random.Range(minDistance, maxDistance);
            spawnedObject.position = newPosition;
            lastSpawnedObject = spawnedObject;
        }
    }
    private void ChangePositionOfGround(Transform checkedGround)
    {
        Vector2 newPosition = checkedGround.position;
        newPosition.x += initialCountOfGrounds * groundLength;
        checkedGround.position = newPosition;
    }
    private void ChangePositionOfBackground(Transform checkedBackground)
    {
        Vector2 newPosition = checkedBackground.position;
        newPosition.x += initialCountOfBG * backgroundLength;
        checkedBackground.position = newPosition;
    }
}
