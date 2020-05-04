using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music = null;
    static public AudioManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        music.playOnAwake = true;
        music.loop = true;
        music.Play();
    }

    public void Pause()
    {
        music.Pause();
    }

    public void UnPause()
    {
        music.UnPause();
    }

    public void Acelerar(int contador)
    {
        //Aumentamos el pitch acorde al tiempo del cronometro
        if (contador < 50)
        {
            if (contador <= 20)
            {
                if (contador <= 5) music.pitch = 1.3f;
                else music.pitch = 1.2f;
            }
            else music.pitch = 1.1f;
        }
        else music.pitch = 1.0f;

        //restablecemos el pitch, para que asi solo acelere el tempo (sin esto, se oiría más rapido pero mas agudo)
        music.outputAudioMixerGroup.audioMixer.SetFloat("pitchMusica_", 1 / music.pitch);
    }
}
