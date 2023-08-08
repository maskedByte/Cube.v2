/*
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

namespace Engine.Extensions;

public static class ArrayExtensions
{
    /// <summary>
    /// Appends one or more elements to the end of an array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to append to.</param>
    /// <param name="elements">The elements to append.</param>
    public static T[] Append<T>(this T[]? array, params T[] elements)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "The input array must not be null.");
        }

        if (elements == null || elements.Length == 0)
        {
            throw new ArgumentException("The elements to append must not be null or empty.", nameof(elements));
        }

        Array.Resize(ref array, array.Length + elements.Length);
        Array.Copy(elements, 0, array, array.Length - elements.Length, elements.Length);

        return array;
    }

    /// <summary>
    /// Clears all elements in an array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to clear.</param>
    public static void Clear<T>(this T[]? array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "The input array must not be null.");
        }

        Array.Clear(array);
    }

    /// <summary>
    /// Counts the number of occurrences of a value in an array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>The number of occurrences of the value in the array.</returns>
    public static int Count<T>(this T[]? array, T value)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "The input array must not be null.");
        }

        return array.Count(t => EqualityComparer<T>.Default.Equals(t, value));
    }

    /// <summary>
    /// Finds the index of the first occurrence of a value in an array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to search.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>The index of the first occurrence of the value in the array, or -1 if the value is not found.</returns>
    public static int Index<T>(this T[]? array, T value)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "The input array must not be null.");
        }

        for (var i = 0; i < array.Length; i++)
        {
            if (EqualityComparer<T>.Default.Equals(array[i], value))
            {
                return i;
            }
        }

        return -1;
    }

    /// <summary>
    /// Inserts a value into an array at a specified index.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to insert into.</param>
    /// <param name="index">The index at which to insert the value.</param>
    /// <param name="value">The value to insert.</param>
    public static T[] Insert<T>(this T[]? array, int index, T value)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "The input array must not be null.");
        }

        if (index < 0 || index > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index),
                "The index must be within the bounds of the array.");
        }

        Array.Resize(ref array, array.Length + 1);
        Array.Copy(array, index, array, index + 1, array.Length - index - 1);

        array[index] = value;

        return array;
    }

    /// <summary>
    /// Reverts the order of the elements in an array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to revert.</param>
    public static void Revert<T>(this T[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "The input array must not be null.");
        }

        Array.Reverse(array);
    }

    /// <summary>
    /// Removes all occurrences of a specific element from an array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to remove from.</param>
    /// <param name="element">The element to remove.</param>
    public static T[] Remove<T>(this T[] array, T element)
    {
        if (array == null)
        {
            throw new ArgumentNullException(nameof(array), "The input array must not be null.");
        }

        var indices = new List<int>();
        for (var i = 0; i < array.Length; i++)
        {
            if (array[i]!.Equals(element))
            {
                indices.Add(i);
            }
        }

        var removedCount = 0;
        foreach (var index in indices)
        {
            Array.Copy(array, index + 1, array, index - removedCount, array.Length - index - 1);
            removedCount++;
        }

        Array.Resize(ref array, array.Length - indices.Count);

        return array;
    }

    /// <summary>
    /// Determines whether the specified array is null or empty.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="array">The array to check.</param>
    /// <returns>true if the array is null or empty; otherwise, false.</returns>
    public static bool IsNullOrEmpty<T>(this T[]? array)
    {
        return array == null || array.Length == 0;
    }

    /// <summary>
    /// Determines whether the specified array is null or all of its elements are null.
    /// </summary>
    /// <typeparam name="T">The type of the elements in the array.</typeparam>
    /// <param name="array">The array to check.</param>
    /// <returns>true if the array is null or all of its elements are null; otherwise, false.</returns>
    public static bool IsNullOrAllElementsNull<T>(this T[]? array)
    {
        return array == null || array.All(t => t == null);
    }
}
