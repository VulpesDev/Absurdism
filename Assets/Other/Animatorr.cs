using UnityEngine;

abstract class Animatorr
{
    public static void Set(Animator anime, string animation, bool boolean)
    {
        if (anime.GetBool(animation) == !boolean)
            anime.SetBool(animation, boolean);
    }
}
