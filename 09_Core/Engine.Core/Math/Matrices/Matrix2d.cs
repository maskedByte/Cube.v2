﻿using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Engine.Core.Math.Vectors;

namespace Engine.Core.Math.Matrices;

/// <summary>
///     Represents a 2x2 matrix.
/// </summary>
[Serializable, StructLayout(LayoutKind.Sequential)]
public struct Matrix2d : IEquatable<Matrix2d>
{
    /// <summary>
    ///     Top row of the matrix.
    /// </summary>
    public Vector2d Row0;

    /// <summary>
    ///     Bottom row of the matrix.
    /// </summary>
    public Vector2d Row1;

    /// <summary>
    ///     The identity matrix.
    /// </summary>
    public static readonly Matrix2d Identity = new(Vector2d.UnitX, Vector2d.UnitY);

    /// <summary>
    ///     The zero matrix.
    /// </summary>
    public static readonly Matrix2d Zero = new(Vector2d.Zero, Vector2d.Zero);

    /// <summary>
    ///     Initializes a new instance of the <see cref="Matrix2d" /> struct.
    /// </summary>
    /// <param name="row0">Top row of the matrix.</param>
    /// <param name="row1">Bottom row of the matrix.</param>
    public Matrix2d(Vector2d row0, Vector2d row1)
    {
        Row0 = row0;
        Row1 = row1;
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="Matrix2d" /> struct.
    /// </summary>
    /// <param name="m00">First item of the first row of the matrix.</param>
    /// <param name="m01">Second item of the first row of the matrix.</param>
    /// <param name="m10">First item of the second row of the matrix.</param>
    /// <param name="m11">Second item of the second row of the matrix.</param>
    [SuppressMessage("ReSharper", "SA1117", Justification = "For better readability of Matrix struct.")]
    public Matrix2d(
        double m00,
        double m01,
        double m10,
        double m11
    )
    {
        Row0 = new Vector2d(m00, m01);
        Row1 = new Vector2d(m10, m11);
    }

    /// <summary>
    ///     Gets the determinant of this matrix.
    /// </summary>
    public double Determinant
    {
        get
        {
            var m11 = Row0.X;
            var m12 = Row0.Y;
            var m21 = Row1.X;
            var m22 = Row1.Y;

            return m11 * m22 - m12 * m21;
        }
    }

    /// <summary>
    ///     Gets or sets the first column of this matrix.
    /// </summary>
    public Vector2d Column0
    {
        get => new(Row0.X, Row1.X);
        set
        {
            Row0.X = value.X;
            Row1.X = value.Y;
        }
    }

    /// <summary>
    ///     Gets or sets the second column of this matrix.
    /// </summary>
    public Vector2d Column1
    {
        get => new(Row0.Y, Row1.Y);
        set
        {
            Row0.Y = value.X;
            Row1.Y = value.Y;
        }
    }

    /// <summary>
    ///     Gets or sets the value at row 1, column 1 of this instance.
    /// </summary>
    public double M11
    {
        get => Row0.X;
        set => Row0.X = value;
    }

    /// <summary>
    ///     Gets or sets the value at row 1, column 2 of this instance.
    /// </summary>
    public double M12
    {
        get => Row0.Y;
        set => Row0.Y = value;
    }

    /// <summary>
    ///     Gets or sets the value at row 2, column 1 of this instance.
    /// </summary>
    public double M21
    {
        get => Row1.X;
        set => Row1.X = value;
    }

    /// <summary>
    ///     Gets or sets the value at row 2, column 2 of this instance.
    /// </summary>
    public double M22
    {
        get => Row1.Y;
        set => Row1.Y = value;
    }

    /// <summary>
    ///     Gets or sets the values along the main diagonal of the matrix.
    /// </summary>
    public Vector2d Diagonal
    {
        get => new(Row0.X, Row1.Y);
        set
        {
            Row0.X = value.X;
            Row1.Y = value.Y;
        }
    }

    /// <summary>
    ///     Gets the trace of the matrix, the sum of the values along the diagonal.
    /// </summary>
    public double Trace => Row0.X + Row1.Y;

    /// <summary>
    ///     Gets or sets the value at a specified row and column.
    /// </summary>
    /// <param name="rowIndex">The index of the row.</param>
    /// <param name="columnIndex">The index of the column.</param>
    /// <returns>The element at the given row and column index.</returns>
    public double this[int rowIndex, int columnIndex]
    {
        get
        {
            if (rowIndex == 0)
            {
                return Row0[columnIndex];
            }

            if (rowIndex == 1)
            {
                return Row1[columnIndex];
            }

            throw new IndexOutOfRangeException("You tried to access this matrix at: (" + rowIndex + ", " + columnIndex + ")");
        }

        set
        {
            if (rowIndex == 0)
            {
                Row0[columnIndex] = value;
            }
            else if (rowIndex == 1)
            {
                Row1[columnIndex] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("You tried to set this matrix at: (" + rowIndex + ", " + columnIndex + ")");
            }
        }
    }

    /// <summary>
    ///     Converts this instance to it's transpose.
    /// </summary>
    public void Transpose() => this = Transpose(this);

    /// <summary>
    ///     Converts this instance into its inverse.
    /// </summary>
    public void Invert() => this = Invert(this);

    /// <summary>
    ///     Builds a rotation matrix.
    /// </summary>
    /// <param name="angle">The counter-clockwise angle in radians.</param>
    /// <param name="result">The resulting Matrix2d instance.</param>
    public static void CreateRotation(double angle, out Matrix2d result)
    {
        var cos = System.Math.Cos(angle);
        var sin = System.Math.Sin(angle);

        result.Row0.X = cos;
        result.Row0.Y = sin;
        result.Row1.X = -sin;
        result.Row1.Y = cos;
    }

    /// <summary>
    ///     Builds a rotation matrix.
    /// </summary>
    /// <param name="angle">The counter-clockwise angle in radians.</param>
    /// <returns>The resulting Matrix2d instance.</returns>
    [Pure]
    public static Matrix2d CreateRotation(double angle)
    {
        CreateRotation(angle, out var result);
        return result;
    }

    /// <summary>
    ///     Creates a scale matrix.
    /// </summary>
    /// <param name="scale">Single scale factor for the x, y, and z axes.</param>
    /// <param name="result">A scale matrix.</param>
    public static void CreateScale(double scale, out Matrix2d result)
    {
        result.Row0.X = scale;
        result.Row0.Y = 0;
        result.Row1.X = 0;
        result.Row1.Y = scale;
    }

    /// <summary>
    ///     Creates a scale matrix.
    /// </summary>
    /// <param name="scale">Single scale factor for the x and y axes.</param>
    /// <returns>A scale matrix.</returns>
    [Pure]
    public static Matrix2d CreateScale(double scale)
    {
        CreateScale(scale, out var result);
        return result;
    }

    /// <summary>
    ///     Creates a scale matrix.
    /// </summary>
    /// <param name="scale">Scale factors for the x and y axes.</param>
    /// <param name="result">A scale matrix.</param>
    public static void CreateScale(Vector2d scale, out Matrix2d result)
    {
        result.Row0.X = scale.X;
        result.Row0.Y = 0;
        result.Row1.X = 0;
        result.Row1.Y = scale.Y;
    }

    /// <summary>
    ///     Creates a scale matrix.
    /// </summary>
    /// <param name="scale">Scale factors for the x and y axes.</param>
    /// <returns>A scale matrix.</returns>
    [Pure]
    public static Matrix2d CreateScale(Vector2d scale)
    {
        CreateScale(scale, out var result);
        return result;
    }

    /// <summary>
    ///     Creates a scale matrix.
    /// </summary>
    /// <param name="x">Scale factor for the x axis.</param>
    /// <param name="y">Scale factor for the y axis.</param>
    /// <param name="result">A scale matrix.</param>
    public static void CreateScale(double x, double y, out Matrix2d result)
    {
        result.Row0.X = x;
        result.Row0.Y = 0;
        result.Row1.X = 0;
        result.Row1.Y = y;
    }

    /// <summary>
    ///     Creates a scale matrix.
    /// </summary>
    /// <param name="x">Scale factor for the x axis.</param>
    /// <param name="y">Scale factor for the y axis.</param>
    /// <returns>A scale matrix.</returns>
    [Pure]
    public static Matrix2d CreateScale(double x, double y)
    {
        CreateScale(x, y, out var result);
        return result;
    }

    /// <summary>
    ///     Multiplies and instance by a scalar.
    /// </summary>
    /// <param name="left">The left operand of the multiplication.</param>
    /// <param name="right">The right operand of the multiplication.</param>
    /// <param name="result">A new instance that is the result of the multiplication.</param>
    public static void Mult(in Matrix2d left, double right, out Matrix2d result)
    {
        result.Row0.X = left.Row0.X * right;
        result.Row0.Y = left.Row0.Y * right;
        result.Row1.X = left.Row1.X * right;
        result.Row1.Y = left.Row1.Y * right;
    }

    /// <summary>
    ///     Multiplies and instance by a scalar.
    /// </summary>
    /// <param name="left">The left operand of the multiplication.</param>
    /// <param name="right">The right operand of the multiplication.</param>
    /// <returns>A new instance that is the result of the multiplication.</returns>
    [Pure]
    public static Matrix2d Mult(Matrix2d left, double right)
    {
        Mult(in left, right, out var result);
        return result;
    }

    /// <summary>
    ///     Multiplies two instances.
    /// </summary>
    /// <param name="left">The left operand of the multiplication.</param>
    /// <param name="right">The right operand of the multiplication.</param>
    /// <param name="result">A new instance that is the result of the multiplication.</param>
    public static void Mult(in Matrix2d left, in Matrix2d right, out Matrix2d result)
    {
        var leftM11 = left.Row0.X;
        var leftM12 = left.Row0.Y;
        var leftM21 = left.Row1.X;
        var leftM22 = left.Row1.Y;
        var rightM11 = right.Row0.X;
        var rightM12 = right.Row0.Y;
        var rightM21 = right.Row1.X;
        var rightM22 = right.Row1.Y;

        result.Row0.X = leftM11 * rightM11 + leftM12 * rightM21;
        result.Row0.Y = leftM11 * rightM12 + leftM12 * rightM22;
        result.Row1.X = leftM21 * rightM11 + leftM22 * rightM21;
        result.Row1.Y = leftM21 * rightM12 + leftM22 * rightM22;
    }

    /// <summary>
    ///     Multiplies two instances.
    /// </summary>
    /// <param name="left">The left operand of the multiplication.</param>
    /// <param name="right">The right operand of the multiplication.</param>
    /// <returns>A new instance that is the result of the multiplication.</returns>
    [Pure]
    public static Matrix2d Mult(Matrix2d left, Matrix2d right)
    {
        Mult(in left, in right, out var result);
        return result;
    }

    /// <summary>
    ///     Adds two instances.
    /// </summary>
    /// <param name="left">The left operand of the addition.</param>
    /// <param name="right">The right operand of the addition.</param>
    /// <param name="result">A new instance that is the result of the addition.</param>
    public static void Add(in Matrix2d left, in Matrix2d right, out Matrix2d result)
    {
        result.Row0.X = left.Row0.X + right.Row0.X;
        result.Row0.Y = left.Row0.Y + right.Row0.Y;
        result.Row1.X = left.Row1.X + right.Row1.X;
        result.Row1.Y = left.Row1.Y + right.Row1.Y;
    }

    /// <summary>
    ///     Adds two instances.
    /// </summary>
    /// <param name="left">The left operand of the addition.</param>
    /// <param name="right">The right operand of the addition.</param>
    /// <returns>A new instance that is the result of the addition.</returns>
    [Pure]
    public static Matrix2d Add(Matrix2d left, Matrix2d right)
    {
        Add(in left, in right, out var result);
        return result;
    }

    /// <summary>
    ///     Subtracts two instances.
    /// </summary>
    /// <param name="left">The left operand of the subtraction.</param>
    /// <param name="right">The right operand of the subtraction.</param>
    /// <param name="result">A new instance that is the result of the subtraction.</param>
    public static void Subtract(in Matrix2d left, in Matrix2d right, out Matrix2d result)
    {
        result.Row0.X = left.Row0.X - right.Row0.X;
        result.Row0.Y = left.Row0.Y - right.Row0.Y;
        result.Row1.X = left.Row1.X - right.Row1.X;
        result.Row1.Y = left.Row1.Y - right.Row1.Y;
    }

    /// <summary>
    ///     Subtracts two instances.
    /// </summary>
    /// <param name="left">The left operand of the subtraction.</param>
    /// <param name="right">The right operand of the subtraction.</param>
    /// <returns>A new instance that is the result of the subtraction.</returns>
    [Pure]
    public static Matrix2d Subtract(Matrix2d left, Matrix2d right)
    {
        Subtract(in left, in right, out var result);
        return result;
    }

    /// <summary>
    ///     Calculate the inverse of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix to invert.</param>
    /// <param name="result">The inverse of the given matrix if it has one, or the input if it is singular.</param>
    /// <exception cref="InvalidOperationException">Thrown if the Matrix2d is singular.</exception>
    public static void Invert(in Matrix2d mat, out Matrix2d result)
    {
        var det = mat.Row0.X * mat.Row1.Y - mat.Row0.Y * mat.Row1.X;

        if (det == 0)
        {
            throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
        }

        var invDet = 1f / det;

        // Because the c# jit assumes alias for byref types we need to
        // save this value as the write to result.Row0.X could change the
        // value of mat.Row0.X.
        var row0X = mat.Row0.X;

        result.Row0.X = mat.Row1.Y * invDet;
        result.Row0.Y = -mat.Row0.Y * invDet;
        result.Row1.X = -mat.Row1.X * invDet;
        result.Row1.Y = row0X * invDet;
    }

    /// <summary>
    ///     Calculate the inverse of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix to invert.</param>
    /// <returns>The inverse of the given matrix.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the Matrix2d is singular.</exception>
    /// <returns>The inverted copy.</returns>
    [Pure]
    public static Matrix2d Invert(Matrix2d mat)
    {
        Invert(in mat, out var result);
        return result;
    }

    /// <summary>
    ///     Calculate the transpose of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix to transpose.</param>
    /// <param name="result">The transpose of the given matrix.</param>
    public static void Transpose(in Matrix2d mat, out Matrix2d result)
    {
        result.Row0.X = mat.Row0.X;
        result.Row0.Y = mat.Row1.X;
        result.Row1.X = mat.Row0.Y;
        result.Row1.Y = mat.Row1.Y;
    }

    /// <summary>
    ///     Calculate the transpose of the given matrix.
    /// </summary>
    /// <param name="mat">The matrix to transpose.</param>
    /// <returns>The transpose of the given matrix.</returns>
    [Pure]
    public static Matrix2d Transpose(Matrix2d mat)
    {
        Transpose(in mat, out var result);
        return result;
    }

    /// <summary>
    ///     Scalar multiplication.
    /// </summary>
    /// <param name="left">left-hand operand.</param>
    /// <param name="right">right-hand operand.</param>
    /// <returns>A new Matrix2d which holds the result of the multiplication.</returns>
    [Pure]
    public static Matrix2d operator *(double left, Matrix2d right) => Mult(right, left);

    /// <summary>
    ///     Scalar multiplication.
    /// </summary>
    /// <param name="left">left-hand operand.</param>
    /// <param name="right">right-hand operand.</param>
    /// <returns>A new Matrix2d which holds the result of the multiplication.</returns>
    [Pure]
    public static Matrix2d operator *(Matrix2d left, double right) => Mult(left, right);

    /// <summary>
    ///     Matrix multiplication.
    /// </summary>
    /// <param name="left">left-hand operand.</param>
    /// <param name="right">right-hand operand.</param>
    /// <returns>A new Matrix2d which holds the result of the multiplication.</returns>
    [Pure]
    public static Matrix2d operator *(Matrix2d left, Matrix2d right) => Mult(left, right);

    /// <summary>
    ///     Matrix addition.
    /// </summary>
    /// <param name="left">left-hand operand.</param>
    /// <param name="right">right-hand operand.</param>
    /// <returns>A new Matrix2d which holds the result of the addition.</returns>
    [Pure]
    public static Matrix2d operator +(Matrix2d left, Matrix2d right) => Add(left, right);

    /// <summary>
    ///     Matrix subtraction.
    /// </summary>
    /// <param name="left">left-hand operand.</param>
    /// <param name="right">right-hand operand.</param>
    /// <returns>A new Matrix2d which holds the result of the subtraction.</returns>
    [Pure]
    public static Matrix2d operator -(Matrix2d left, Matrix2d right) => Subtract(left, right);

    /// <summary>
    ///     Compares two instances for equality.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>True, if left equals right; false otherwise.</returns>
    [Pure]
    public static bool operator ==(Matrix2d left, Matrix2d right) => left.Equals(right);

    /// <summary>
    ///     Compares two instances for inequality.
    /// </summary>
    /// <param name="left">The first instance.</param>
    /// <param name="right">The second instance.</param>
    /// <returns>True, if left does not equal right; false otherwise.</returns>
    [Pure]
    public static bool operator !=(Matrix2d left, Matrix2d right) => !left.Equals(right);

    /// <summary>
    ///     Returns a System.String that represents the current Matrix4.
    /// </summary>
    /// <returns>The string representation of the matrix.</returns>
    public override string ToString() => $"{Row0}\n{Row1}";

    /// <summary>
    ///     Returns the hashcode for this instance.
    /// </summary>
    /// <returns>A System.Int32 containing the unique hashcode for this instance.</returns>
    public override int GetHashCode() => HashCode.Combine(Row0, Row1);

    /// <summary>
    ///     Indicates whether this instance and a specified object are equal.
    /// </summary>
    /// <param name="obj">The object to compare to.</param>
    /// <returns>True if the instances are equal; false otherwise.</returns>
    [Pure]
    public override bool Equals(object? obj) => obj is Matrix2d matrix2d && Equals(matrix2d);

    /// <summary>
    ///     Indicates whether the current matrix is equal to another matrix.
    /// </summary>
    /// <param name="other">An matrix to compare with this matrix.</param>
    /// <returns>true if the current matrix is equal to the matrix parameter; otherwise, false.</returns>
    [Pure]
    public bool Equals(Matrix2d other) => Row0 == other.Row0 && Row1 == other.Row1;
}
