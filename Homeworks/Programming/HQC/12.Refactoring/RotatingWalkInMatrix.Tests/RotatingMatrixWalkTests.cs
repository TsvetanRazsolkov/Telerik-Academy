namespace RotatingWalkInMatrix.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.IO;

    [TestClass]
    public class RotatingMatrixWalkTests
    {
        private string expectedConsoleOutputCorrectInput7;
        private string expectedConsoleOutputIncorrectInput;
        private int[,] matrixLength1;
        private int[,] matrixLength2;
        private int[,] matrixLength3;
        private int[,] matrixLength4;
        private int[,] matrixLength6;

        [TestInitialize]
        public void InitializeExpectedAnswers()
        {
            expectedConsoleOutputCorrectInput7 = "Enter a positive integer\r\n" +
                                "  1 19 20 21 22 23 24\r\n" +
                                " 18  2 33 34 35 36 25\r\n" +
                                " 17 40  3 32 39 37 26\r\n" +
                                " 16 48 41  4 31 38 27\r\n" +
                                " 15 47 49 42  5 30 28\r\n" +
                                " 14 46 45 44 43  6 29\r\n" +
                                " 13 12 11 10  9  8  7\r\n";

            expectedConsoleOutputIncorrectInput = "Enter a positive integer\r\n" +
                            "You haven't entered a correct positive integer\r\n" +
                            "Enter a positive integer\r\n" + 
                            "You haven't entered a correct positive integer\r\n" +
                            "Enter a positive integer\r\n" + 
                            "  1\r\n";

            matrixLength1 = new int[,] { { 1 } };

            matrixLength2 = new int[,] {{1, 4},
                                        {3, 2}};

            matrixLength3 = new int[,] {{1, 7, 8},
                                        {6, 2, 9},
                                        {5, 4, 3}};

            matrixLength4 = new int[,] {{1,10, 11, 12},
                                        {9, 2, 15, 13},
                                        {8, 16, 3, 14},
                                        {7, 6, 5, 4}};

            matrixLength6 = new int[,] {{1,16,17,18,19,20},
                                        {15,2,27,28,29,21},
                                        {14,31,3,26,30,22},
                                        {13,36,32,4,25,23},
                                        {12,35,34,33,5,24},
                                        {11,10,9,8,7,6}};
        }

        [TestMethod]
        public void ExpectRotatingWalkExampleToGiveAdequateConsoleOutput_WithCorrectInput()
        {
            using (StringReader input = new StringReader("7"))
            {
                Console.SetIn(input);
                using (StringWriter output = new StringWriter())
                {
                    Console.SetOut(output);

                    RotatingWalkExample.Main();

                    Assert.AreEqual(expectedConsoleOutputCorrectInput7, output.ToString());
                }
            }
        }

        [TestMethod]
        public void ExpectRotatingWalkExampleToGiveAdequateConsoleOutput_WithIncorrectInput()
        {
            using (StringReader input = new StringReader("-3\n101\n1\n"))
            {
                Console.SetIn(input);
                using (StringWriter output = new StringWriter())
                {
                    Console.SetOut(output);

                    RotatingWalkExample.Main();

                    Assert.AreEqual(expectedConsoleOutputIncorrectInput, output.ToString());
                }
            }
        }

        [TestMethod]
        public void RotatingWalkInMatrixWithSize1_ExpectedToWork()
        {
            var expected = matrixLength1;
            var actual = new int[1, 1];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(actual);

            Assert.IsTrue(MatrixComparer.AreSame(expected, actual));
        }

        [TestMethod]
        public void RotatingWalkInMatrixWithSize2_ExpectedToWork()
        {
            var expected = matrixLength2;
            var actual = new int[2, 2];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(actual);

            Assert.IsTrue(MatrixComparer.AreSame(expected, actual));
        }

        [TestMethod]
        public void RotatingWalkInMatrixWithSize3_ExpectedToWork()
        {
            var expected = matrixLength3;
            var actual = new int[3, 3];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(actual);

            Assert.IsTrue(MatrixComparer.AreSame(expected, actual));
        }

        [TestMethod]
        public void RotatingWalkInMatrixWithSize4_ExpectedToWork()
        {
            var expected = matrixLength4;
            var actual = new int[4, 4];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(actual);

            Assert.IsTrue(MatrixComparer.AreSame(expected, actual));
        }

        [TestMethod]
        public void RotatingWalkInMatrixWithSize6_ExpectedToWork()
        {
            var expected = matrixLength6;
            var actual = new int[6, 6];

            RotatingMatrixWalkSolver.SolveRotatingMatrixWalk(actual);

            Assert.IsTrue(MatrixComparer.AreSame(expected, actual));
        }
    }
}
