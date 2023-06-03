using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public class Platform : MonoBehaviour
    {

    }

    [SerializeField] private float _spawnPlatformPosition;
    [SerializeField] private Transform _player;
    [SerializeField] private List<GameObject> _platformPrefabs;
 
    private List<Platform> _plaforms;
    private Vector3 _frontier = Vector3.one * -float.MaxValue;
 
    private void Start()
    {
        _plaforms = new List<Platform>();
        _plaforms.AddRange(FindObjectsOfType<Platform>());
        FindFrontier();
    }
 
    private void Update()
    {
        float distance = _frontier.z - _player.position.z;
        if(distance <= _spawnPlatformPosition)
        {
            InstantiatePlatform();
            FindFrontier();
        }
    }
 
    private void InstantiatePlatform()
    {
 
    }
 
    private void FindFrontier()
    {
        // ищем позицию последней платформы
        foreach(Platform platform in _plaforms)
        {
            if(platform.transform.position.z > _frontier.z)
            {
                _frontier = platform.transform.position;
            }
        }
    }
}
