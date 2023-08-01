using UnityEngine;
public class SoundsManager : MonoBehaviour
{
    /// <summary>
    /// ButtonInteractionMusic --> On pressing a button.
    /// ButtonInteractionMusic --> Audio played in the background.
    /// CorrectAnswer_1 & CorrectAnswer_2--> When user answer a correct answer. Each one will be played after the one before it,
    /// so the user will not be bored from same audio.
    /// _WrongAnswer --> When user answer a wrong answer.
    /// </summary>
    [SerializeField] private AudioSource ButtonInteractionMusic, BackGroundMusic, CorrectAnswer_1, CorrectAnswer_2, _WrongAnswer;



    /// <summary>
    /// The buttons that will be enabled or disbled depending on user's choice.
    /// </summary>
    [SerializeField] private GameObject AudioButton_On, AudioButton_Off;

    /// <summary>
    ///  WannaPlayAudio = true --> Enabled or disabled depending if the user want to listed to audios in the game or not.
    ///  True by default since a game should starts with audio on.
    ///  PlayNextAudio --> to play the correct audios one after one.
    /// </summary>
    private bool WannaPlayAudio = true, PlayNextAudio;





    /// <summary>
    /// This method is attached to a button, SO
    /// when the user press on this button for the first time, and since the (WannaPlayAudio) is already true
    /// the first condition in this method will be activated, and:
    /// The (BackGroundMusic) will be stopped.
    /// Active audio icon inside the game will be hidden, and the silenced icon will be shown.
    /// WannaPlayAudio = false; --> will be false ,since no audio is running.
    /// return; so the compiler will return and not continue this if statment(since (WannaPlayAudio) is now false, so (return;) is a must).
    /// 
    /// Now the audio is off and the icon of the button is the silenced one(AudioButton_Off)
    /// when the user press on this button for the first time, and since the (WannaPlayAudio) is now false
    /// the second condition in this method will be activated, and:
    /// The (BackGroundMusic) will be played.
    /// Active audio icon inside the game will be now displayed, and the silenced icon will be hidden.
    /// WannaPlayAudio = true; --> will be true ,since the audio is running.
    /// </summary>
    public void TurnAudio_OnOrOff()
    {
        if (WannaPlayAudio == true)
        {
            BackGroundMusic.Stop();
            AudioButton_On.SetActive(false);
            AudioButton_Off.SetActive(true);
            WannaPlayAudio = false;
            return;
        }
        if (WannaPlayAudio == false)
        {
            BackGroundMusic.Play();
            AudioButton_On.SetActive(true);
            AudioButton_Off.SetActive(false);
            WannaPlayAudio = true;
        }
    }



    /// <summary>
    /// This method is attached to each button in the game, if (WannaPlayAudio) is true,
    /// the (ButtonInteractionMusic) will be played on each press.
    /// </summary>
    public void ButtonInteraction()
    {
        if (WannaPlayAudio == true)
            ButtonInteractionMusic.Play();
    }



    /// <summary>
    /// When audio is enabled and no (PlayNextAudio) is false
    /// (CorrectAnswer_1) will be played
    /// PlayNextAudio = true; --> so this audio will not be played on next correct answer.
    /// return; so the compiler will return and not continue this if statment(since (PlayNextAudio) is now true, so (return;) is a must).
    /// 
    /// When audio is enabled and no (PlayNextAudio) is true
    /// This time, (CorrectAnswer_2) will be played.
    /// PlayNextAudio = false; --> so this audio will not be played on next correct answer.
    /// </summary>
    public void CorrectAnswer()
    {
        if (WannaPlayAudio == true && PlayNextAudio == false)
        {
            CorrectAnswer_1.Play();
            PlayNextAudio = true;
            return;
        }
        if (WannaPlayAudio == true && PlayNextAudio == true)
        {
            CorrectAnswer_2.Play();
            PlayNextAudio = false;
        }
    }



    /// <summary>
    /// Playing wrong audio on wrong answers, only incase the (WannaPlayAudio) is true.
    /// </summary>
    public void WrongAnswer()
    {
        if (WannaPlayAudio == true)
            _WrongAnswer.Play();
    }
}