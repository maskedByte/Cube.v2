using System.Globalization;
using Engine.Core.Math.Matrices;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Extensions;

public static class Extension
{
    /// <summary>
    ///     Extension method for use in foreach to get both (item and index)
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source) =>
        source.Select((item, index) => (item, index));

    /// <summary>
    ///     Create a new instance for a given class name <paramref name="fullName" />
    /// </summary>
    /// <param name="fullName">FullName of the class to create a new instance for</param>
    public static object? GetInstanceFromFullName(this string fullName)
    {
        var type = Type.GetType(fullName);
        if (type != null)
        {
            return Activator.CreateInstance(type);
        }

        foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
        {
            type = asm.GetType(fullName);
            if (type != null)
            {
                return Activator.CreateInstance(type);
            }
        }

        return null;
    }

    /// <summary>
    ///     Add element to <see cref="List{T}" /> and return
    /// </summary>
    /// <param name="list"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T AddReturn<T>(this List<T> list, T value)
    {
        list.Add(value);
        return value;
    }

    #region String conversion

    public static Vector2 ToVector2(this string str)
    {
        var split = str.Split(',');
        return split.Length != 2
            ? Vector2.Zero
            : new Vector2(
                float.Parse(split[0], CultureInfo.InvariantCulture),
                float.Parse(split[1], CultureInfo.InvariantCulture)
            );
    }

    public static Vector3 ToVector3(this string str)
    {
        var split = str.Split(',');
        return split.Length != 3
            ? Vector3.Zero
            : new Vector3(
                float.Parse(split[0], CultureInfo.InvariantCulture),
                float.Parse(split[1], CultureInfo.InvariantCulture),
                float.Parse(split[2], CultureInfo.InvariantCulture)
            );
    }

    public static Vector4 ToVector4(this string str)
    {
        var split = str.Split(',');
        return split.Length != 4
            ? Vector4.Zero
            : new Vector4(
                float.Parse(split[0], CultureInfo.InvariantCulture),
                float.Parse(split[1], CultureInfo.InvariantCulture),
                float.Parse(split[2], CultureInfo.InvariantCulture),
                float.Parse(split[3], CultureInfo.InvariantCulture)
            );
    }

    public static Matrix2 ToMatrix2(this string str) => Matrix2.Zero;

    public static Matrix3 ToMatrix3(this string str) => Matrix3.Zero;

    public static Matrix4 ToMatrix4(this string str) => Matrix4.Zero;

    #endregion
}
