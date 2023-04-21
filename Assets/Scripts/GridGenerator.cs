using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject hex;

    // Start is called before the first frame update
    void Start()
    {
        placeGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void placeGrid()
    {
       
        for(int i = 0; i< 10;i++)
        {
            for(int j = 0; j<10;j++)
            {//for x
             //[cell size(1) - dist to place cell attach to each other(0.84)(also the width of cell hex)]=0.16(distance thats removed from 1 cell size to make it close to other cells)
             //for y   
             //[cell size(1) - dist to place cell attach to each other(0.75)(also the height of cell hex)]=0.25(distance thats removed from 1 cell size to make it close to other cells)
                float offfset =0;
             if (j%2==0)
                {
                      offfset = 0.418f;
                }
                Instantiate(hex, new Vector3(offfset + i-(i*0.16f), 0, j-(j*0.25f)), Quaternion.identity);

            }
        }
    }
}
