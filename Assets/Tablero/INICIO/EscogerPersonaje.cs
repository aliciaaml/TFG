using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EscogerPersonaje : MonoBehaviour
{
    public static int contador = 1;
    public static bool juegoComenzar = false;

    public GameObject confirm;

    public TextMeshProUGUI jugador;
    public TextMeshProUGUI jugador2;

   
    public GameObject[] characters;
    public GameObject[] characters_deselection;

    List<GameObject> charactersList;

    public static int selectedCharacter = 0;

    public static List<int> character_choosed = new List<int>(new int[4]);

    void Update(){

        Replay.replay = false;
        if(characters[selectedCharacter] == characters_deselection[selectedCharacter]){

            confirm.SetActive(false);
        }
        else{
            confirm.SetActive(true);
        }

    }

    public void Back(){

        SceneManager.LoadScene("ChooseAmountPlayers");
    }

    public void NextCharacter(){

        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }
    
    public void PreviousCharacter(){

        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if(selectedCharacter<0){
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);

    }

    public void Confirm(){

        if(EscogerJugador.one_player && character_choosed.Count>0){

            character_choosed[selectedCharacter] = contador;                    //Esta lista pone en la posicion del personaje el numero del jugador, por ejemplo si el jugador 1 coge el cactus en la posicion 4  pone un 1.
            SceneManager.LoadScene("Terreno");
            juegoComenzar = true;               //Este bool se utiliza para quitar el canvas de inicio de la escena del tablero
            
        }
        else{
            if(EscogerJugador.two_player && character_choosed.Count>0 ){

                if(contador<2){
                    character_choosed[selectedCharacter] = contador;
                    characters[selectedCharacter].SetActive(false);
                    charactersList = new List<GameObject>(characters);
                    charactersList.RemoveAt(selectedCharacter);
                    charactersList.Insert(selectedCharacter, characters_deselection[selectedCharacter]);
                    characters = charactersList.ToArray();
                    contador += 1;
                    jugador.text = "Player " + contador.ToString();
                    jugador2.text = "Player " + contador.ToString();
                    selectedCharacter = 0;
                    characters[selectedCharacter].SetActive(true);
                    
                }

                else if(contador ==2){

                    character_choosed[selectedCharacter] = contador;
                    SceneManager.LoadScene("Terreno");
                    juegoComenzar = true;
                }
            }        
        
            if(EscogerJugador.three_player && character_choosed.Count>0){

                if(contador<3){
                    character_choosed[selectedCharacter] = contador;
                    characters[selectedCharacter].SetActive(false);
                    charactersList = new List<GameObject>(characters);
                    charactersList.RemoveAt(selectedCharacter);
                    charactersList.Insert(selectedCharacter, characters_deselection[selectedCharacter]);
                    characters = charactersList.ToArray();
                    contador += 1;
                    jugador.text = "Player " + contador.ToString();
                    jugador2.text = "Player " + contador.ToString();
                    selectedCharacter = 0;
                    characters[selectedCharacter].SetActive(true);
                }

                else if(contador ==3){
                    character_choosed[selectedCharacter] = contador;
                    SceneManager.LoadScene("Terreno");
                    juegoComenzar = true;
                }
            }       
        }
    }
}
