using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point{
    //Since we are building 3d we need X and Z axis info
    public int X { get; set;} //X pos
    public int Z { get; set; } //Z pos

    public Point(int x, int z) {
        this.X = x;
        this.Z = z;
    }
}
