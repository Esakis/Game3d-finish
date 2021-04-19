using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : MonoBehaviour
{
    public static EnemyInstance instancja;
    /** Nazwa taga obiektu w miejscu którego pojawi siê gracz na nowej scenie.*/
    //public static string startNr;

    ///** Zmienna dostarcza informacji o tym czy gracz wczyta³ stan gry z pliku.*/
    public static bool respown = false;
    public static string startNr;
    /**
	 * Metoda 'Awake' jest wywo³ywana tylko raz (tak jak Start) tu¿ po zaczytaniu skryptu, 
	 * ale zanim zostanie wywo³ana metoda 'Start'.
	 * Wykorzystywana do inicjalizacji zmiennych lub stanu gry.
	 */
    void Awake()
    {
        //Je¿eli instancja jeszcze nie zosta³a zachowana.
        if (!instancja)
        {
            //Zachowaj instancjê obiektu podczas wczytywania sceny.
            //DontDestroyOnLoad(this.gameObject);
            
            //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Skeleton"));
            DontDestroyOnLoad(transform.root);

            //Instancja obiektu zosta³a zachowana i podstawiamy j¹ pod zmienna statyczn¹
            instancja = this;
        }
        else
        {

            /** 
             * Instancja równa siê true, czyli ju¿ jest gdzieœ w œwiecie obiekt
             * a zatem usuñ instancjê tego obiektu.
             * 
             * Ta sytuacja mo¿e mieæ miejsce, kiedy wrócimy do naszej g³ównej/startowej lokacji
             * gdzie znajduje siê ju¿ taki obiekt.
             */
            Destroy(gameObject);
        }

    }


}
