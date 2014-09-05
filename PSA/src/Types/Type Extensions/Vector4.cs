using System;
using System.Runtime.InteropServices;

namespace System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vector4
    {
        public float x, y, z, w;

        public Vector4(float x, float y, float z, float w) { this.x = x; this.y = y; this.z = z; this.w = w; }

        public static explicit operator Vector3(Vector4 v) { return new Vector3(v.x / v.w, v.y / v.w, v.z / v.w); }
        public static explicit operator Vector4(Vector3 v) { return new Vector4(v._x, v._y, v._z, 1.0f); }
    }
}
