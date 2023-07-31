// ReSharper disable CompareOfFloatsByEqualityOperator

using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Engine.Math;

internal struct MathfInternal
{
    public const float FloatMinNormal = 1.17549435E-38f;
    public const float FloatMinDenormal = float.Epsilon;

    public const bool IsFlushToZeroEnabled = FloatMinDenormal == 0;
}

public struct Mathf
{
    /// <summary>
    /// Defines the value of Pi as a <see cref="float"/>.
    /// </summary>
    public const float Pi = 3.1415927f;

    /// <summary>
    /// Defines the value of Pi divided by two as a <see cref="float"/>.
    /// </summary>
    public const float PiOver2 = Pi / 2;

    /// <summary>
    /// Defines the value of Pi divided by three as a <see cref="float"/>.
    /// </summary>
    public const float PiOver3 = Pi / 3;

    /// <summary>
    /// Defines the value of  Pi divided by four as a <see cref="float"/>.
    /// </summary>
    public const float PiOver4 = Pi / 4;

    /// <summary>
    /// Defines the value of Pi divided by six as a <see cref="float"/>.
    /// </summary>
    public const float PiOver6 = Pi / 6;

    /// <summary>
    /// Defines the value of Pi multiplied by two as a <see cref="float"/>.
    /// </summary>
    public const float TwoPi = 2 * Pi;

    /// <summary>
    /// Defines the value of Pi multiplied by 3 and divided by two as a <see cref="float"/>.
    /// </summary>
    public const float ThreePiOver2 = 3 * Pi / 2;

    /// <summary>
    /// Defines the value of E as a <see cref="float"/>.
    /// </summary>
    public const float E = 2.7182817f;

    /// <summary>
    /// Defines the base-10 logarithm of E.
    /// </summary>
    public const float Log10E = 0.4342945f;

    /// <summary>
    /// Defines the base-2 logarithm of E.
    /// </summary>
    public const float Log2E = 1.442695f;

    /// <summary>
    /// A representation of positive infinity (RO).
    /// </summary>
    public const float Infinity = float.PositiveInfinity;

    /// <summary>
    /// A representation of negative infinity (RO).
    /// </summary>
    public const float NegativeInfinity = float.NegativeInfinity;

    /// <summary>
    /// Degrees-to-radians conversion constant (RO).
    /// </summary>
    public const float Deg2Rad = Pi * 2F / 360F;

    /// <summary>
    /// Radians-to-degrees conversion constant (RO).
    /// </summary>
    public const float Rad2Deg = 1F / Deg2Rad;

    /// <summary>
    /// A tiny floating point value (RO).
    /// </summary>
    public static readonly float epsilon =
        MathfInternal.IsFlushToZeroEnabled
            ? MathfInternal.FloatMinNormal
            : MathfInternal.FloatMinDenormal;


    public static float ACos(float x)
    {
        return (float)System.Math.Acos(x);
    }

    public static double ACos(double x)
    {
        return System.Math.Acos(x);
    }

    public static float ACos2(float x)
    {
        if (x < 1f) return 0f;

        return (float)System.Math.Log(x + System.Math.Sqrt(x * x - 1f));
    }

    public static float ASin(float x)
    {
        return (float)System.Math.Asin(x);
    }

    public static double ASin(double x)
    {
        return System.Math.Asin(x);
    }

    public static float ASin2(float x)
    {
        return (x < 0f ? -1f : x > 0f ? 1f : 0f) *
               (float)System.Math.Log(System.Math.Abs(x) + System.Math.Sqrt(1f + x * x));
    }

    public static float ATan(float y, float x)
    {
        return (float)System.Math.Atan2(y, x);
    }

    public static double ATan(double y, double x)
    {
        return System.Math.Atan2(y, x);
    }

    public static float ATan(float yOverX)
    {
        return (float)System.Math.Atan(yOverX);
    }

    public static double ATan(double yOverX)
    {
        return System.Math.Atan(yOverX);
    }

    public static float ATan2(float x)
    {
        if (System.Math.Abs(x) >= 1f) return 0;

        return 0.5f * (float)System.Math.Log((1f + x) / (1f - x));
    }

    public static float Cos(float angle)
    {
        return (float)System.Math.Cos(angle);
    }

    public static double Cos(double angle)
    {
        return System.Math.Cos(angle);
    }

    public static float Cos2(float angle)
    {
        return (float)System.Math.Cosh(angle);
    }

    public static double Cos2(double angle)
    {
        return System.Math.Cosh(angle);
    }

    public static float Degrees(float radians)
    {
        return radians * 57.295779513082320876798154814105f;
    }

    public static double Degrees(double radians)
    {
        return radians * 57.295779513082320876798154814105d;
    }

    public static float Radians(float degrees)
    {
        return degrees * 0.01745329251994329576923690768489f;
    }

    public static double Radians(double degrees)
    {
        return degrees * 0.01745329251994329576923690768489d;
    }

    public static float Sin(float angle)
    {
        return (float)System.Math.Sin(angle);
    }

    public static double Sin(double angle)
    {
        return System.Math.Sin(angle);
    }

    public static float Sin2(float angle)
    {
        return (float)System.Math.Sinh(angle);
    }

    public static double Sin2(double angle)
    {
        return System.Math.Sinh(angle);
    }

    public static float Tan(float angle)
    {
        return (float)System.Math.Tan(angle);
    }

    public static double Tan(double angle)
    {
        return System.Math.Tan(angle);
    }

    public static float TanH(float angle)
    {
        return (float)System.Math.Tanh(angle);
    }

    public static double TanH(double angle)
    {
        return System.Math.Tanh(angle);
    }

    [Pure]
    public static float Sqrt(float f)
    {
        return (float)System.Math.Sqrt(f);
    }

    [Pure]
    public static double Sqrt(double f)
    {
        return System.Math.Sqrt(f);
    }

    [Pure]
    public static float Abs(float f)
    {
        return System.Math.Abs(f);
    }

    [Pure]
    public static double Abs(double f)
    {
        return System.Math.Abs(f);
    }

    [Pure]
    public static int Abs(int value)
    {
        return System.Math.Abs(value);
    }

    [Pure]
    public static float Min(float a, float b)
    {
        return a < b ? a : b;
    }

    [Pure]
    public static double Min(double a, double b)
    {
        return a < b ? a : b;
    }

    [Pure]
    public static float Min(params float[] values)
    {
        var len = values.Length;
        if (len == 0) return 0;

        var m = values[0];
        for (var i = 1; i < len; i++)
            if (values[i] < m)
                m = values[i];

        return m;
    }

    [Pure]
    public static int Min(int a, int b)
    {
        return a < b ? a : b;
    }

    [Pure]
    public static int Min(params int[] values)
    {
        var len = values.Length;
        if (len == 0) return 0;

        var m = values[0];
        for (var i = 1; i < len; i++)
            if (values[i] < m)
                m = values[i];

        return m;
    }

    [Pure]
    public static float Max(float a, float b)
    {
        return a > b ? a : b;
    }

    [Pure]
    public static double Max(double a, double b)
    {
        return a > b ? a : b;
    }

    [Pure]
    public static float Max(params float[] values)
    {
        var len = values.Length;
        if (len == 0) return 0;

        var m = values[0];
        for (var i = 1; i < len; i++)
            if (values[i] > m)
                m = values[i];

        return m;
    }

    [Pure]
    public static int Max(int a, int b)
    {
        return a > b ? a : b;
    }

    [Pure]
    public static int Max(params int[] values)
    {
        var len = values.Length;
        if (len == 0) return 0;

        var m = values[0];
        for (var i = 1; i < len; i++)
            if (values[i] > m)
                m = values[i];

        return m;
    }

    /// <summary>
    /// Returns a specified number raised to the specified power.
    /// </summary>
    [Pure]
    public static float Pow(float f, float p)
    {
        return (float)System.Math.Pow(f, p);
    }

    /// <summary>
    /// Returns a specified number raised to the specified power.
    /// </summary>
    [Pure]
    public static double Pow(double f, double p)
    {
        return System.Math.Pow(f, p);
    }

    [Pure]
    public static float Exp(float power)
    {
        return (float)System.Math.Exp(power);
    }

    [Pure]
    public static double Exp(double power)
    {
        return System.Math.Exp(power);
    }

    [Pure]
    public static float Log(float f, float p)
    {
        return (float)System.Math.Log(f, p);
    }

    [Pure]
    public static double Log(double f, double p)
    {
        return System.Math.Log(f, p);
    }

    [Pure]
    public static float Log(float f)
    {
        return (float)System.Math.Log(f);
    }

    [Pure]
    public static double Log(double f)
    {
        return System.Math.Log(f);
    }

    [Pure]
    public static float Log10(float f)
    {
        return (float)System.Math.Log10(f);
    }

    [Pure]
    public static double Log10(double f)
    {
        return System.Math.Log10(f);
    }


    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to the specified double-precision floating-point number.
    /// </summary>
    [Pure]
    public static float Ceil(float f)
    {
        return (float)System.Math.Ceiling(f);
    }

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to the specified double-precision floating-point number.
    /// </summary>
    [Pure]
    public static double Ceil(double f)
    {
        return System.Math.Ceiling(f);
    }

    /// <summary>
    /// Returns the largest integral value less than or equal to the specified double-precision floating-point number.
    /// </summary>
    [Pure]
    public static float Floor(float f)
    {
        return (float)System.Math.Floor(f);
    }

    /// <summary>
    /// Returns the largest integral value less than or equal to the specified double-precision floating-point number.
    /// </summary>
    [Pure]
    public static double Floor(double f)
    {
        return System.Math.Floor(f);
    }

    /// <summary>
    /// Rounds a double-precision floating-point value to the nearest integral value, and rounds midpoint values to the nearest even number.
    /// </summary>
    [Pure]
    public static float Round(float f)
    {
        return (float)System.Math.Round(f);
    }

    /// <summary>
    /// Rounds a double-precision floating-point value to the nearest integral value, and rounds midpoint values to the nearest even number.
    /// </summary>
    [Pure]
    public static double Round(double f)
    {
        return System.Math.Round(f);
    }

    /// <summary>
    /// Returns the smallest integral value that is greater than or equal to the specified double-precision floating-point number.
    /// </summary>
    [Pure]
    public static int CeilToInt(float f)
    {
        return (int)System.Math.Ceiling(f);
    }

    /// <summary>
    /// Returns the largest integral value less than or equal to the specified double-precision floating-point number.
    /// </summary>
    [Pure]
    public static int FloorToInt(float f)
    {
        return (int)System.Math.Floor(f);
    }

    /// <summary>
    /// Rounds a double-precision floating-point value to the nearest integral value, and rounds midpoint values to the nearest even number.
    /// </summary>
    [Pure]
    public static int RoundToInt(float f)
    {
        return (int)System.Math.Round(f);
    }

    /// <summary>
    /// Returns the sign of <param name="f"></param>
    /// </summary>
    public static float Sign(float f)
    {
        return f >= 0F ? 1F : -1F;
    }

    /// <summary>
    /// Clamps a value between a minimum float and maximum float value.
    /// </summary>
    [Pure]
    public static float Clamp(float value, float min, float max)
    {
        if (value < min)
            value = min;
        else if (value > max) value = max;

        return value;
    }

    /// <summary>
    /// Clamps a value between a minimum double and maximum double value.
    /// </summary>
    [Pure]
    public static double Clamp(double value, double min, double max)
    {
        if (value < min)
            value = min;
        else if (value > max) value = max;

        return value;
    }

    // Clamps value between min and max and returns value.
    public static int Clamp(int value, int min, int max)
    {
        if (value < min)
            value = min;
        else if (value > max) value = max;

        return value;
    }

    // Clamps value between 0 and 1 and returns value
    public static double Clamp01(double value)
    {
        return value switch
        {
            < 0.0 => 0.0,
            > 1.0 => 1.0,
            _ => value
        };
    }


    /// <summary>
    /// Returns the remainder resulting from the division of a specified number by another specified number.
    /// </summary>
    /// <param name="a">A dividend.</param>
    /// <param name="b">A divisor.</param>
    /// <returns>A number equal to a - (b Q), where Q is the quotient of a / b rounded to the nearest integer (if a / b falls halfway between two integers, the even integer is returned).
    /// If a - (b Q) is zero, the value +0 is returned if a is positive, or -0 if a is negative.
    /// If b = 0, NaN is returned.</returns>
    [Pure]
    public static double IeeeRemainder(double a, double b)
    {
        return System.Math.IEEERemainder(a, b);
    }

    // Same as ::ref::Lerp but makes sure the values interpolate correctly when they wrap around 360 degrees.
    public static float LerpAngle(float a, float b, float t)
    {
        var delta = Repeat(b - a, 360);
        if (delta > 180) delta -= 360;

        return (float)(a + delta * Clamp01(t));
    }

    // Moves a value /current/ towards /target/.
    public static float MoveTowards(float current, float target, float maxDelta)
    {
        if (Abs(target - current) <= maxDelta) return target;

        return current + Sign(target - current) * maxDelta;
    }

    // Same as ::ref::MoveTowards but makes sure the values interpolate correctly when they wrap around 360 degrees.
    public static float MoveTowardsAngle(float current, float target, float maxDelta)
    {
        var deltaAngle = DeltaAngle(current, target);
        if (-maxDelta < deltaAngle && deltaAngle < maxDelta) return target;

        target = current + deltaAngle;
        return MoveTowards(current, target, maxDelta);
    }

    // Interpolates between /min/ and /max/ with smoothing at the limits.
    public static float SmoothStep(float from, float to, float t)
    {
        t = (float)Clamp01(t);
        t = -2.0F * t * t * t + 3.0F * t * t;
        return to * t + from * (1F - t);
    }

    public static float Gamma(float value, float absMax, float gamma)
    {
        var negative = value < 0F;
        var abs = Abs(value);
        if (abs > absMax) return negative ? -abs : abs;

        var result = Pow(abs / absMax, gamma) * absMax;
        return negative ? -result : result;
    }

    // Compares two floating point values if they are similar.
    public static bool Approximately(float a, float b)
    {
        // If a or b is zero, compare that the other is less or equal to epsilon.
        // If neither a or b are 0, then find an epsilon that is good for
        // comparing numbers at the maximum magnitude of a and b.
        // Floating points have about 7 significant digits, so
        // 1.000001f can be represented while 1.0000001f is rounded to zero,
        // thus we could use an epsilon of 0.000001f for comparing values close to 1.
        // We multiply this epsilon by the biggest magnitude of a and b.
        return Abs(b - a) < Max(0.000001f * Max(Abs(a), Abs(b)), epsilon * 8);
    }

    // Gradually changes a value towards a desired goal over time.
    public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime,
        float maxSpeed, float deltaTime)
    {
        // Based on Game Programming Gems 4 Chapter 1.10
        smoothTime = Max(0.0001F, smoothTime);
        var omega = 2F / smoothTime;

        var x = omega * deltaTime;
        var exp = 1F / (1F + x + 0.48F * x * x + 0.235F * x * x * x);
        var change = current - target;
        var originalTo = target;

        // Clamp maximum speed
        var maxChange = maxSpeed * smoothTime;
        change = Clamp(change, -maxChange, maxChange);
        target = current - change;

        var temp = (currentVelocity + omega * change) * deltaTime;
        currentVelocity = (currentVelocity - omega * temp) * exp;
        var output = target + (change + temp) * exp;

        // Prevent overshooting
        if (originalTo - current > 0.0F != output > originalTo) return output;

        output = originalTo;
        currentVelocity = (output - originalTo) / deltaTime;

        return output;
    }

    // Gradually changes an angle given in degrees towards a desired goal angle over time.
    public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime,
        float maxSpeed, float deltaTime)
    {
        target = current + DeltaAngle(current, target);
        return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
    }

    // Loops the value t, so that it is never larger than length and never smaller than 0.
    public static float Repeat(float t, float length)
    {
        return Clamp(t - Floor(t / length) * length, 0.0f, length);
    }

    // PingPongs the value t, so that it is never larger than length and never smaller than 0.
    public static float PingPong(float t, float length)
    {
        t = Repeat(t, length * 2F);
        return length - Abs(t - length);
    }

    // Calculates the ::ref::Lerp parameter between of two values.
    public static float InverseLerp(float a, float b, float value)
    {
        return (float)(a != b ? Clamp01((value - a) / (b - a)) : 0.0f);
    }

    // Calculates the shortest difference between two given angles.
    public static float DeltaAngle(float current, float target)
    {
        var delta = Repeat(target - current, 360.0F);
        if (delta > 180.0F) delta -= 360.0F;

        return delta;
    }

    internal static long RandomToLong(Random r)
    {
        var buffer = new byte[8];
        r.NextBytes(buffer);
        return (long)(BitConverter.ToUInt64(buffer, 0) & long.MaxValue);
    }

    /// <summary>
    /// Returns an approximation of the inverse square root of left number.
    /// </summary>
    /// <param name="x">A number.</param>
    /// <returns>An approximation of the inverse square root of the specified number, with an upper error bound of 0.001.</returns>
    /// <remarks>
    /// This is an improved implementation of the the method known as Carmack's inverse square root
    /// which is found in the Quake III source code. This implementation comes from
    /// http://www.codemaestro.com/reviews/review00000105.html. For the history of this method, see
    /// http://www.beyond3d.com/content/articles/8/.
    /// </remarks>
    [Pure]
    public static float InverseSqrtFast(float x)
    {
        unsafe
        {
            var xHalf = 0.5f * x;
            var i = *(int*)&x; // Read bits as integer.
            i = 0x5f375a86 - (i >> 1); // Make an initial guess for Newton-Raphson approximation
            x = *(float*)&i; // Convert bits back to float
            x = x * (1.5f - xHalf * x * x); // Perform left single Newton-Raphson step.
            return x;
        }
    }

    /// <summary>
    /// Returns an approximation of the inverse square root of left number.
    /// </summary>
    /// <param name="x">A number.</param>
    /// <returns>An approximation of the inverse square root of the specified number, with an upper error bound of 0.001.</returns>
    /// <remarks>
    /// This is an improved implementation of the the method known as Carmack's inverse square root
    /// which is found in the Quake III source code. This implementation comes from
    /// http://www.codemaestro.com/reviews/review00000105.html. For the history of this method, see
    /// http://www.beyond3d.com/content/articles/8/.
    /// double magic number from: https://cs.uwaterloo.ca/~m32rober/rsqrt.pdf
    /// chapter 4.8.
    /// </remarks>
    [Pure]
    public static double InverseSqrtFast(double x)
    {
        unsafe
        {
            var xHalf = 0.5 * x;
            var i = *(long*)&x; // Read bits as long.
            i = 0x5fe6eb50c7b537a9 - (i >> 1); // Make an initial guess for Newton-Raphson approximation
            x = *(double*)&i; // Convert bits back to double
            x = x * (1.5 - xHalf * x * x); // Perform left single Newton-Raphson step.
            return x;
        }
    }

    /// <summary>
    /// Convert degrees to radians.
    /// </summary>
    /// <param name="degrees">An angle in degrees.</param>
    /// <returns>The angle expressed in radians.</returns>
    [Pure]
    public static float DegreesToRadians(float degrees)
    {
        const float degToRad = MathF.PI / 180.0f;
        return degrees * degToRad;
    }

    /// <summary>
    /// Convert radians to degrees.
    /// </summary>
    /// <param name="radians">An angle in radians.</param>
    /// <returns>The angle expressed in degrees.</returns>
    [Pure]
    public static float RadiansToDegrees(float radians)
    {
        const float radToDeg = 180.0f / MathF.PI;
        return radians * radToDeg;
    }

    /// <summary>
    /// Convert degrees to radians.
    /// </summary>
    /// <param name="degrees">An angle in degrees.</param>
    /// <returns>The angle expressed in radians.</returns>
    [Pure]
    public static double DegreesToRadians(double degrees)
    {
        const double degToRad = System.Math.PI / 180.0;
        return degrees * degToRad;
    }

    /// <summary>
    /// Convert radians to degrees.
    /// </summary>
    /// <param name="radians">An angle in radians.</param>
    /// <returns>The angle expressed in degrees.</returns>
    [Pure]
    public static double RadiansToDegrees(double radians)
    {
        const double radToDeg = 180.0 / System.Math.PI;
        return radians * radToDeg;
    }

    /// <summary>
    /// Linearly interpolates between a and b by t.
    /// </summary>
    /// <param name="start">Start value.</param>
    /// <param name="end">End value.</param>
    /// <param name="t">Value of the interpolation between a and b. Clamped to [0, 1].</param>
    /// <returns>The interpolated result between the a and b values.</returns>
    [Pure]
    public static float Lerp(float start, float end, float t)
    {
        t = System.Math.Clamp(t, 0, 1);
        return start + t * (end - start);
    }

    /// <summary>
    /// Linearly interpolates between a and b by t.
    /// </summary>
    /// <param name="start">Start value.</param>
    /// <param name="end">End value.</param>
    /// <param name="t">Value of the interpolation between a and b. Clamped to [0, 1].</param>
    /// <returns>The interpolated result between the a and b values.</returns>
    [Pure]
    public static double Lerp(double start, double end, double t)
    {
        t = System.Math.Clamp(t, 0, 1);
        return start + t * (end - start);
    }

    /// <summary>
    /// Linearly interpolates between a and b by t.
    /// </summary>
    /// <param name="a">Start value.</param>
    /// <param name="b">End value.</param>
    /// <param name="t">Value of the interpolation between a and b. Clamped to [0, 1].</param>
    /// <returns>The interpolated result between the a and b values.</returns>
    /// [Pure]
    public static float LerpClamped(float a, float b, float t)
    {
        return (float)(a + (b - a) * Clamp01(t));
    }

    /// <summary>
    /// Normalizes an angle to the range (-180, 180].
    /// </summary>
    /// <param name="angle">The angle in degrees to normalize.</param>
    /// <returns>The normalized angle in the range (-180, 180].</returns>
    public static float NormalizeAngle(float angle)
    {
        // returns angle in the range [0, 360)
        angle = ClampAngle(angle);

        if (angle > 180f)
            // shift angle to range (-180, 180]
            angle -= 360f;

        return angle;
    }

    /// <summary>
    /// Normalizes an angle to the range (-180, 180].
    /// </summary>
    /// <param name="angle">The angle in degrees to normalize.</param>
    /// <returns>The normalized angle in the range (-180, 180].</returns>
    public static double NormalizeAngle(double angle)
    {
        // returns angle in the range [0, 360)
        angle = ClampAngle(angle);

        if (angle > 180f)
            // shift angle to range (-180, 180]
            angle -= 360f;

        return angle;
    }

    /// <summary>
    /// Normalizes an angle to the range (-π, π].
    /// </summary>
    /// <param name="angle">The angle in radians to normalize.</param>
    /// <returns>The normalized angle in the range (-π, π].</returns>
    public static float NormalizeRadians(float angle)
    {
        // returns angle in the range [0, 2π).
        angle = ClampRadians(angle);

        if (angle > Pi)
            // shift angle to range (-π, π]
            angle -= 2 * Pi;

        return angle;
    }

    /// <summary>
    /// Normalizes an angle to the range (-π, π].
    /// </summary>
    /// <param name="angle">The angle in radians to normalize.</param>
    /// <returns>The normalized angle in the range (-π, π].</returns>
    public static double NormalizeRadians(double angle)
    {
        // returns angle in the range [0, 2π).
        angle = ClampRadians(angle);

        if (angle > Pi)
            // shift angle to range (-π, π]
            angle -= 2 * Pi;

        return angle;
    }

    /// <summary>
    /// Clamps an angle to the range [0, 360).
    /// </summary>
    /// <param name="angle">The angle to clamp in degrees.</param>
    /// <returns>The clamped angle in the range [0, 360).</returns>
    public static float ClampAngle(float angle)
    {
        // mod angle so it's in the range (-360, 360)
        angle %= 360f;

        if (angle < 0.0f)
            // shift angle to the range [0, 360)
            angle += 360f;

        return angle;
    }

    /// <summary>
    /// Clamps an angle to the range [0, 360).
    /// </summary>
    /// <param name="angle">The angle to clamp in degrees.</param>
    /// <returns>The clamped angle in the range [0, 360).</returns>
    public static double ClampAngle(double angle)
    {
        // mod angle so it's in the range (-360, 360)
        angle %= 360d;

        if (angle < 0.0d)
            // shift angle to the range [0, 360)
            angle += 360d;

        return angle;
    }

    /// <summary>
    /// Clamps an angle to the range [0, 2π).
    /// </summary>
    /// <param name="angle">The angle to clamp in radians.</param>
    /// <returns>The clamped angle in the range [0, 2π).</returns>
    public static float ClampRadians(float angle)
    {
        // mod angle so it's in the range (-2π,2π)
        angle %= TwoPi;

        if (angle < 0.0f)
            // shift angle to the range [0,2π)
            angle += TwoPi;

        return angle;
    }


    /// <summary>
    /// Clamps an angle to the range [0, 2π).
    /// </summary>
    /// <param name="angle">The angle to clamp in radians.</param>
    /// <returns>The clamped angle in the range [0, 2π).</returns>
    public static double ClampRadians(double angle)
    {
        // mod angle so it's in the range (-2π,2π)
        angle %= 2d * System.Math.PI;

        if (angle < 0.0d)
            // shift angle to the range [0,2π)
            angle += 2d * System.Math.PI;

        return angle;
    }

    /// <summary>
    /// Approximates floating point equality with a maximum number of different bits.
    /// This is typically used in place of an epsilon comparison.
    /// see: https://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
    /// see: https://stackoverflow.com/questions/3874627/floating-point-comparison-functions-for-c-sharp.
    /// </summary>
    /// <param name="a">the first value to compare.</param>
    /// <param name="b">>the second value to compare.</param>
    /// <param name="maxDeltaBits">the number of floating point bits to check.</param>
    /// <returns>true if the values are approximately equal; otherwise, false.</returns>
    [Pure]
    public static bool ApproximatelyEqual(float a, float b, int maxDeltaBits)
    {
        // we use longs here, otherwise we run into a two's complement problem, causing this to fail with -2 and 2.0
        long k = BitConverter.SingleToInt32Bits(a);
        if (k < 0) k = int.MinValue - k;

        long l = BitConverter.SingleToInt32Bits(b);
        if (l < 0) l = int.MinValue - l;

        var intDiff = System.Math.Abs(k - l);
        return intDiff <= 1 << maxDeltaBits;
    }

    /// <summary>
    /// Approximates double-precision floating point equality by an epsilon (maximum error) value.
    /// This method is designed as a "fits-all" solution and attempts to handle as many cases as possible.
    /// </summary>
    /// <param name="a">The first float.</param>
    /// <param name="b">The second float.</param>
    /// <param name="error">The maximum error between the two.</param>
    /// <returns>
    ///  <value>true</value> if the values are approximately equal within the error margin; otherwise,
    /// <value>false</value>.
    /// </returns>
    [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator", Justification = "Used for early bailout.")]
    [Pure]
    public static bool ApproximatelyEqualEpsilon(double a, double b, double error)
    {
        const double doubleNormal = (1L << 52) * double.Epsilon;
        var absA = System.Math.Abs(a);
        var absB = System.Math.Abs(b);
        var diff = System.Math.Abs(a - b);

        if (a == b)
            // Shortcut, handles infinities
            return true;

        if (a == 0.0f || b == 0.0f || diff < doubleNormal)
            // a or b is zero, or both are extremely close to it.
            // relative error is less meaningful here
            return diff < error * doubleNormal;

        // use relative error
        return diff / System.Math.Min(absA + absB, double.MaxValue) < error;
    }

    /// <summary>
    /// Approximates single-precision floating point equality by an epsilon (maximum error) value.
    /// This method is designed as a "fits-all" solution and attempts to handle as many cases as possible.
    /// </summary>
    /// <param name="a">The first float.</param>
    /// <param name="b">The second float.</param>
    /// <param name="error">The maximum error between the two.</param>
    /// <returns>
    ///  <value>true</value> if the values are approximately equal within the error margin; otherwise,
    ///  <value>false</value>.
    /// </returns>
    [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator", Justification = "Used for early bailout.")]
    [Pure]
    public static bool ApproximatelyEqualEpsilon(float a, float b, float error)
    {
        const float floatNormal = (1 << 23) * float.Epsilon;
        var absA = System.Math.Abs(a);
        var absB = System.Math.Abs(b);
        var diff = System.Math.Abs(a - b);

        if (a == b)
            // Shortcut, handles infinities
            return true;

        if (a == 0.0f || b == 0.0f || diff < floatNormal)
            // a or b is zero, or both are extremely close to it.
            // relative error is less meaningful here
            return diff < error * floatNormal;

        // use relative error
        var relativeError = diff / System.Math.Min(absA + absB, float.MaxValue);
        return relativeError < error;
    }

    /// <summary>
    /// Approximates equivalence between two single-precision floating-point numbers on a direct human scale.
    /// It is important to note that this does not approximate equality - instead, it merely checks whether or not
    /// two numbers could be considered equivalent to each other within a certain tolerance. The tolerance is
    /// inclusive.
    /// </summary>
    /// <param name="a">The first value to compare.</param>
    /// <param name="b">The second value to compare.</param>
    /// <param name="tolerance">The tolerance within which the two values would be considered equivalent.</param>
    /// <returns>Whether or not the values can be considered equivalent within the tolerance.</returns>
    [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator", Justification = "Used for early bailout.")]
    [Pure]
    public static bool ApproximatelyEquivalent(float a, float b, float tolerance)
    {
        if (a == b)
            // Early bailout, handles infinities
            return true;

        var diff = System.Math.Abs(a - b);
        return diff <= tolerance;
    }

    /// <summary>
    /// Approximates equivalence between two double-precision floating-point numbers on a direct human scale.
    /// It is important to note that this does not approximate equality - instead, it merely checks whether or not
    /// two numbers could be considered equivalent to each other within a certain tolerance. The tolerance is
    /// inclusive.
    /// </summary>
    /// <param name="a">The first value to compare.</param>
    /// <param name="b">The second value to compare.</param>
    /// <param name="tolerance">The tolerance within which the two values would be considered equivalent.</param>
    /// <returns>Whether or not the values can be considered equivalent within the tolerance.</returns>
    [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator", Justification = "Used for early bailout.")]
    [Pure]
    public static bool ApproximatelyEquivalent(double a, double b, double tolerance)
    {
        if (a == b)
            // Early bailout, handles infinities
            return true;

        var diff = System.Math.Abs(a - b);
        return diff <= tolerance;
    }

    /// <summary>
    /// Calculates the factorial of a given natural number.
    /// </summary>
    /// <param name="n">The number.</param>
    /// <returns>The factorial of <paramref name="n"/>.</returns>
    [Pure]
    public static long Factorial(int n)
    {
        long result = 1;

        for (; n > 1; n--) result *= n;

        return result;
    }

    /// <summary>
    /// Calculates the binomial coefficient <paramref name="n"/> above <paramref name="k"/>.
    /// </summary>
    /// <param name="n">The n.</param>
    /// <param name="k">The k.</param>
    /// <returns>n! / (k! * (n - k)!).</returns>
    [Pure]
    public static long BinomialCoefficient(int n, int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
    }
}
