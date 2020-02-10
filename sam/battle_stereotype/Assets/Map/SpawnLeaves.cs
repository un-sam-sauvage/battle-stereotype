using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLeaves : MonoBehaviour
{
    private Vector2 _zoneSpawn;
    
    public GameObject[] feuilles;
    
    private float _posX;
    private float _posY;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 0, 2);
    }

    void Spawn()
    {
        _posX =Random.Range(-3.5f, 3.5f);
        _posY = Random.Range(5, 6);
        index = Random.Range(0, feuilles.Length);
        _zoneSpawn = new Vector2(_posX,_posY);
        Instantiate(feuilles[index], _zoneSpawn, Quaternion.identity);
        
    }
}
