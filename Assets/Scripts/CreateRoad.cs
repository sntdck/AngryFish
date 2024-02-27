using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    public GameObject roadPrefab;
    public List<GameObject> obstaclePrefabs;
    public List<GameObject> wallPrefabs;

    public GameObject wallPrefabNew;

    public Transform player;
    public float generationDistance = 80f;
    public float destroyDistance = 20f;
    public float roadWidth = 2f;

    // public float distanceBetweenPvsO = 50f;
    public int numberWalls = 3;
    public int numberObstacles = 7;

    public float minDistance = 3f;
    public float maxDistance = 8f;

    private List<GameObject> roadSegments = new List<GameObject>();
    private List<GameObject> obstacles = new List<GameObject>();
    private List<GameObject> walls = new List<GameObject>();
    private List<GameObject> wallsNew = new List<GameObject>();

    void Update()
    {
        if (player.position.z > transform.position.z - generationDistance)
        {
            GenerateRoad();
            GenerateObstacles();
            GenerateWalls();
            GenerateWallsNew();
        }

        DestroyOldRoadSegments();
        DestroyOldObstacles();
        DestroyOldWalls();
        DestroyOldWallsNew();
    }

    void GenerateRoad()
    {
        GameObject road = Instantiate(roadPrefab, transform.position, Quaternion.identity);
        roadSegments.Add(road);
        road.transform.localScale = new Vector3(roadWidth, 1f, 1f);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + road.GetComponentInChildren<MeshRenderer>().bounds.size.z);
    }

    void GenerateObstacles()
    {
        float roadLength = roadPrefab.GetComponentInChildren<MeshRenderer>().bounds.size.z;

        for (int i = 0; i < numberObstacles; i++)
        {
            float spawnX = Random.Range(-20f, 3.5f);
            float spawnZ = transform.position.z + roadLength;
            float spawnRotationY = Random.Range(0f, 360f);

            int randomIndex = Random.Range(0, obstaclePrefabs.Count);
            GameObject obstaclePrefab = obstaclePrefabs[randomIndex];

            GameObject obstacle = Instantiate(obstaclePrefab, new Vector3(spawnX, 0.1f, spawnZ), Quaternion.Euler(0f, spawnRotationY, 0f));
            obstacles.Add(obstacle);
        }
    }

    void GenerateWalls()
    {
        float roadLength = roadPrefab.GetComponentInChildren<MeshRenderer>().bounds.size.z;

        float initialLeftZPos = transform.position.z;
        float initialRightZPos = transform.position.z;

        for (int i = 0; i < numberWalls; i++)
        {
            float zPos = initialLeftZPos + i;
            int randomIndex = Random.Range(0, wallPrefabs.Count);
            GameObject leftWallPrefab = wallPrefabs[randomIndex];
            float spawnRotationY = Random.Range(0f, 360f);

            GameObject leftWall = Instantiate(leftWallPrefab, new Vector3(-21f, 0.23f, zPos + roadLength), Quaternion.Euler(0f, spawnRotationY, 0f));
            walls.Add(leftWall);
        }

        for (int i = 0; i < numberWalls; i++)
        {
            float zPos = initialRightZPos + i;
            int randomIndex = Random.Range(0, wallPrefabs.Count);
            GameObject rightWallPrefab = wallPrefabs[randomIndex];
            float spawnRotationY = Random.Range(0f, 360f);

            GameObject rightWall = Instantiate(rightWallPrefab, new Vector3(4.4f, 0.23f, zPos + roadLength), Quaternion.Euler(0f, spawnRotationY, 0f));
            walls.Add(rightWall);
        }
    }


    void DestroyOldRoadSegments()
    {
        for (int i = 0; i < roadSegments.Count; i++)
        {
            if (player.position.z - roadSegments[i].transform.position.z > destroyDistance)
            {
                Destroy(roadSegments[i]);
                roadSegments.RemoveAt(i);
                i--;
            }
        }
    }

    void DestroyOldObstacles()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (player.position.z - obstacles[i].transform.position.z > destroyDistance)
            {
                Destroy(obstacles[i]);
                obstacles.RemoveAt(i);
                i--;
            }
        }
    }

    void DestroyOldWalls()
    {
        for (int i = 0; i < walls.Count; i++)
        {
            if (player.position.z - walls[i].transform.position.z > destroyDistance)
            {
                Destroy(walls[i]);
                walls.RemoveAt(i);
                i--;
            }
        }
    }
    void GenerateWallsNew()
    {
        float roadLength = roadPrefab.GetComponentInChildren<MeshRenderer>().bounds.size.z;

        float initialLeftZPos = transform.position.z;
        float initialRightZPos = transform.position.z;

        for (int i = 0; i < 1; i++)
        {
            float zPos = initialLeftZPos + i;
            GameObject leftWall = Instantiate(wallPrefabNew, new Vector3(-18.53f, 0.95f, zPos + roadLength), wallPrefabNew.transform.rotation);
            wallsNew.Add(leftWall);
        }

        for (int i = 0; i < 1; i++)
        {
            float zPos = initialRightZPos + i;
            GameObject rightWall = Instantiate(wallPrefabNew, new Vector3(1.8f, 0.95f, zPos + roadLength), Quaternion.Euler(0f, -180f, 0f));
            wallsNew.Add(rightWall);
        }
    }

    void DestroyOldWallsNew()
    {
        for (int i = 0; i < wallsNew.Count; i++)
        {
            if (player.position.z - wallsNew[i].transform.position.z > destroyDistance)
            {
                Destroy(wallsNew[i]);
                wallsNew.RemoveAt(i);
                i--;
            }
        }
    }
}
