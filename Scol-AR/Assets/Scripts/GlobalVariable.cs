using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable
{
    public static int nb_elt = 5;
    public static Dictionary<string, GameObject> listAtom = new Dictionary<string, GameObject>();
    public static List<string> currentImages = new List<string>();
    public static List<string> moleculeFound = new List<string>();
    public static string animationToPlay;
}
