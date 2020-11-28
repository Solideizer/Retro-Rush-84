using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPooling : MonoBehaviour
{
    #region Variable Declarations
#pragma warning disable 649
    [SerializeField] public int columnPoolSize = 10;
    [SerializeField] public float spawnRate = 2f;
    [SerializeField] private GameObject roadPrefab;
#pragma warning restore 649
    private GameObject[] _roads;
    private Vector3 _objectPoolPosition = new Vector3 (-15f, -25f, 0);
    private float _timeSinceLastSpawn;
    private float[] _spawnXpos = { 0f, 5f, -5f };
    private float _spawnYpos = 0f;
    private float _spawnZpos = 20f;
    private int _currentColumn = 0;
    #endregion 

    private void Start ()
    {
        _roads = new GameObject[columnPoolSize];

        for (int i = 0; i < columnPoolSize; i++)
        {
            _roads[i] = Instantiate (roadPrefab, _objectPoolPosition, Quaternion.identity) as GameObject;
        }
    }
    void Update ()
    {
        _timeSinceLastSpawn += Time.deltaTime;

        if (_timeSinceLastSpawn >= spawnRate)
        {
            _timeSinceLastSpawn = 0f;
            var spawnXindex = Random.Range (0, 3);

            _roads[_currentColumn].transform.position = new Vector3 (_spawnXpos[spawnXindex], _spawnYpos, _spawnZpos);
            _currentColumn++;
            _spawnZpos += 5f;

            if (_currentColumn >= columnPoolSize)
            {
                _currentColumn = 0;
            }
        }
    }
}