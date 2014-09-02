using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace System
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct Vector3
    {
        public float _x;
        public float _y;
        public float _z;

        public Vector3(float x, float y, float z) { _x = x; _y = y; _z = z; }
        public Vector3(float s) { _x = s; _y = s; _z = s; }

        private const float _colorFactor = 1.0f / 255.0f;
        public static explicit operator Vector3(Color c) { return new Vector3(c.R * _colorFactor, c.G * _colorFactor, c.B * _colorFactor); }
        public static explicit operator Color(Vector3 v) { return Color.FromArgb((int)(v._x / _colorFactor), (int)(v._y / _colorFactor), (int)(v._z / _colorFactor)); }

        public static Vector3 operator -(Vector3 v) { return new Vector3(-v._x, -v._y, -v._z); }
        public static Vector3 operator +(Vector3 v1, Vector3 v2) { return new Vector3(v1._x + v2._x, v1._y + v2._y, v1._z + v2._z); }
        public static Vector3 operator -(Vector3 v1, Vector3 v2) { return new Vector3(v1._x - v2._x, v1._y - v2._y, v1._z - v2._z); }
        public static Vector3 operator -(Vector3 v1, float f) { return new Vector3(v1._x - f, v1._y - f, v1._z - f); }
        public static Vector3 operator *(Vector3 v1, Vector3 v2) { return new Vector3(v1._x * v2._x, v1._y * v2._y, v1._z * v2._z); }
        public static Vector3 operator *(Vector3 v1, float s) { return new Vector3(v1._x * s, v1._y * s, v1._z * s); }
        public static Vector3 operator *(float s, Vector3 v1) { return new Vector3(v1._x * s, v1._y * s, v1._z * s); }
        public static Vector3 operator /(Vector3 v1, Vector3 v2) { return new Vector3(v1._x / v2._x, v1._y / v2._y, v1._z / v2._z); }
        public static Vector3 operator /(Vector3 v1, float s) { return new Vector3(v1._x / s, v1._y / s, v1._z / s); }

        public static bool operator ==(Vector3 v1, Vector3 v2) { return (v1._x == v2._x) && (v1._y == v2._y) && (v1._z == v2._z); }
        public static bool operator !=(Vector3 v1, Vector3 v2) { return (v1._x != v2._x) || (v1._y != v2._y) || (v1._z != v2._z); }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public void Add(Vector3* v) { _x += v->_x; _y += v->_y; _z += v->_z; }
        public void Add(float v) { _x += v; _y += v; _z += v; }
        public void Sub(Vector3* v) { _x -= v->_x; _y -= v->_y; _z -= v->_z; }
        public void Sub(float v) { _x -= v; _y -= v; _z -= v; }
        public void Multiply(Vector3* v) { _x *= v->_x; _y *= v->_y; _z *= v->_z; }
        public void Multiply(float v) { _x *= v; _y *= v; _z *= v; }

        public static float* Mult(float* v1, float* v2) { v1[0] = v1[0] * v2[0]; v1[1] = v1[1] * v2[1]; v1[2] = v1[2] * v2[2]; return v1; }
        public static float* Mult(float* v1, float v2) { v1[0] = v1[0] * v2; v1[1] = v1[1] * v2; v1[2] = v1[2] * v2; return v1; }
        public static float* Add(float* v1, float* v2) { v1[0] = v1[0] + v2[0]; v1[1] = v1[1] + v2[1]; v1[2] = v1[2] + v2[2]; return v1; }
        public static float* Add(float* v1, float v2) { v1[0] = v1[0] + v2; v1[1] = v1[1] + v2; v1[2] = v1[2] + v2; return v1; }
        public static float* Sub(float* v1, float* v2) { v1[0] = v1[0] - v2[0]; v1[1] = v1[1] - v2[1]; v1[2] = v1[2] - v2[2]; return v1; }
        public static float* Sub(float* v1, float v2) { v1[0] = v1[0] - v2; v1[1] = v1[1] - v2; v1[2] = v1[2] - v2; return v1; }

        //public static float* Mult(float* v1, float* v2) { v1[0] = v1[0] * v2[0]; v1[1] = v1[1] * v2[1]; v1[2] = v1[2] * v2[2]; return v1; }
        //public static float* Mult(float* v1, float v2) { v1[0] *= v2; v1[1] *= v2; v1[2] *= v2; return v1; }
        //public static float* Add(float* v1, float* v2) { v1[0] += v2[0]; v1[1] += v2[1]; v1[2] += v2[2]; return v1; }
        //public static float* Add(float* v1, float v2) { v1[0] += v2; v1[1] += v2; v1[2] += v2; return v1; }
        //public static float* Sub(float* v1, float* v2) { v1[0] -= v2[0]; v1[1] -= v2[1]; v1[2] -= v2[2]; return v1; }
        //public static float* Sub(float* v1, float v2) { v1[0] -= v2; v1[1] -= v2; v1[2] -= v2; return v1; }

        public static float Dot(Vector3 v1, Vector3 v2) { return (v1._x * v2._x) + (v1._y * v2._y) + (v1._z * v2._z); }
        public float Dot(Vector3 v) { return (_x * v._x) + (_y * v._y) + (_z * v._z); }
        public float Dot(Vector3* v) { return (_x * v->_x) + (_y * v->_y) + (_z * v->_z); }

        public static Vector3 Clamp(Vector3 v1, float min, float max) { v1.Clamp(min, max); return v1; }
        public void Clamp(float min, float max) { this.Max(min); this.Min(max); }

        public static Vector3 Min(Vector3 v1, Vector3 v2) { return new Vector3(Math.Min(v1._x, v2._x), Math.Min(v1._y, v2._y), Math.Min(v1._z, v2._z)); }
        public static Vector3 Min(Vector3 v1, float f) { return new Vector3(Math.Min(v1._x, f), Math.Min(v1._y, f), Math.Min(v1._z, f)); }
        public void Min(Vector3 v) { _x = Math.Min(_x, v._x); _y = Math.Min(_y, v._y); _z = Math.Min(_z, v._z); }
        public void Min(Vector3* v) { if (v->_x < _x) _x = v->_x; if (v->_y < _y) _y = v->_y; if (v->_z < _z) _z = v->_z; }
        public void Min(float f) { _x = Math.Min(_x, f); _y = Math.Min(_y, f); _z = Math.Min(_z, f); }

        public static Vector3 Max(Vector3 v1, Vector3 v2) { return new Vector3(Math.Max(v1._x, v2._x), Math.Max(v1._y, v2._y), Math.Max(v1._z, v2._z)); }
        public static Vector3 Max(Vector3 v1, Vector3* v2) { return new Vector3(Math.Max(v1._x, v2->_x), Math.Max(v1._y, v2->_y), Math.Max(v1._z, v2->_z)); }
        public static Vector3 Max(Vector3 v1, float f) { return new Vector3(Math.Max(v1._x, f), Math.Max(v1._y, f), Math.Max(v1._z, f)); }
        public void Max(Vector3 v) { _x = Math.Max(_x, v._x); _y = Math.Max(_y, v._y); _z = Math.Max(_z, v._z); }
        public void Max(Vector3* v) { if (v->_x > _x) _x = v->_x; if (v->_y > _y) _y = v->_y; if (v->_z > _z) _z = v->_z; }
        public void Max(float f) { _x = Math.Max(_x, f); _y = Math.Max(_y, f); _z = Math.Max(_z, f); }

        public float DistanceTo(Vector3 v) { Vector3 v1 = this - v; return Vector3.Dot(v1, v1); }
        public static Vector3 Lerp(Vector3 v1, Vector3 v2, float median) { return (v1 * (1.0f - median)) + (v2 * median); }
        public static Vector3 Floor(Vector3 v) { return new Vector3((int)v._x, (int)v._y, (int)v._z); }

        public static Vector3 Truncate(Vector3 v)
        {
            return new Vector3(
                v._x > 0.0f ? (float)Math.Floor(v._x) : (float)Math.Ceiling(v._x),
                v._y > 0.0f ? (float)Math.Floor(v._y) : (float)Math.Ceiling(v._z),
                v._z > 0.0f ? (float)Math.Floor(v._z) : (float)Math.Ceiling(v._z));
        }

        public override string ToString()
        {
            return String.Format("({0},{1},{2})", _x, _y, _z);
        }

        public bool Contained(Vector3 start, Vector3 end, float expansion) { return Contained(this, start, end, expansion); }
        public static unsafe bool Contained(Vector3 point, Vector3 start, Vector3 end, float expansion)
        {
            float* sPtr = (float*)&point;
            float* s1 = (float*)&start, s2 = (float*)&end;
            float* temp;
            for (int i = 0; i < 3; i++)
            {
                if (s1[i] > s2[i])
                { temp = s1; s1 = s2; s2 = temp; }

                if ((sPtr[i] < (s1[i] - expansion)) || (sPtr[i] > (s2[i] + expansion)))
                    return false;
            }
            return true;
        }

        public static Vector3 IntersectZ(Vector3 ray1, Vector3 ray2, float z)
        {
            float a = ray2._z - ray1._z;

            float tanX = (ray1._y - ray2._y) / a;
            float tanY = (ray2._x - ray1._x) / a;

            a = z - ray1._z;
            return new Vector3(tanY * a + ray1._x, -tanX * a + ray1._y, z);
        }

        public float TrueDistance(Vector3 p)
        {
            float lenX = Math.Abs(p._x - _x);
            float lenY = Math.Abs(p._y - _y);
            float lenZ = Math.Abs(p._z - _z);
            float h;

            if (lenX == 0.0f)
                h = lenY;
            else if (lenY == 0.0f)
                h = lenX;
            else
                h = (float)(lenX / Math.Cos(Math.Atan(lenY / lenX)));

            if (lenZ == 0.0f)
                return h;
            else if (h == 0.0f)
                return lenZ;
            else
                return (float)(h / Math.Cos(Math.Atan(lenZ / h)));
        }
    }
}
