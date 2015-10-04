using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrices;

namespace Matrix_Test.cs {
    [TestClass]
    public class Matrix_Test {

        #region Constructor_Test

        [TestMethod]
        public void Matrix_NxNConstructor_CorrectSize() {
            Matrix matrix = new Matrix(3);
            Assert.AreEqual(3, matrix.NumRows);
            Assert.AreEqual(3, matrix.NumColumns);
            Assert.AreEqual(3, matrix.Data.GetLength(0));
            Assert.AreEqual(3, matrix.Data.GetLength(1));
        }

        [TestMethod]
        public void Matrix_NxNConstructor_AllZeros() {
            Matrix matrix = new Matrix(2);
            Assert.AreEqual(0, matrix[1, 1]);
            Assert.AreEqual(0, matrix[1, 2]);
            Assert.AreEqual(0, matrix[2, 1]);
            Assert.AreEqual(0, matrix[2, 2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Matrix_NxNConstructor_NonPositiveDimension_ThrowsException() {
            Matrix matrix = new Matrix(0);
        }

        [TestMethod]
        public void Matrix_MxNConstructor_CorrectSize() {
            Matrix matrix = new Matrix(3, 4);
            Assert.AreEqual(3, matrix.NumRows);
            Assert.AreEqual(4, matrix.NumColumns);
            Assert.AreEqual(3, matrix.Data.GetLength(0));
            Assert.AreEqual(4, matrix.Data.GetLength(1));
        }

        [TestMethod]
        public void Matrix_MxNConstructor_AllZeros() {
            Matrix matrix = new Matrix(2, 3);
            Assert.AreEqual(0, matrix[1, 1]);
            Assert.AreEqual(0, matrix[1, 2]);
            Assert.AreEqual(0, matrix[1, 3]);
            Assert.AreEqual(0, matrix[2, 1]);
            Assert.AreEqual(0, matrix[2, 2]);
            Assert.AreEqual(0, matrix[2, 3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Matrix_MxNConstructor_NonPositiveDimension_ThrowsException() {
            Matrix matrix = new Matrix(2, 0);
        }

        [TestMethod]
        public void Matrix_2DArrayConstructor_CorrectSize() {
            float[,] array = new float[,] { { 4, 2, 3 }, { 8, 12, 6.8F } };
            Matrix matrix = new Matrix(array);
            Assert.AreEqual(2, matrix.NumRows);
            Assert.AreEqual(3, matrix.NumColumns);
            Assert.AreEqual(2, matrix.Data.GetLength(0));
            Assert.AreEqual(3, matrix.Data.GetLength(1));
        }

        [TestMethod]
        public void Matrix_2DArrayConstructor_CorrectValues() {
            float[,] array = new float[,] { { 4, 2, 3 }, { 8, 12, 6.8F } };
            Matrix matrix = new Matrix(array);
            Assert.AreEqual(4, matrix[1, 1]);
            Assert.AreEqual(2, matrix[1, 2]);
            Assert.AreEqual(3, matrix[1, 3]);
            Assert.AreEqual(8, matrix[2, 1]);
            Assert.AreEqual(12, matrix[2, 2]);
            Assert.AreEqual(6.8F, matrix[2, 3]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Matrix_2DArrayConstructor_EmptyArray_ThrowsException() {
            float[,] array = new float[0, 0];
            Matrix matrix = new Matrix(array);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Matrix_2DArrayConstructor_NullArray_ThrowsException() {
            float[,] array = null;
            Matrix matrix = new Matrix(array);
        }

        #endregion

        #region Equals_Test

        [TestMethod]
        public void Matrix_SameObject_EqualsTrue() {
            float[,] array = new float[,] { { 4, 2, 3 }, { 8, 12, 6.8F } };
            Matrix matrix = new Matrix(array);
            Assert.IsTrue(matrix == matrix);
        }

        [TestMethod]
        public void Matrix_SameValues_EqualsTrue1() {
            Matrix matrix = new Matrix(4, 5);
            Matrix matrix2 = new Matrix(4, 5);
            Assert.IsTrue(matrix == matrix2);
        }

        [TestMethod]
        public void Matrix_SameValues_EqualsTrue2() {
            float[,] array = new float[,] { { 4, 2, 3 }, { 8, 12, 6.8F } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array);
            Assert.IsTrue(matrix == matrix2);
        }

        [TestMethod]
        public void Matrix_BothNull_EqualsTrue() {
            Matrix matrix = null;
            Matrix matrix2 = null;
            Assert.IsTrue(matrix == matrix2);
        }

        [TestMethod]
        public void Matrix_FirstNull_EqualsFalse() {
            Matrix matrix = null;
            Matrix matrix2 = new Matrix(3);
            Assert.IsFalse(matrix == matrix2);
        }

        [TestMethod]
        public void Matrix_SecondNull_EqualsFalse() {
            Matrix matrix = new Matrix(3);
            Matrix matrix2 = null;
            Assert.IsFalse(matrix == matrix2);
        }

        [TestMethod]
        public void Matrix_DifferentSizes_EqualsFalse1() {
            Matrix matrix = new Matrix(4, 3);
            Matrix matrix2 = new Matrix(3, 4);
            Assert.IsFalse(matrix == matrix2);
        }

        [TestMethod]
        public void Matrix_DifferentSizes_EqualsFalse2() {
            Matrix matrix = new Matrix(3);
            Matrix matrix2 = new Matrix(4);
            Assert.IsFalse(matrix == matrix2);
        }

        [TestMethod]
        public void Matrix_DifferentSizes_EqualsFalse3() {
            Matrix matrix = new Matrix(17, 1);
            Matrix matrix2 = new Matrix(18, 1);
            Assert.IsFalse(matrix == matrix2);
        }

        [TestMethod]
        public void Matrix_DifferentValues_EqualsFalse1() {
            float[,] array = new float[,] { { 4, 2, 3 }, { 8, 12, 6.8F } };
            float[,] array2 = new float[,] { { 4, 1, 3 }, { 8, 12, 6.8F } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Assert.IsFalse(matrix == matrix2);
        }

        [TestMethod]
        public void Matrix_DifferentValues_EqualsFalse2() {
            float[,] array = new float[,] { { 4 }, { 2 }, { 3 } };
            float[,] array2 = new float[,] { { 4 }, { 2 }, { 2 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Assert.IsFalse(matrix == matrix2);
        }

        #endregion

        #region Add_Test

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Matrix_NullsAdded_ThrowsException() {
            Matrix matrix = null;
            Matrix matrix2 = null;
            Matrix matrix3 = matrix + matrix2;
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Matrix_OneNullAdded_ThrowsException() {
            Matrix matrix = null;
            Matrix matrix2 = new Matrix(3);
            Matrix matrix3 = matrix + matrix2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Matrix_DifferentSizes_ThrowsException() {
            Matrix matrix = new Matrix(4, 5);
            Matrix matrix2 = new Matrix(4);
            Matrix matrix3 = matrix + matrix2;
        }

        [TestMethod]
        public void Matrix_ZeroMatrices_ResultZeros() {
            Matrix matrix = new Matrix(3);
            Matrix matrix2 = new Matrix(3);
            Assert.IsTrue(matrix == matrix + matrix2);
        }

        [TestMethod]
        public void Matrix_ZeroPlusMatrix_ResultsUnchanged() {
            float[,] array = new float[,] { { 1, 2, 3 }, 
                                            { 4, 5, 6 }, 
                                            { 7, 8, 9 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(3);
            Assert.IsTrue(matrix == matrix + matrix2);
        }

        [TestMethod]
        public void Matrix_ValidMatrices_ResultsCorrect1() {
            float[,] array = new float[,] { { 3, 8, 4.5F } };
            float[,] array2 = new float[,] { { 1, 1, 1 } };
            float[,] array3 = new float[,] { { 4, 9, 5.5F } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Matrix matrix3 = new Matrix(array3);
            Assert.AreEqual(matrix3, matrix + matrix2);
        }

        [TestMethod]
        public void Matrix_ValidMatrices_ResultsCorrect2() {
            float[,] array = new float[,] { { 1, 2, 3, 1.5F }, 
                                            { 4, 5, 6, 4.5F }, 
                                            { 7, 8, 9, 7.5F } };
            float[,] array2 = new float[,] { { 1, 2,  3,  4 }, 
                                             { 5, 6,  7,  8 }, 
                                             { 9, 10, 11, 12 } };
            float[,] array3 = new float[,] { { 2,  4,  6,  5.5F }, 
                                             { 9,  11, 13, 12.5F }, 
                                             { 16, 18, 20, 19.5F } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Matrix matrix3 = new Matrix(array3);
            Assert.AreEqual(matrix3, matrix + matrix2);
        }

        #endregion

        #region Multiply_Test

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Matrix_NullMultiplier_ThrowsException() {
            Matrix matrix = null;
            Matrix matrix2 = 2 * matrix;
        }

        [TestMethod]
        public void Matrix_ZeroConstant_ReturnsZeroMatrix() {
            float[,] array = new float[,] { { 1, 2, 3 }, 
                                            { 4, 5, 6 }, 
                                            { 7, 8, 9 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(3);
            Assert.AreEqual(matrix2, 0 * matrix);
        }

        [TestMethod]
        public void Matrix_ValidMatrixPositiveConstant_CorrectResult() {
            float[,] array = new float[,] { { 1, 2, 3 }, 
                                            { 4, 5, 6 }, 
                                            { 7, 8, 9 } };
            float[,] array2 = new float[,] { { 2,  4,  6 }, 
                                             { 8,  10, 12 }, 
                                             { 14, 16, 18 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Assert.AreEqual(matrix2, 2 * matrix);
        }

        [TestMethod]
        public void Matrix_ValidMatrixNegativeConstant_CorrectResult() {
            float[,] array = new float[,] { { 1, 2, 3, 1 }, 
                                            { 4, 5, 6, 4 }, 
                                            { 7, 8, 9, 7 } };
            float[,] array2 = new float[,] { { -2,  -4,  -6,  -2 }, 
                                             { -8,  -10, -12, -8 }, 
                                             { -14, -16, -18, -14 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Assert.AreEqual(matrix2, -2 * matrix);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Matrix_OneNullMultiplied_ThrowsException() {
            float[,] array = new float[,] { { 1, 2, 3, 1 }, 
                                            { 4, 5, 6, 4 }, 
                                            { 7, 8, 9, 7 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = null;
            Matrix matrix3 = matrix * matrix2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Matrix_WrongSizesMultiplied_ThrowsException() {
            float[,] array = new float[,] { { 1, 2, 3, 1 }, 
                                            { 4, 5, 6, 4 }, 
                                            { 7, 8, 9, 7 } };
            float[,] array2 = new float[,] { { -2,  -4,  -6,  -2 }, 
                                             { -8,  -10, -12, -8 }, 
                                             { -14, -16, -18, -14 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Matrix matrix3 = matrix * matrix2;
        }

        [TestMethod]
        public void Matrix_ValidMatricesMultiplied_CorrectResult1() {
            float[,] array = new float[,] { { 1, 2, 3 },
                                            { 1, 4, 5 },
                                            { 6, 4, 7 },
                                            { 8, 9, 7 } };
            float[,] array2 = new float[,] { { -2,  -4,  -6,  -2 }, 
                                             { -8,  -10, -12, -8 }, 
                                             { -14, -16, -18, -14 } };
            float[,] array3 = new float[,] { { -60,  -72,  -84,  -60  },
                                             { -104, -124, -144, -104 },
                                             { -142, -176, -210, -142 },
                                             { -186, -234, -282, -186 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Matrix matrix3 = new Matrix(array3);
            Assert.AreEqual(matrix3, matrix * matrix2);
        }

        [TestMethod]
        public void Matrix_ValidMatricesMultiplied_CorrectResult2() {
            float[,] array = new float[,] { { 1, 2, 3, 4, 5 } };
            float[,] array2 = new float[,] { { 1 },
                                             { 2 },
                                             { 3 },
                                             { 4 },
                                             { 5 } };
            float[,] array3 = new float[,] { { 55 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Matrix matrix3 = new Matrix(array3);
            Assert.AreEqual(matrix3, matrix * matrix2);
        }

        #endregion

        #region Hadamard_Test

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Matrix_HadamardNullMatrixArgument_ThrowsException() {
            Matrix matrix = null;
            Matrix matrix2 = new Matrix(3);
            Matrix matrix3 = Matrix.HadamardProduct(matrix, matrix2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Matrix_HadamardDifferentlySizedMatrices_ThrowsException() {
            Matrix matrix = new Matrix(4, 5);
            Matrix matrix2 = new Matrix(4);
            Matrix matrix3 = Matrix.HadamardProduct(matrix, matrix2);
        }

        [TestMethod]
        public void Matrix_HadamardZeroMatrices_ResultZeros() {
            Matrix matrix = new Matrix(3);
            Matrix matrix2 = new Matrix(3);
            Assert.IsTrue(matrix == Matrix.HadamardProduct(matrix, matrix2));
        }

        [TestMethod]
        public void Matrix_HadamardZeroTimesMatrix_ResultZeros() {
            float[,] array = new float[,] { { 1, 2, 3 }, 
                                            { 4, 5, 6 }, 
                                            { 7, 8, 9 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(3);
            Assert.IsTrue(matrix2 == Matrix.HadamardProduct(matrix, matrix2));
        }

        [TestMethod]
        public void Matrix_HadamardValidMatrices_ResultsCorrect1() {
            float[,] array = new float[,] { { 3, 8, 4.5F } };
            float[,] array2 = new float[,] { { 1, 1, 1 } };
            float[,] array3 = new float[,] { { 3, 8, 4.5F } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Matrix matrix3 = new Matrix(array3);
            Assert.AreEqual(matrix3, Matrix.HadamardProduct(matrix, matrix2));
        }

        [TestMethod]
        public void Matrix_HadamardValidMatrices_ResultsCorrect2() {
            float[,] array = new float[,] { { 1, 2, 3, 1.5F }, 
                                            { 4, 5, 6, 4.5F }, 
                                            { 7, 8, 9, 7.5F } };
            float[,] array2 = new float[,] { { 1, 2,  3,  4 }, 
                                             { 5, 6,  7,  8 }, 
                                             { 9, 10, 11, 12 } };
            float[,] array3 = new float[,] { { 1,  4,  9,  6 }, 
                                             { 20,  30, 42, 36 }, 
                                             { 63, 80, 99, 90 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Matrix matrix3 = new Matrix(array3);
            Assert.AreEqual(matrix3, Matrix.HadamardProduct(matrix, matrix2));
        }

        #endregion

        #region Transpose_Test

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Matrix_TransposeNullMatrix_ThrowsException() {
            Matrix matrix = null;
            Matrix matrix2 = Matrix.Transpose(matrix);
        }

        [TestMethod]
        public void Matrix_TransposeSquareZeroMatrix_SameAsOriginalMatrix() {
            Matrix matrix = new Matrix(3);
            Matrix matrix2 = Matrix.Transpose(matrix);
            Assert.AreEqual(matrix, matrix2);
        }

        [TestMethod]
        public void Matrix_TransposeNonSquareMatrix_CorrectSize() {
            Matrix matrix = new Matrix(3, 8);
            Matrix matrix2 = Matrix.Transpose(matrix);
            Assert.AreEqual(8, matrix2.NumRows);
            Assert.AreEqual(3, matrix2.NumColumns);
        }

        [TestMethod]
        public void Matrix_TransposeValidMatrix_CorrectResult1() {
            float[,] array = new float[,] { { 1, 2, 3 } };
            float[,] array2 = new float[,] { { 1 },
                                             { 2 },
                                             { 3 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Assert.AreEqual(matrix2, Matrix.Transpose(matrix));
        }

        [TestMethod]
        public void Matrix_TransposeValidMatrix_CorrectResult2() {
            float[,] array = new float[,] { { 1, 2 },
                                            { 3, 4 }, 
                                            { 5, 6 } };
            float[,] array2 = new float[,] { { 1, 3, 5 }, 
                                             { 2, 4, 6 } };
            Matrix matrix = new Matrix(array);
            Matrix matrix2 = new Matrix(array2);
            Assert.AreEqual(matrix2, Matrix.Transpose(matrix));
        }

        [TestMethod]
        public void Matrix_DoubleTransposition_SameMatrix() {
            float[,] array = new float[,] { { 1, 2 },
                                            { 3, 4 }, 
                                            { 5, 6 } };
            Matrix matrix = new Matrix(array);
            Assert.AreEqual(matrix, Matrix.Transpose(Matrix.Transpose(matrix)));
        }

        #endregion

    }
}
