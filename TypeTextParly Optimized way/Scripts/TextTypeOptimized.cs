using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextTypeOptimized : MonoBehaviour
{


    public AudioSource Source;

    public AudioClip UIClip;

    public Text SubText;

    [SerializeField] string tempstring;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        

        StartCoroutine(TypeTextCO(SubText, tempstring, 1f ,"BATPAN: ", Source));


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator TypeTextCO(Text textcomponent, string FullText, float duration ,string WhoSaid, AudioSource source)
    {

        textcomponent.text = WhoSaid; // start with who said

        float spenttime = 0f;

        int charIndex = 0;

        // start audio

        if(source != null )
        {

            source.PlayOneShot(UIClip);


        }

        // start audio

        while (charIndex < FullText.Length)
        {

            spenttime += Time.deltaTime;

            int newCharCount = Mathf.FloorToInt((spenttime / duration) * FullText.Length);

            if(newCharCount > charIndex)
            {

                textcomponent.text = WhoSaid + FullText.Substring(0, newCharCount);
                charIndex = newCharCount;


            }

            yield return null; // wait for the next frame



        }

        textcomponent.text = WhoSaid + FullText; // ensure the correct sentence is shown

        // stop audio playing

        if(source != null )
        {


            source.Stop();


        }

        // stop audio playing





    }





}
