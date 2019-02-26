using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generetator : MonoBehaviour
{
    Heroe ero = new Heroe();
    Zombie zombie = new Zombie();
    Aldeano aldeano = new Aldeano();
    string[] nombres = new string[] { "Carlos", "Sebastian", "Eduardo", "Daniel", "Cata",
                                      "Danilo" , "Felipe" , "Tatiana" , "Juan" ,"Ronald" ,
                                      "Geremias" , "Rene" , "Eugenia" , "Eulari" , "Gala" ,
                                      "Gurtza" , "Gudula" , "Hebe" , "Fara", "Fedora"};
    public float veloc;
    public string Clor;
    // Start is called before the first frame update
    void Start()
    {
        ero.hero = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        ero.hero.AddComponent<Camera>();
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
            zombie.sombie(Clor);
        }
        int Alde = 9 - Zrnd;
        for(int i = 0; i < Alde; i++)
        {
            int nrnd = Random.Range(0, 20);
            int ernd = Random.Range(15, 101);
            aldeano.Aldea(nombres[nrnd], ernd);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ero.hero.transform.Translate(0, 0, ero.Movimiento(veloc));
        ero.hero.transform.Rotate(0,ero.Rota(veloc * 5),0,0);
    } 
}
/// <summary>
/// Se genera gran parte las estancias del lo jugable
/// </summary>
public class Heroe
{   
    public GameObject hero;
    /// <summary>
    /// Se le pone la velocidad en la quiere ir el jugador y se procede con el mismo movimiento
    /// </summary>
    /// <param name="vel">
    /// Se le pone una velocidad en float
    /// </param>
    /// <returns></returns>
    public float Movimiento(float vel)
    {
        float ind = 0;
        if (Input.GetKey(KeyCode.W))
        {
            ind +=vel;
        }
        if (Input.GetKey(KeyCode.S))
        {
            ind -= vel;
        }
        return ind;
    }
    /// <summary>
    /// Se utliza para rotar en "y", la camara del heroe
    /// </summary>
    /// <param name="vel"></param>
    /// <returns></returns>
    public float Rota(float vel)
    {
        float ind = 0;

        if (Input.GetKey(KeyCode.A))
        {
            ind += vel;
        }
        if (Input.GetKey(KeyCode.D))
        {
            ind -= vel;
        }
        return ind;
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
    public void sombie(string color)
    {
        GameObject Zesfera = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Renderer Zrendere = Zesfera.GetComponent<Renderer>();
        float Rx = Random.Range(-10, 10);
        float Ry = Random.Range(-10, 10);
        Zesfera.transform.position = new Vector3(Rx, 0, Ry);
        if(color == "Cyan")
        {
            Zrendere.material.color = Color.cyan;
        }
        if(color == "Magenta")
        {
            Zrendere.material.color = Color.magenta;
        }
        if (color == "Verde")
        {
            Zrendere.material.color = Color.green;
        }
        Debug.Log("Soy un Zombie de color " + color);

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
    /// <param name="Nombre">
    /// Se da un nombre dentro de un array
    /// </param>
    /// <param name="Edad">
    /// Se da un nombre dentro de un entero
    /// </param>
    public void Aldea(string Nombre , int Edad)
    {
        GameObject Acube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        float Rx = Random.Range(-10, 10);
        float Ry = Random.Range(-10, 10);
        Acube.transform.position = new Vector3(Rx, 0, Ry);
        Debug.Log("Hola Soy " + Nombre + " y tengo " + Edad + " años");
    }
}

