using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface Magnet
{
    GameObject getGameObject();
    MagnetType getMagnetType();
    void Create(MagnetType type, float force);
}