using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public Rigidbody2D playerR8;

    private Rigidbody2D floor;
    private float initiaFloorPositionY;

	// Use this for initialization
	public void Start ()
    {
        floor = GetComponent<Rigidbody2D>();
        initiaFloorPositionY = floor.position.y;
        floor.MovePosition(new Vector2(playerR8.position.x, initiaFloorPositionY));
	}
	
	// Update is called once per frame
	public void Update ()
    {
        Move();
	}
    private void Move()
    {
        floor.MovePosition(new Vector2(playerR8.position.x, initiaFloorPositionY));
    }
}
