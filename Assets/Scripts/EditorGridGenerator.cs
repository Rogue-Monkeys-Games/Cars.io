using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorGridGenerator : EditorWindow
{
    public GameObject HexCell;
    public GameObject GridParent;
    private int grid_X_Size;
    private int grid_Z_Size;
   

    [MenuItem("Grid/Cell Placement tool")]
    public static void ShowWindow()
    {
        GetWindow<EditorGridGenerator>("Cell Placement tool");
    }

    private void OnGUI()
    {
        SerializedObject obj = new SerializedObject(this);
        EditorGUILayout.PropertyField(obj.FindProperty("HexCell"));
        EditorGUILayout.PropertyField(obj.FindProperty("GridParent"));
        grid_X_Size = EditorGUILayout.IntField("Grid Size in X:", grid_X_Size);
        grid_Z_Size = EditorGUILayout.IntField("Grid Size in Z:", grid_Z_Size);
        if (HexCell == null)
        {
            EditorGUILayout.HelpBox("please assign cell gameobject PREFAB", MessageType.Warning);
        }
        else
        {
            EditorGUILayout.BeginVertical("box");
            CreateButton();
            EditorGUILayout.EndVertical();
        }

        obj.ApplyModifiedProperties();
    }
    private void CreateButton()
    {
        if (GUILayout.Button("PlaceCells"))
        {
            PlaceCell();
        }
    }

    private void PlaceCell()
    {
        for (int i = 0; i < grid_X_Size; i++)
        {
            for (int j = 0; j < grid_Z_Size; j++)
            {//for x
             //[cell size(1) - dist to place cell attach to each other(0.84)(also the width of cell hex)]=0.16(distance thats removed from 1 cell size to make it close to other cells)
             //for y   
             //[cell size(1) - dist to place cell attach to each other(0.75)(also the height of cell hex)]=0.25(distance thats removed from 1 cell size to make it close to other cells)
                float offfset = 0;
                if (j % 2 == 0)
                {
                    offfset = 0.418f;
                }
                GameObject cellInstance = Instantiate(HexCell, new Vector3(offfset + i - (i * 0.16f), 0, j - (j * 0.25f)), Quaternion.identity);
                cellInstance.transform.SetParent(GridParent.transform);

            }
        }
    }


}
