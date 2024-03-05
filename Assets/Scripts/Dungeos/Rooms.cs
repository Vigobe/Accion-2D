using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public enum TipoRoom
{
    RoomLibre,
    RoomEntrada,
    RoomEnemigo,
    RoomBoss
}
public class Rooms : MonoBehaviour
{
    [Header("COnfig")]
    [SerializeField] private bool mostrarDebug;
    [SerializeField] private TipoRoom tipoRoom;

    [Header("Grid")]
    [SerializeField] private Tilemap tileMapExtra;

    [Header("Puertas")]
    [SerializeField] private Transform[] posPuertasNS;
    [SerializeField] private Transform[] posPuertasOE;


    private Dictionary<Vector3,bool> listaDeTiles = new Dictionary<Vector3,bool>();
    private List<Puertas> listaDePuertas= new List<Puertas>();


    private void Start()
    {
        ObtenerTiles();
        GenerarPuertas();
        GenerarRoomSegunPlantilla();    
    }

    private void ObtenerTiles()
    {
        if (EsRoomNormal())
        {
            return;
        }

        foreach (Vector3Int tilePos in tileMapExtra.cellBounds.allPositionsWithin)
        {
            Vector3Int posLocal = new Vector3Int(tilePos.x, tilePos.y, tilePos.z);
            Vector3 posicion = tileMapExtra.CellToWorld(posLocal);
            Vector3 posicionModificada = new Vector3(posicion.x + 0.5f, posicion.y + 0.5f, posicion.z);

            if (tileMapExtra.HasTile(posLocal))
            {
                listaDeTiles.Add(posicionModificada, true);
            }

        }
    }

    private void GenerarRoomSegunPlantilla()
    {
        if(EsRoomNormal())
        {
            return;
        }
        // Crear plantilla al azar
        int indexRandom = Random.Range(0, LevelManager.Instance.RoomPlantillas.Plantillas.Length); 
        Texture2D textura = LevelManager.Instance.RoomPlantillas.Plantillas[indexRandom];
        List<Vector3> posiciones = new List<Vector3>(listaDeTiles.Keys);
        //Recorrido de los Tiles
        for(int y=0, i= 0; y < textura.height; y++)
        {
            for ( int x = 0; x < textura.width; x++, i++)
            {
                Color colorPixel = textura.GetPixel(x, y);
                foreach (RoomProps prop in LevelManager.Instance.RoomPlantillas.Prop)
                {
                    if (colorPixel == prop.PropColor)
                    {
                        GameObject propCreado = Instantiate(prop.PropPrefab, tileMapExtra.transform);
                        propCreado.transform.position = new Vector3(posiciones[i].x, posiciones[i].y, 0);
                        if (listaDeTiles.ContainsKey(posiciones[i]))
                        {
                            listaDeTiles[posiciones[i]] = false;
                        }
                    }
                }
            }
        }
    }

    private void RegistrarPuerta(GameObject puertaPrefab, Transform objTransform)
    {
        GameObject PuertaGO = Instantiate(puertaPrefab, objTransform.position, Quaternion.identity, objTransform);
        Puertas puerta = PuertaGO.GetComponent<Puertas>();
        listaDePuertas.Add(puerta);
    }

    private void GenerarPuertas()
    {
        if (posPuertasNS.Length > 0)
        {
            for (int i = 0;i < posPuertasNS.Length;i++)
            {
                RegistrarPuerta(LevelManager.Instance.LibreriaDungeon.PuertaNS, posPuertasNS[i]);   
            }
        }

        if (posPuertasOE.Length > 0)
        {
            for (int i = 0; i < posPuertasOE.Length; i++)
            {
                RegistrarPuerta(LevelManager.Instance.LibreriaDungeon.PuertaEO, posPuertasOE[i]);
            }
        }
    }
    private bool EsRoomNormal()
    {
        return tipoRoom == TipoRoom.RoomEntrada || tipoRoom == TipoRoom.RoomLibre;
    }

    private void OnDrawGizmosSelected()
    {
        if(mostrarDebug== false)
        {
            return;
        }
        if (listaDeTiles.Count > 0)
        {
            foreach (KeyValuePair<Vector3,bool> valor in listaDeTiles)
            {
                if (valor.Value)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawWireCube(valor.Key, Vector3.one * 0.8f );
                }
                else
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(valor.Key, 0.3f);
                }
            }
        }
    }
}
