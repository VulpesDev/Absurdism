using System.Collections;
using UnityEngine;
using Cinemachine;

class CameraEffect : MonoBehaviour
{
    public static CinemachineBasicMultiChannelPerlin cnChannel;
    public static IEnumerator Shaker(int amplitude, int frequency, float time_sec)
    {
        cnChannel = GameObject.FindGameObjectWithTag("VirtualCam").GetComponent<CinemachineVirtualCamera>().
            GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cnChannel.m_AmplitudeGain = amplitude;
        cnChannel.m_FrequencyGain = frequency;
        yield return new WaitForSeconds(time_sec);
        cnChannel.m_AmplitudeGain = 0;
        cnChannel.m_FrequencyGain = 0;
    }
}
