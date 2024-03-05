using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomPlantillas",menuName = "Dungeon/RoomPlantillas")]
public class RoomsPlantillas : ScriptableObject
{
    [Header("Plantillas")]
    public Texture2D[] Plantillas;

    [Header("Props")]
    public RoomProps[] Prop;
}

[Serializable]
public class RoomProps
{
    public string Nombre;
    public Color PropColor;
    public GameObject PropPrefab;
}
