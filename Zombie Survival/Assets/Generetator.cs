using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generetator : MonoBehaviour
{
    Heroe hero;
    public string Clor;
    // Start is called before the first frame update
    void Start()
    {
        hero = new Heroe(new GameObject());
        string[] nombres = new string[] { "Carlos", "Sebastian", "Eduardo", "Daniel", "Cata",
                                      "Danilo" , "Felipe" , "Tatiana" , "Juan" ,"Ronald" ,
                                      "Geremias" , "Rene" , "Eugenia" , "Eulari" , "Gala" ,
                                      "Gurtza" , "Gudula" , "Hebe" , "Fara", "Fedora"};
        int Zrnd;
        Zrnd = Random.Range(4,9);
        for(int i = 0; i < Zrnd;i++)
        {
            int Crnd = Random.Range(1, 4);
            if(Crnd == 1)
            {
                Clor = "Cyan";
            }
            if(Crnd == 2)
            {
                Clor = "Magenta";
            }
            if(Crnd == 3)
            {
                Clor = "Verde";
            }

            new Zombie(Clor);

        }
        int Alde = 9 - Zrnd;
        for(int i = 0; i < Alde; i++)
        {
            int nrnd = Random.Range(0, 20);
            int ernd = Random.Range(15, 101);
            new Aldeano(nombres[nrnd], ernd);
        }
    }

    // Update is called once per frame
    void Update()
    {
        hero.Movimiento();
    } 
}

/// <summary>
/// Se genera gran parte las estancias del lo jugable
/// </summary>
public class Heroe
{
    Transform movHero;
  
    /// <summary>
    /// la creacion de su heroe y la adiccion de los componentes
    /// </summary>
    /// <param name="heroe">
    /// Se le procede una creacion de objeto
    /// </param>
    public Heroe(GameObject heroe)
    {
        heroe = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        movHero = heroe.transform;
        heroe.AddComponent<Camera>();
    }
    /// <summary>
    /// Se le pone la velocidad en la quiere ir el jugador, se procede con el mismo movimiento
    /// y la rotacion
    /// </summary>
    public void Movimiento()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movHero.Translate(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movHero.Translate(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movHero.Rotate(0, -3, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movHero.Rotate(0, -3, 0);
        }
    }
}

/// <summary>
/// Se da Toda la funcion de los zombies
/// </summary>
public class Zombie
{
    /// <summary>
    /// Toma toda 
    /// </summary>
    /// <param name="color">
    /// Se le da un string con los nombres "Cyan, Magenta o Verde", Para darle su color y ademas se crean todas las estancias
    /// </param>
    public Zombie(string color)
    {

        GameObject zesfera = GameObject.CreatePrimitive(PrimitiveType.Cube);
        zesfera.name = "Zombie";
        Renderer zrendere = zesfera.GetComponent<Renderer>();
        float Rx = Random.Range(-10, 10);
        float Ry = Random.Range(-10, 10);
        zesfera.transform.position = new Vector3(Rx, 0, Ry);
        if(color == "Cyan")
        {
            zrendere.material.color = Color.cyan;
        }
        if(color == "Magenta")
        {
            zrendere.material.color = Color.magenta;
        }
        if (color == "Verde")
        {
            zrendere.material.color = Color.green;
        }
        Debug.Log(Imprimir("Soy un Zombie de color " + color));

    }
    string Imprimir(string V)
    {
        return V;
    }

}

/// <summary>
/// Se toma todo lo de los aldeanos
/// </summary>
public class Aldeano
{
    /// <summary>
    /// Es la estancia de todos los aldeano
    /// </summary>
    /// <param name="nombre">
    /// Se da un nombre dentro de un array
    /// </param>
    /// <param name="edad">
    /// Se da un nombre dentro de un entero
    /// </param>
    public Aldeano(string nombre , int edad)
    {
        GameObject acube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        acube.name = nombre;
        float Rx = Random.Range(-10, 10);
        float Ry = Random.Range(-10, 10);
        acube.transform.position = new Vector3(Rx, 0, Ry);
        Debug.Log(Imprimir("Hola Soy " + nombre + " y tengo " + edad + " años"));
    }
    string Imprimir(string V)
    {
        return V;
    }
}

