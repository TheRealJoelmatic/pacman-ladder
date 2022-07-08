using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Fruits : MonoBehaviour
{
    public GameObject Apple;
    public GameObject Bell;
    public GameObject Cherry;
    public GameObject GalaxianStarship;
    public GameObject Key;
    public GameObject Melon;
    public GameObject Orange;
    public GameObject Strawberry;

    public Component[] Sprit;

    public AudioSource Eats;

    public Text HasGot;

    private bool TimerOn;

    public string FruitEaten;


    private float targetTime = 10.0f;

    private bool hasEaten = false;

    private void Start()
    {
        HasGot.text = "false";
        Sprit = GetComponentsInChildren<SpriteRenderer>();

        this.GetComponent<CircleCollider2D>().enabled = true;

        Genarate();
    }

    private void Genarate()
    {
        int randomNumber = Random.Range(1, 8);

        if (randomNumber == 1)
        {
            AllOf();
            Apple.SetActive(true);
            TimerOn = true;
            FruitEaten = "apple";
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (randomNumber == 2)
        {
            AllOf();
            Bell.SetActive(true);
            TimerOn = true;
            FruitEaten = "bell";
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (randomNumber == 3)
        {
            AllOf();
            Cherry.SetActive(true);
            TimerOn = true;
            FruitEaten = "cherry";
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (randomNumber == 4)
        {
            AllOf();
            GalaxianStarship.SetActive(true);
            TimerOn = true;
            FruitEaten = "galaxianstarship";
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (randomNumber == 5)
        {
            AllOf();
            Key.SetActive(true);
            TimerOn = true;
            FruitEaten = "key";
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (randomNumber == 6)
        {
            AllOf();
            Melon.SetActive(true);
            TimerOn = true;
            FruitEaten = "Melon";
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (randomNumber == 7)
        {
            AllOf();
            Orange.SetActive(true);
            TimerOn = true;
            FruitEaten = "Orange";
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
        else if (randomNumber == 8)
        {
            AllOf();
            Strawberry.SetActive(true);
            TimerOn = true;
            FruitEaten = "Strawberry";
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
    }

    private void AllOf()
    {
        Apple.SetActive(false);
        Bell.SetActive(false);
        Cherry.SetActive(false);
        GalaxianStarship.SetActive(false);
        Key.SetActive(false);
        Melon.SetActive(false);
        Orange.SetActive(false);
        Strawberry.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eat();
        }
    }
    private void Eat()
    {
        Eats.Play();
        HasGot.text = "true";
        AllOf();
        hasEaten = true;
        this.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(Startagain());
    }

    IEnumerator Startagain()
    {
        Debug.Log("starting again");
        yield return new WaitForSeconds(20f);
        hasEaten = false;
        targetTime = 10.0f;
        Genarate();
    }

    private void Update()
    {

        if (TimerOn == true && hasEaten == false)
        {
            targetTime -= Time.deltaTime;
            if (targetTime <= 5.0f)
            {
                TimerOn = false;
                StartCoroutine(TimerEnding());
            }
        }
    }
    IEnumerator TimerEnding()
    {
        this.GetComponent<CircleCollider2D>().enabled = true;
        FlashOff();
        yield return new WaitForSeconds(0.5f);
        FlashOn();
        yield return new WaitForSeconds(0.5f);
        FlashOff();
        yield return new WaitForSeconds(0.5f);
        FlashOn();
        yield return new WaitForSeconds(0.5f);
        FlashOff();
        yield return new WaitForSeconds(0.5f);
        FlashOn();
        yield return new WaitForSeconds(0.5f);
        FlashOff();
        yield return new WaitForSeconds(0.5f);
        FlashOn();
        yield return new WaitForSeconds(0.5f);
        FlashOff();
        this.GetComponent<CircleCollider2D>().enabled = false;

    }

    public void FlashOn()
    {
        if(HasGot.text == "false")
        {
            this.GetComponent<CircleCollider2D>().enabled = true;
            if (FruitEaten == "apple")
            {
                Apple.SetActive(true);
            }
            else if (FruitEaten == "bell")
            {
                Bell.SetActive(true);
            }
            else if (FruitEaten == "cherry")
            {
                Cherry.SetActive(true);
            }
            else if (FruitEaten == "galaxianstarship")
            {
                GalaxianStarship.SetActive(true);
            }
            else if (FruitEaten == "key")
            {
                Key.SetActive(true);
            }
            else if (FruitEaten == "Melon")
            {
                Melon.SetActive(true);
            }
            else if (FruitEaten == "Orange")
            {
                Orange.SetActive(true);
            }
            else if (FruitEaten == "Strawberry")
            {
                Strawberry.SetActive(true);
            }
            else
            {
                Apple.SetActive(true);
            }
        }
    }
    public void FlashOff()
    {
        if (HasGot.text == "false")
        {
            this.GetComponent<CircleCollider2D>().enabled = true;
            if (FruitEaten == "apple")
            {
                Apple.SetActive(false);
            }
            else if (FruitEaten == "bell")
            {
                Bell.SetActive(false);
            }
            else if (FruitEaten == "cherry")
            {
                Cherry.SetActive(false);
            }
            else if (FruitEaten == "galaxianstarship")
            {
                GalaxianStarship.SetActive(false);
            }
            else if (FruitEaten == "key")
            {
                Key.SetActive(false);
            }
            else if (FruitEaten == "Melon")
            {
                Melon.SetActive(false);
            }
            else if (FruitEaten == "Orange")
            {
                Orange.SetActive(false);
            }
            else if (FruitEaten == "Strawberry")
            {
                Strawberry.SetActive(false);
            }
            else
            {
                Apple.SetActive(false);
            }
        } 
    }
}
