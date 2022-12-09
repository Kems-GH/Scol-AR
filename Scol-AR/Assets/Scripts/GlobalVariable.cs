using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariable
{
    public static Dictionary<string, GameObject> listAtom = new Dictionary<string, GameObject>();
    public static List<string> currentImages = new List<string>();
    public static List<string> moleculeFound = new List<string>();
    public static List<string> periodicTable = new List<string>()
    {
        "H", "He",
        "Li", "Be", "B", "C", "N", "O", "F", "Ne",
        "Na", "Mg", "Al", "Si", "P", "P", "S", "Cl", "Ar",
        "K", "Ca", "Sc", "Ti", "V", "Cr", "Mn", "Fe", "Co", "Ni", "Cu", "Zn", "Ga", "Ge", "As", "Se", "Br", "Kr",
        "Rb", "Sr", "Y", "Zr", "Nb", "Mo", "Tc", "Ru", "Rh", "Pd", "Ag", "Cd", "In", "Sn", "Sb", "Te", "I", "Xe"
    };
}
