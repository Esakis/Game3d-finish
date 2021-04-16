using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour
{
    // Start is called before the first frame update

    public Button btnStart;
    public Button btnExit;
    public Button btnSave;
    public Button btnLoad;

    public Canvas hudMenu;
    private Canvas manuUI;

    void Start()
    {


        manuUI = (Canvas)GetComponent<Canvas>();
        btnStart = btnStart.GetComponent<Button>();//Ustawienie przycisku uruchomienia gry.
        btnExit = btnExit.GetComponent<Button>();//Ustawienie przycisku wyj�cia z gry.
        hudMenu = hudMenu.GetComponent<Canvas>();
        hudMenu.enabled = false;
        Cursor.visible = manuUI.enabled;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        { //Je�eli naci�ni�to klawisz "Escape"
            manuUI.enabled = !manuUI.enabled;//Ukrycie/pokazanie menu.
            hudMenu.enabled = !hudMenu.enabled;//Ukrycie/pokazanie interface.

            Cursor.visible = manuUI.enabled;//Ukrycie pokazanie kursora myszy.

            if (manuUI.enabled)
            {
                Cursor.lockState = CursorLockMode.Confined;//Odblokowanie kursora myszy.
                Cursor.visible = true;//Pokazanie kursora.
               
                btnStart.enabled = true; //Aktywacja przycsiku 'Start'.
                btnExit.enabled = true; //Aktywacja przycsiku 'Wyj�cie'.
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked; //Zablokowanie kursora myszy.
                Cursor.visible = false;//Ukrycie kursora.
             

            }

        }

    }

    public void ButtonExit()
    {
        Application.Quit(); //Powoduje wyj�cie z gry.
    }

    //Metoda wywo�ywana podczas udzielenia odpowiedzi przecz�cej na pytanie o wyj�cie z gry.


    //Metoda wywo�ywana przez przycisk uruchomienia gry 'Play Game'
    public void ButtonStart()
    {
        //Application.LoadLevel (0); //this will load our first level from our build settings. "1" is the second scene in our game	
        manuUI.enabled = false; //Ukrycie g��wnego menu.

        Time.timeScale = 1;//W�aczenie czasu.

        Cursor.visible = false;//Ukrycie kursora.
        Cursor.lockState = CursorLockMode.Locked; //Zablokowanie kursora myszy.

    }

    public void ButtonSave()
    {
       //tutaj wpisz odniesienie do skryptu z zapisywaniem gry
    }


    public void ButtonLoad()
    {
        //tutaj wpisz odniesienie do skryptu z �adowaniem gry
    }


}
