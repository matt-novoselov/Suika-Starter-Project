using UnityEngine;

public class ScreenBorderSetup : MonoBehaviour
{
    private float wallHeight = 1f;

    void Start()
    {
        SetUpBorders();
        Destroy(this);
    }

    void SetUpBorders()
    {
        Camera mainCamera = Camera.main;

        // Calculate screen boundaries in world coordinates
        Vector2 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // Bottom
        InstantiateWall(
            position: new Vector2((bottomLeft.x + topRight.x) / 2f, bottomLeft.y - wallHeight / 2),
            width: topRight.x - bottomLeft.x,
            height: wallHeight);

        // Top
        InstantiateWall(
            position: new Vector2((bottomLeft.x + topRight.x) / 2f, topRight.y + wallHeight / 2),
            width: topRight.x - bottomLeft.x,
            height: wallHeight);

        // Left
        InstantiateWall(
            position: new Vector2(bottomLeft.x - wallHeight / 2, (bottomLeft.y + topRight.y) / 2f),
            width: wallHeight,
            height: topRight.y - bottomLeft.y);

        // Right
        InstantiateWall(
            position: new Vector2(topRight.x + wallHeight / 2, (bottomLeft.y + topRight.y) / 2f),
            width: wallHeight,
            height: topRight.y - bottomLeft.y);
    }

    void InstantiateWall(Vector2 position, float width, float height)
    {
        GameObject wall = new GameObject("Wall");
        wall.transform.position = position;

        // Add BoxCollider2D component
        BoxCollider2D collider = wall.AddComponent<BoxCollider2D>();
        collider.size = new Vector2(width, height);

        // Add Rigidbody2D component if you want the walls to interact with physics
        // Rigidbody2D rigidbody = wall.AddComponent<Rigidbody2D>();
        // rigidbody.bodyType = RigidbodyType2D.Static;

        wall.transform.parent = transform;  // Set the empty GameObject as the parent
    }
}
