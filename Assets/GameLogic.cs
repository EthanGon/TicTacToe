using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public bool xTurn;
    public bool gameOver = false;
    public bool xWon;
    public bool oWon;
    public int countSlotsTaken = 0;
    public Text[] symbolBox;
    public Text gameOverText;
    public Text displayPlayerTurn;
    public GameObject gameOverScreen;
    
    public void addSymbol() 
    {
        
        if (!gameOver)
        {
            if (xTurn)
            {
                DisplayCurrentTurn();
                countSlotsTaken++;
                EventSystem.current.currentSelectedGameObject.transform.Find("text").gameObject.GetComponent<Text>().text = "X";
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
                xTurn = false;
                
                checkSlots("X", 0, 1, 2);
                checkSlots("X", 3, 4, 5);
                checkSlots("X", 6, 7, 8);
                checkSlots("X", 0, 3, 6);
                checkSlots("X", 1, 4, 7);
                checkSlots("X", 2, 5, 8);
                checkSlots("X", 0, 4, 8);
                checkSlots("X", 2, 4, 6);
                

            }
            else
            {
                DisplayCurrentTurn();
                countSlotsTaken++;
                EventSystem.current.currentSelectedGameObject.transform.Find("text").gameObject.GetComponent<Text>().text = "O";
                EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
                xTurn = true;

                checkSlots("O", 0, 1, 2);
                checkSlots("O", 3, 4, 5);
                checkSlots("O", 6, 7, 8);
                checkSlots("O", 0, 3, 6);
                checkSlots("O", 1, 4, 7);
                checkSlots("O", 2, 5, 8);
                checkSlots("O", 0, 4, 8);
                checkSlots("O", 2, 4, 6);
                
            }
        }

    }

    public void DisplayCurrentTurn() 
    { 
        if (xTurn)
        {
            displayPlayerTurn.text = "O's TURN";
        } 
        else
        {
            displayPlayerTurn.text = "X's TURN";
        }
    }

    public void checkSlots(string symbol, int slot1, int slot2, int slot3) 
    {
        if (symbolBox[slot1].text.Equals(symbol) && symbolBox[slot2].text.Equals(symbol) && symbolBox[slot3].text.Equals(symbol)) 
        {
            DisplayGameOverScreen();
            gameOverText.text = symbol + " IS THE WINNER!!";
            if (symbol.Equals("X"))
            {
                xWon = true;
            }
            else if (symbol.Equals("O"))
            {
                oWon = true;
            }
        } 
        else if (countSlotsTaken == 9) 
        {
            if (!xWon && !oWon) 
            {
                DisplayGameOverScreen();
                gameOverText.text = "DRAW!";
            }
        }

    }

    public void RestartGame()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DisplayGameOverScreen() 
    {
        gameOver = true;
        gameOverScreen.SetActive(true);
    }

    public void ExitGame() 
    { 
        Application.Quit();
    }





}
