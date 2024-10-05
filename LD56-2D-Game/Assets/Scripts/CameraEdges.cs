using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdges : MonoBehaviour
{
    public float wallThickness = 1.0f; // Thickness of the invisible walls
    public bool isTrigger = false;
    public PhysicsMaterial2D material; // Set to true if you want the colliders to be triggers

    private Camera cam;
    private BoxCollider2D topWall, bottomWall, leftWall, rightWall;

    void Start()
    {
        cam = GetComponent<Camera>();

        // Create and position the invisible walls
        CreateWalls();
        PositionWalls();
    }

    void Update()
    {
        // Continuously update wall positions in case the camera moves or resizes
        PositionWalls();
    }

    void CreateWalls()
    {
        // Create BoxCollider2D objects for each wall
        topWall = new GameObject("TopWall").AddComponent<BoxCollider2D>();
        bottomWall = new GameObject("BottomWall").AddComponent<BoxCollider2D>();
        leftWall = new GameObject("LeftWall").AddComponent<BoxCollider2D>();
        rightWall = new GameObject("RightWall").AddComponent<BoxCollider2D>();

        // Set each wall as a child of the camera
        topWall.transform.parent = transform;
        bottomWall.transform.parent = transform;
        leftWall.transform.parent = transform;
        rightWall.transform.parent = transform;

        // Set the thickness of each wall (based on wallThickness) and mark as triggers if needed
        topWall.isTrigger = isTrigger;
        bottomWall.isTrigger = isTrigger;
        leftWall.isTrigger = isTrigger;
        rightWall.isTrigger = isTrigger;

        topWall.sharedMaterial = material;
        bottomWall.sharedMaterial = material;
        leftWall.sharedMaterial = material;
        rightWall.sharedMaterial = material;
    }

    void PositionWalls()
    {
        // Get the camera boundaries in world space
        Vector2 cameraSize = new Vector2(cam.aspect * cam.orthographicSize * 2, cam.orthographicSize * 2);
        float cameraLeft = cam.transform.position.x - cameraSize.x / 2;
        float cameraRight = cam.transform.position.x + cameraSize.x / 2;
        float cameraTop = cam.transform.position.y + cameraSize.y / 2;
        float cameraBottom = cam.transform.position.y - cameraSize.y / 2;

        // Set wall sizes and positions
        topWall.size = new Vector2(cameraSize.x + wallThickness * 2, wallThickness);
        topWall.offset = new Vector2(0, cameraTop + wallThickness / 2);

        bottomWall.size = new Vector2(cameraSize.x + wallThickness * 2, wallThickness);
        bottomWall.offset = new Vector2(0, cameraBottom - wallThickness / 2);

        leftWall.size = new Vector2(wallThickness, cameraSize.y + wallThickness * 2);
        leftWall.offset = new Vector2(cameraLeft - wallThickness / 2, 0);

        rightWall.size = new Vector2(wallThickness, cameraSize.y + wallThickness * 2);
        rightWall.offset = new Vector2(cameraRight + wallThickness / 2, 0);
    }
}
