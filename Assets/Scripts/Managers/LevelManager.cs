using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Config")]
    [SerializeField] private RoomPlantillas roomPlantillas;
    [SerializeField] private LibreriaDungeon libreriaDungeon;
    public RoomPlantillas RoomPlantillas => roomPlantillas;
    public LibreriaDungeon LibreriaDungeon => libreriaDungeon;  



    private void Awake()
    {
        Instance = this;

    }
}
