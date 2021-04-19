using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : MonoBehaviour
{
    public static EnemyInstance instancja;
    /** Nazwa taga obiektu w miejscu kt�rego pojawi si� gracz na nowej scenie.*/
    //public static string startNr;

    ///** Zmienna dostarcza informacji o tym czy gracz wczyta� stan gry z pliku.*/
    public static bool respown = false;
    public static string startNr;
    /**
	 * Metoda 'Awake' jest wywo�ywana tylko raz (tak jak Start) tu� po zaczytaniu skryptu, 
	 * ale zanim zostanie wywo�ana metoda 'Start'.
	 * Wykorzystywana do inicjalizacji zmiennych lub stanu gry.
	 */
    void Awake()
    {
        //Je�eli instancja jeszcze nie zosta�a zachowana.
        if (!instancja)
        {
            //Zachowaj instancj� obiektu podczas wczytywania sceny.
            //DontDestroyOnLoad(this.gameObject);
            
            //DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Skeleton"));
            DontDestroyOnLoad(transform.root);

            //Instancja obiektu zosta�a zachowana i podstawiamy j� pod zmienna statyczn�
            instancja = this;
        }
        else
        {

            /** 
             * Instancja r�wna si� true, czyli ju� jest gdzie� w �wiecie obiekt
             * a zatem usu� instancj� tego obiektu.
             * 
             * Ta sytuacja mo�e mie� miejsce, kiedy wr�cimy do naszej g��wnej/startowej lokacji
             * gdzie znajduje si� ju� taki obiekt.
             */
            Destroy(gameObject);
        }

    }


}
