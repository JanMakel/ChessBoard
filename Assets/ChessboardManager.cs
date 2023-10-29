using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessboardManager : MonoBehaviour
{

    public GameObject point;
    private float minValueX = -3;
    private float minValueY = 3f;
    private float spaceBetweenSquares = 1f;

    private float timer;
    private float spawnRate = 1f;

    public List<GameObject> board;
    //private List<Vector3> positionOcupied = new List<Vector3>();
    private List<Vector3> casillas = new List<Vector3>();

    /*
    int RandomSquareIndex()
    {
        return Random.Range(0, 8);
    }
    
    
    Vector3 RandomSpawnPosition()
    {

        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (-RandomSquareIndex() * spaceBetweenSquares);

        
        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, -1);
        
        return spawnPosition;

    }
    */

    /// <summary>
    /// Esta funcion génera una instancia cada x tiempo donde X es la variable spawnRate dentro de los limites indicados
    /// </summary>
    private void Instantiating()
    {
        
        timer += Time.deltaTime;
        
        if (timer >= spawnRate && casillas.Count != 0)
        {
            timer -= spawnRate;

            /*
            Vector3 spawnPos = RandomSpawnPosition();


            if (!positionOcupied.Contains(spawnPos))
            {
                Instantiate(point, RandomSpawnPosition(), Quaternion.identity);
                positionOcupied.Add(spawnPos);
            }
           */

            int tempIndx = RandomCasillas();
            Instantiate(point, casillas[tempIndx], Quaternion.identity);
            casillas.RemoveAt(tempIndx);
        }
        
    }

    private void Start()
    {
        //positionOcupied = new List<Vector3>();
        CreateBoard();
    }

    private void Update()
    {
            Instantiating();
    }
    /// <summary>
    /// Esta funcion Calcula una posicion aleatoria dentro de unos limites y con un espaciado de 1 para cada
    /// </summary>
    /// <param name="X"> Indice de la Fila</param>
    /// <param name="Y"> Indice de la Columna</param>
    /// <returns> Devuelve la posicion de la casilla que almacenaremos más adelante</returns>
    Vector3 CalculatePosition(int X, int Y)
    {

        float spawnPosX = minValueX + (X * spaceBetweenSquares);
        float spawnPosY = minValueY + (-Y * spaceBetweenSquares);


        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, -1);

        return spawnPosition;

    }
   /// <summary>
   /// Funcion que genera un número aleatorio dentro de la longitud del tablero que creamos más adelante, iremos encogiendo el numero final por eso usamos casillas.count
   /// </summary>
   /// <returns> Devuelve un número entre 1 y el número de casillas que quedan</returns>
    int RandomCasillas()
    {
        return Random.Range(0, casillas.Count);
    }


    /// <summary>
    /// Esta funcion crea el tablero de 8*8 casillas - Generando así 64 posiciones que se guardaran en el Vector Casillas - Calculate positon es el que me da la posición exacta de la casilla
    /// </summary>
    private void CreateBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                
                casillas.Add(CalculatePosition(i, j));
            }
        }
    }
}





    


