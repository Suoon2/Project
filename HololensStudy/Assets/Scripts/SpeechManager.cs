using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;
using UnityEngine.SceneManagement;
public class SpeechManager : MonoBehaviour
{
    KeywordRecognizer recognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    void Start()
    {
        keywords.Add("Hi", () =>
        {
            FindObjectOfType<Sphere>().OnTapped();
            });

        keywords.Add("Reset", () => 
        {
            SceneManager.LoadScene("Test02");
        });

        recognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
        recognizer.Start();
    }

    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action action;
        if (keywords.TryGetValue(args.text, out action))
        {
            action();
        }
    }

    void Update()
    {

    }
}
