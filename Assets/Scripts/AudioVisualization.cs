using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioVisualization : MonoBehaviour
{
    private AudioSource _audioSource;
    [HideInInspector] public float[] Samples = new float[512];

    void Awake ()
    {
        _audioSource = GetComponent<AudioSource> ();
    }

    private void Update ()
    {
        GetSpectrum ();
    }

    void GetSpectrum ()
    {
        _audioSource.GetSpectrumData (Samples, 0, FFTWindow.Blackman);
    }
}