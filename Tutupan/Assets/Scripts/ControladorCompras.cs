using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControladorCompras : MonoBehaviour
{
    //Variables para que de las gracias por comprar
    public Animator animator;
    private AudioSource audioSource;
    public AudioClip NotEnough;
    //VAriables publicas que informan de lo que tiene el usuario
    public Text tCunnas, tEspejos, tEspejosDobles, tPrismas, tPuntos;
    //Variables para poder comprar
    private int Puntos, PrecioBaseCunna = 400, PrecioBaseEspejo = 200, 
                PrecioBaseEspejoDoble = 350, PrecioBasePrisma = 500,
    //Estas son las disponibles para el jugador 
                CunnasCompradas, EspejosComprados, EspejosDoblesComprados, PrismasComprados, 
    //Estas son para calcular el precio en base a cuantas se hayan comprado ya
                CunnasCompradasTotales, EspejosCompradosTotales, EspejosDoblesCompradosTotales, PrismasCompradosTotales;
  
    void Start() {
        audioSource = GetComponent<AudioSource>();
        Puntos = PlayerPrefs.GetInt("Puntos");

        CunnasCompradas = PlayerPrefs.GetInt("CunnasCompradas");
        EspejosComprados = PlayerPrefs.GetInt("EspejosComprados");
        EspejosDoblesComprados = PlayerPrefs.GetInt("EspejosDoblesComprados");
        PrismasComprados = PlayerPrefs.GetInt("PrismasComprados");

        CunnasCompradasTotales = PlayerPrefs.GetInt("CunnasCompradasTotales");
        EspejosCompradosTotales = PlayerPrefs.GetInt("EspejosCompradosTotales");
        EspejosDoblesCompradosTotales = PlayerPrefs.GetInt("EspejosDoblesCompradosTotales");
        PrismasCompradosTotales = PlayerPrefs.GetInt("PrismasCompradosTotales");

        PrecioBaseCunna *= ((CunnasCompradasTotales + 2)/2);
        PrecioBaseEspejo *= ((EspejosCompradosTotales + 2)/2);
        PrecioBaseEspejoDoble *= ((EspejosDoblesCompradosTotales + 2)/2);
        PrecioBasePrisma *= ((PrismasCompradosTotales + 2)/2);
        tCunnas.text = "Price: " + PrecioBaseCunna + "\n Inventory: " + CunnasCompradas;
        tEspejos.text = "Price: " + PrecioBaseEspejo + "\n Inventory: " + EspejosComprados;
        tEspejosDobles.text = "Price: " + PrecioBaseEspejoDoble + "\n Inventory: " + EspejosDoblesComprados;
        tPrismas.text = "Price: " + PrecioBasePrisma + "\n Inventory: " + PrismasComprados;
        tPuntos.text = "Points: " + Puntos;
    }

    public void ComprarCunna() {
        if(PrecioBaseCunna <= Puntos) {
            CunnasCompradasTotales++;
            PlayerPrefs.SetInt("CunnasCompradasTotales", CunnasCompradasTotales);
            CunnasCompradas++;
            PlayerPrefs.SetInt("CunnasCompradas", CunnasCompradas);
            Puntos -= PrecioBaseCunna;
            PlayerPrefs.SetInt("Puntos", Puntos);
            PrecioBaseCunna *= ((CunnasCompradasTotales + 2)/2);
            tCunnas.text = "Price: " + PrecioBaseCunna + "\n Inventory: " + CunnasCompradas;
            tPuntos.text = "Puntos: " + Puntos;
            audioSource.Play(0);
            animator.Play("0000000014", 1, 0); //Thank you
            animator.PlayInFixedTime("Thankful",-1, 0.30f);
        }else {
            animator.Play("0000000015", 1, 0); //Not enought points audio
            audioSource.PlayOneShot(NotEnough);
        }
    }
    
    public void ComprarEspejo() {
        if (PrecioBaseEspejo <= Puntos) {
            EspejosCompradosTotales++;
            PlayerPrefs.SetInt("EspejosCompradosTotales", EspejosCompradosTotales);
            EspejosComprados++;
            PlayerPrefs.SetInt("EspejosComprados", EspejosComprados);
            Puntos -= PrecioBaseEspejo;
            PlayerPrefs.SetInt("Puntos", Puntos);
            PrecioBaseEspejo *= ((EspejosCompradosTotales + 2)/2);
            tEspejos.text = "Price: " + PrecioBaseEspejo + "\n Inventory: " + EspejosComprados;
            tPuntos.text = "Puntos: " + Puntos;
            audioSource.Play(0);
            animator.Play("0000000014", 1, 0); //Thank you
        } else {
            animator.Play("0000000015", 1, 0); //Not enought points audio
            audioSource.PlayOneShot(NotEnough);
        } 
    }
  
    public void ComprarEspejoDoble() {
        if (PrecioBaseEspejoDoble <= Puntos) {
            EspejosDoblesCompradosTotales++;
            PlayerPrefs.SetInt("EspejosDoblesCompradasTotales", EspejosDoblesCompradosTotales);
            EspejosDoblesComprados++;
            PlayerPrefs.SetInt("EspejosDoblesCompradas", EspejosDoblesComprados);
            Puntos -= PrecioBaseEspejoDoble;
            PlayerPrefs.SetInt("Puntos", Puntos);
            PrecioBaseEspejoDoble *= ((EspejosDoblesCompradosTotales + 2)/2);
            tEspejosDobles.text = "Price: " + PrecioBaseEspejoDoble + "\n Inventory: " + EspejosDoblesComprados;
            tPuntos.text = "Puntos: " + Puntos;
            audioSource.Play(0);
           animator.Play("0000000014", 1, 0); //Thank you
        } else {
            animator.Play("0000000015", 1, 0); //Not enought points audio
            audioSource.PlayOneShot(NotEnough);
        }
    }
     public void ComprarPrisma() {
         if (PrecioBasePrisma <= Puntos) {
            PrismasCompradosTotales++;
            PlayerPrefs.SetInt("PrismasCompradosTotales", PrismasCompradosTotales);
            PrismasComprados++;
            PlayerPrefs.SetInt("PrismasComprados", PrismasComprados);
            Puntos -= PrecioBasePrisma;
            PlayerPrefs.SetInt("Puntos", Puntos);
            PrecioBasePrisma *= ((PrismasCompradosTotales + 2)/2);
            tPrismas.text = "Price: " + PrecioBasePrisma + "\n Inventory: " + PrismasComprados;
            tPuntos.text = "Puntos: " + Puntos;
            audioSource.Play(0);
            animator.Play("0000000014", 1, 0); //Thank you
        } else {
            animator.Play("0000000015", 1, 0); //Not enought points audio
            audioSource.PlayOneShot(NotEnough);
        }
    }

    public void Atras() {
        SceneManager.LoadScene("MenuInicial");
    }
}
