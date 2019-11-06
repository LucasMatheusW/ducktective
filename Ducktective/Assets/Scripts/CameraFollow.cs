using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private float xMax, xMin, yMax, yMin;
    [SerializeField]
    private Tilemap tileMap;
    private Vector3 minTile, maxTile;

    // Start is called before the first frame update
    void Start()
    {
        minTile = tileMap.CellToWorld(tileMap.cellBounds.min);
        maxTile = tileMap.CellToWorld(tileMap.cellBounds.max);
        limit(minTile, maxTile);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x,xMin,xMax), Mathf.Clamp(target.position.y,yMin,yMax), -10);
    }

    void limit(Vector3 minTile, Vector3 maxTile){
        Camera cam = Camera.main;
        float heigh = 2f * cam.orthographicSize;
        float width = heigh * cam.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;
        yMin = minTile.y + heigh / 2;
        yMax = maxTile.y - heigh / 2;
    }
}
