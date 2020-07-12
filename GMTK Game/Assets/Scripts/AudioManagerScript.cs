using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioClip aLooksgood1, aLooksgood2, aLooksgood3, aLooksgood4, aLooksgood5, aLooksgood6, aLooksgood7, aGhost1, aGhost2, aOrderup1, aOrderup2, aOrderup3, aOrderup4, aOrderup5, aOrderup6, aSpecialorder, aWrong1, aWrong2, aWrong3, aWrong4, aWrong5, aWrong6;
    static AudioSource audioSrc;

    void Start()
    {
        aLooksgood1 = Resources.Load<AudioClip>("looksgood1");
        aLooksgood2 = Resources.Load<AudioClip>("looksgood2");
        aLooksgood3 = Resources.Load<AudioClip>("looksgood3");
        aLooksgood4 = Resources.Load<AudioClip>("looksgood4");
        aLooksgood5 = Resources.Load<AudioClip>("looksgood5");
        aLooksgood6 = Resources.Load<AudioClip>("looksgood6");
        aLooksgood7 = Resources.Load<AudioClip>("looksgood7");
        aGhost1 = Resources.Load<AudioClip>("ghost1");
        aGhost2 = Resources.Load<AudioClip>("ghost2");
        aOrderup1 = Resources.Load<AudioClip>("orderup1");
        aOrderup2 = Resources.Load<AudioClip>("orderup2");
        aOrderup3 = Resources.Load<AudioClip>("orderup3");
        aOrderup4 = Resources.Load<AudioClip>("orderup4");
        aOrderup5 = Resources.Load<AudioClip>("orderup5");
        aOrderup6 = Resources.Load<AudioClip>("orderup6");
        aSpecialorder = Resources.Load<AudioClip>("specialorder");
        aWrong1 = Resources.Load<AudioClip>("wrong1");
        aWrong2 = Resources.Load<AudioClip>("wrong2");
        aWrong3 = Resources.Load<AudioClip>("wrong3");
        aWrong4 = Resources.Load<AudioClip>("wrong4");
        aWrong5 = Resources.Load<AudioClip>("wrong5");
        aWrong6 = Resources.Load<AudioClip>("wrong6");


        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {

        switch (clip)
        {
            case "looksgood1":
                audioSrc.PlayOneShot(aLooksgood1);
                break;
            case "looksgood2":
                audioSrc.PlayOneShot(aLooksgood2);
                break;
            case "looksgood3":
                audioSrc.PlayOneShot(aLooksgood3);
                break;
            case "looksgood4":
                audioSrc.PlayOneShot(aLooksgood4);
                break;
            case "looksgood5":
                audioSrc.PlayOneShot(aLooksgood5);
                break;
            case "looksgood6":
                audioSrc.PlayOneShot(aLooksgood6);
                break;
            case "looksgood7":
                audioSrc.PlayOneShot(aLooksgood7);
                break;
            case "ghost1":
                audioSrc.PlayOneShot(aGhost1);
                break;
            case "ghost2":
                audioSrc.PlayOneShot(aGhost2);
                break;
            case "orderup1":
                audioSrc.PlayOneShot(aOrderup1);
                break;
            case "orderup2":
                audioSrc.PlayOneShot(aOrderup2);
                break;
            case "orderup3":
                audioSrc.PlayOneShot(aOrderup3);
                break;
            case "orderup4":
                audioSrc.PlayOneShot(aOrderup4);
                break;
            case "orderup5":
                audioSrc.PlayOneShot(aOrderup5);
                break;
            case "orderup6":
                audioSrc.PlayOneShot(aOrderup6);
                break;
            case "specialorder":
                audioSrc.PlayOneShot(aSpecialorder);
                break;
            case "wrong1":
                audioSrc.PlayOneShot(aWrong1);
                break;
            case "wrong2":
                audioSrc.PlayOneShot(aWrong2);
                break;
            case "wrong3":
                audioSrc.PlayOneShot(aWrong3);
                break;
            case "wrong4":
                audioSrc.PlayOneShot(aWrong4);
                break;
            case "wrong5":
                audioSrc.PlayOneShot(aWrong5);
                break;
            case "wrong6":
                audioSrc.PlayOneShot(aWrong6);
                break;
        }
    }
}
