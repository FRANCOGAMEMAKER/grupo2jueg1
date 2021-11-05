using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ApagarFuego : MonoBehaviour
{
    public Tilemap destructableTilemap;
    public GameObject fi;
    void Start()
    {


        destructableTilemap = GetComponent<Tilemap>();
        destructableTilemap.CompressBounds();

        foreach(var position in destructableTilemap.cellBounds.allPositionsWithin)
            {
                if(destructableTilemap.HasTile(position)){
                Instantiate(fi,position,new Quaternion(0,0,0,0));
                }
            }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("water"))
        {
            
        }
    }
}
