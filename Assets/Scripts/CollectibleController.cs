using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    [SerializeField]
    string collectibleType;

    [SerializeField]
    int value;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Character2DController controller = other.GetComponent<Character2DController>();
            if(controller != null)
            {
                /*CASO DE ESTUDIO: */
                /*1. LLEVAR EL CONTEO DE ESTRELLAS Y MOSTRAR EN PANTALLA: 30 PTS*/
                /*2. RECOLECTAR LA LLAVE: 15 PUNTOS */
                controller.IncreaseCollectible(collectibleType, value);

                
                /*3. ABRIR EL COFRE PARA GANAR EL NIVEL: 15 PTS */


                /*4. HACER UN SEGUNDO NIVEL UTILIZANDO TILEMAP: 30 PTS*/
                /*5. EL TIEMPO DE VIDEO JUEGO ES DE 3 MIN PARA AVANZAR EN EL NIVEL: 10 PTS*/
            }
            Destroy(gameObject);
        }
    }
}
