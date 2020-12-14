using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР_2
{
    public partial class FormWindow : Form
    {
        private Panel lastTask = null;
        private Action solution = null;
        private Random rnd = new Random();

        private enum Animals
        {
            Panda,
            Bear,
            Giraffe,
            Antelope,
            Iguana,
            Hare
        }

        private enum Characteristics
        {
            Courage,
            Kindness,
            Vanity,
            Greed,
            Generosity,
            Fearfulness
        }

        private enum Subject
        {
            DVD_ROM,
            Fireworks,
            Candies,
            Anime,
            TV,
            Rocket
        }

        public FormWindow()
        {
            InitializeComponent();
            SetSizeOfWindow(480, 79);
        }

        private void TaskBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedTask = TaskBox.SelectedIndex;
            switch (selectedTask)
            {
                case 0:
                    solution = HireTeam;
                    SetSizeOfWindow(481, 182);
                    PlacePanelInPosition(Task1, 1, 41);
                    ShowPanel(Task1);
                    break;
                case 1:
                    solution = CompareTriangles;
                    SetSizeOfWindow(480, 215);
                    PlacePanelInPosition(Task2, 1, 41);
                    ShowPanel(Task2);
                    break;
                case 2:
                    solution = SolveTaskAboutCyclists;
                    SetSizeOfWindow(481, 327);
                    PlacePanelInPosition(Task3, 1, 41);
                    ShowPanel(Task3);
                    break;
                case 3:
                    solution = ExchangeMaximumMatrixItems;
                    SetSizeOfWindow(480, 325);
                    PlacePanelInPosition(MatrixTask1, 1, 41);
                    ShowPanel(MatrixTask1);
                    break;
                case 4:
                    solution = ReplaceMaxItemsWithAverage;
                    SetSizeOfWindow(480, 253);
                    PlacePanelInPosition(Task5, 1, 41);
                    ShowPanel(Task5);
                    break;
                case 5:
                    solution = RemoveRowWithMaxDiagonalItem;
                    SetSizeOfWindow(480, 326);
                    PlacePanelInPosition(MatrixTask2, 1, 41);
                    ShowPanel(MatrixTask2);
                    break;
                case 6:
                    solution = ExchangeRowsWithMaxDiagonalItem;
                    SetSizeOfWindow(480, 326);
                    PlacePanelInPosition(MatrixTask2, 1, 41);
                    ShowPanel(MatrixTask2);
                    break;
                case 7:
                    solution = ExchangeMatrixRows;
                    SetSizeOfWindow(480, 325);
                    PlacePanelInPosition(MatrixTask1, 1, 41);
                    ShowPanel(MatrixTask1);
                    break;
                case 8:
                    solution = CombineArraysWithoutMaxItems;
                    SetSizeOfWindow(481, 410);
                    PlacePanelInPosition(Task9, 1, 41);
                    ShowPanel(Task9);
                    break;
                case 9:
                    solution = InsertColumnAsRow;
                    SetSizeOfWindow(480, 357);
                    PlacePanelInPosition(Task10, 1, 41);
                    ShowPanel(Task10);
                    break;
                case 10:
                    solution = SortArrays;
                    SetSizeOfWindow(480, 253);
                    PlacePanelInPosition(Task5, 1, 41);
                    ShowPanel(Task5);
                    break;
                case 11:
                    solution = CreateArrayFromSumOfColumns;
                    SetSizeOfWindow(480, 254);
                    PlacePanelInPosition(Task12, 1, 41);
                    ShowPanel(Task12);
                    break;
                case 12:
                    solution = FindSumsOfFunctions;
                    SetSizeOfWindow(481, 182);
                    PlacePanelInPosition(Task13, 1, 41);
                    ShowPanel(Task13);
                    break;
                case 13:
                    solution = InterviewPeople;
                    SetSizeOfWindow(480, 252);
                    PlacePanelInPosition(Task14, 1, 41);
                    ShowPanel(Task14);
                    break;
                case 14:
                    solution = ExchangeRowsWithMaxNegativeNumbers;
                    SetSizeOfWindow(480, 325);
                    PlacePanelInPosition(MatrixTask1, 1, 41);
                    ShowPanel(MatrixTask1);
                    break;
            }
            Clear();
        }

        private void SetSizeOfWindow(int width, int height)
        {
            this.Width = width;
            this.Height = height;
        }

        private void PlacePanelInPosition(Panel panel, int x, int y)
        {
            panel.Location = new Point(x, y);
        }

        private void ShowPanel(Panel panel)
        {
            if (lastTask != null) lastTask.Visible = false;
            panel.Visible = true;
            lastTask = panel;
        }

        private void Clear()
        {
            foreach (Control control in Controls)
            {
                foreach (TextBox textBox in GetAll<TextBox>(control))
                {
                    textBox.Clear();
                }

                foreach (DataGridView grid in GetAll<DataGridView>(control))
                {
                    grid.Rows.Clear();
                }
            }
        }

        public IEnumerable<Control> GetAll<T>(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll<T>(ctrl))
                           .Concat(controls)
                           .Where(c => c is T);
        }

        private void Solve_Click(object sender, EventArgs e)
        {
            if (solution == null) return;
            solution.Invoke();
        }

        private void HireTeam()
        {
            try
            {
                int candidateNumbers = int.Parse(CandidateNumbers.Text);
                int requiredAmount = int.Parse(RequiredAmount.Text);

                int waysNumber;
                FindNumberOfWays(requiredAmount, candidateNumbers, out waysNumber);
                Ways.Text = waysNumber.ToString();
            }
            catch { }
        } // Main

        private void FindNumberOfWays(int k, int n, out int waysNumber)
        {
            waysNumber = Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        private int Factorial(int n)
        {
            int factorial = 1;
            while (n > 1)
            {
                factorial *= n;
                n--;
            }
            return factorial;
        }

        private void CompareTriangles() // Main
        {
            try
            {
                double firstTriangleA = double.Parse(FirstTriangleA.Text);
                double firstTriangleB = double.Parse(FirstTriangleB.Text);
                double firstTriangleC = double.Parse(FirstTriangleC.Text);
                double firstArea = -1;

                double secondTriangleA = double.Parse(SecondTriangleA.Text);
                double secondTriangleB = double.Parse(SecondTriangleB.Text);
                double secondTriangleC = double.Parse(SecondTriangleC.Text);
                double secondArea = -1;

                FindAreaOfTriangle(firstTriangleA, firstTriangleB, firstTriangleC, out firstArea);
                AreaOfFirstTriangle.Text = firstArea.ToString();
                FindAreaOfTriangle(secondTriangleA, secondTriangleB, secondTriangleC, out secondArea);
                AreaOfSecondTriangle.Text = secondArea.ToString();

                if (firstArea > secondArea) ComparisonResult.Text = "У треугольника A наибольшая площадь!";
                else if (firstArea < secondArea) ComparisonResult.Text = "У треугольника B наибольшая площадь!";
                else ComparisonResult.Text = "Площади треугольников равны!";
            }
            catch { }
        }

        private void FindAreaOfTriangle(double a, double b, double c, out double area)
        {
            double halfOfPerimeter = HalfOfPerimeter(a, b, c);
            area = Math.Sqrt(halfOfPerimeter * (halfOfPerimeter - a) * (halfOfPerimeter - b) * (halfOfPerimeter - c));
        }

        private double HalfOfPerimeter(double a, double b, double c)
        {
            return (a + b + c) / 2;
        }

        private void SolveTaskAboutCyclists()
        {
            try
            {
                double firstSpeed = double.Parse(FirstSpeed.Text);
                double firstAcceleration = double.Parse(FirstAcceleration.Text);
                double firstDistance1 = FindDistance(firstSpeed, firstAcceleration, 1);
                FirstDistance1.Text = firstDistance1.ToString();
                double firstDistance4 = FindDistance(firstSpeed, firstAcceleration, 4);
                FirstDistance4.Text = firstDistance4.ToString();

                double secondSpeed = double.Parse(SecondSpeed.Text);
                double secondAcceleration = double.Parse(SecondAcceleration.Text);
                double secondDistance1 = FindDistance(secondSpeed, secondAcceleration, 1);
                SecondDistance1.Text = secondDistance1.ToString();
                double secondDistance4 = FindDistance(secondSpeed, secondAcceleration, 4);
                SecondDistance4.Text = secondDistance4.ToString();

                if (firstDistance1 > secondDistance1) Answers.Text += "Первый велосипедист преодолел большее расстояние за 1 час! \r\n";
                else if (firstDistance1 < secondDistance1) Answers.Text += "Второй велосипедист преодолел большее расстояние за 1 час! \r\n";
                else Answers.Text += "За первый час езды велосипедисты преодолели одинаковое расстояние! \r\n";

                if (firstDistance4 > secondDistance4) Answers.Text += "Первый велосипедист преодолел большее расстояние за 4 часа! \r\n";
                else if (firstDistance4 < secondDistance4) Answers.Text += "Второй велосипедист преодолел большее расстояние за 4 часа! \r\n";
                else Answers.Text += "За первые 4 часа езды велосипедисты преодолели одинаковое расстояние! \r\n";

                double meetingTime = 0;
                FindMeetingTime(firstSpeed - secondSpeed, firstAcceleration - secondAcceleration, out meetingTime);
                Answers.Text += $"Велосипедисты встретятся через: {meetingTime} час(а/ов)!";
            }
            catch { }
        } // Main

        private double FindDistance(double v0, double a, double t)
        {
            return Math.Round(v0 * t + a * Math.Pow(t, 2) / 2, 2);
        }

        private void FindMeetingTime(double deltaV, double deltaA, out double time)
        {
            time = Math.Round(-2 * deltaV / deltaA, 2);
        }

        private void ExchangeMaximumMatrixItems() // Main
        {
            try
            {
                int columns = int.Parse(Columns.Text);
                int rowsA = int.Parse(RowsA.Text);
                int rowsB = int.Parse(RowsB.Text);

                double[,] matrix1 = GenerateMatrix(rowsA, columns, 0, 9);
                double[,] matrix2 = GenerateMatrix(rowsB, columns, 0, 9);
                ShowMatrices(Matrix1, Matrix2, matrix1, matrix2);

                var maxItemA = FindMaxItemInMatrix(matrix1);
                var maxItemB = FindMaxItemInMatrix(matrix2);
                ExchangeItems(matrix1, matrix2, maxItemA, maxItemB);
                ShowMatrices(Matrix3, Matrix4, matrix1, matrix2);
            }
            catch { }
        } 

        private double[,] GenerateMatrix(int rows, int columns, int a, int b)
        {
            double[,] matrix = new double[columns, rows];

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    matrix[column, row] = rnd.Next(a, b);
                }
            }

            return matrix;
        }

        private void ShowMatrices(TextBox MatrixA, TextBox MatrixB, double[,] matrixA, double[,] matrixB)
        {
            ShowMatrix(MatrixA, matrixA);
            ShowMatrix(MatrixB, matrixB);
        }

        private void ShowMatrix(TextBox output, double[,] matrix)
        {
            output.Clear();
            for (int row = 0; row <= matrix.GetUpperBound(1); row++)
            {
                for (int column = 0; column <= matrix.GetUpperBound(0); column++)
                {
                    output.Text += matrix[column, row] + " ";
                }
                output.Text += "\r\n";
            }
        }

        private (int, int) FindMaxItemInMatrix(double[,] matrix)
        {
            double maxItem = double.NegativeInfinity;
            int columnOfMaxItem = -1;
            int rowOfMaxItem = -1;

            for (int row = 0; row <= matrix.GetUpperBound(1); row++)
            {
                for (int column = 0; column <= matrix.GetUpperBound(0); column++)
                {
                    if (matrix[column, row] > maxItem)
                    {
                        maxItem = matrix[column, row];
                        columnOfMaxItem = column;
                        rowOfMaxItem = row;
                    }
                }
            }

            return (columnOfMaxItem, rowOfMaxItem);
        }

        private void ExchangeItems(double[,] matrixA, double[,] matrixB, (int, int) maxItemA, (int, int) maxItemB)
        {
            var temp = matrixA[maxItemA.Item1, maxItemA.Item2];
            matrixA[maxItemA.Item1, maxItemA.Item2] = matrixB[maxItemB.Item1, maxItemB.Item2];
            matrixB[maxItemB.Item1, maxItemB.Item2] = temp;
        }

        private void ReplaceMaxItemsWithAverage() // Main
        {
            try
            {
                List<double> arrayA; CreateNewArray(CountA, out arrayA, 1, 4);
                List<double> arrayB; CreateNewArray(CountB, out arrayB, 4, 9);
                List<int> indicesA = FindMaxItemsInArray(arrayA);
                List<int> indicesB = FindMaxItemsInArray(arrayB);
                int maxCount = Math.Max(arrayA.Count, arrayB.Count);

                ShowArrays(ArraysBefore, maxCount - 1, arrayA, arrayB);
                ReplaceMaxItems(FindAverage(arrayA, arrayB, indicesA, indicesB), arrayA, arrayB);
                ShowArrays(ArraysAfter, maxCount - 1, arrayA, arrayB);
            }
            catch { }
        } 

        private void CreateNewArray(TextBox Count, out List<double> array, int a, int b)
        {
            int count = int.Parse(Count.Text);
            array = new List<double>();
            AddItemsToArray(ref array, count, a, b);
        }

        private void AddItemsToArray(ref List<double> array, int n, int a, int b)
        {
            if (n <= 0) return;
            while (n != 0)
            {
                array.Add(rnd.Next(a, b));
                n--;
            }
        }

        private List<int> FindMaxItemsInArray(List<double> array)
        {
            double maxValue = array.Max();
            List<int> maxItems = new List<int>();
            FindItemsInArray(array, maxValue, ref maxItems);
            return maxItems;
        }

        private void FindItemsInArray(List<double> array, double value, ref List<int> indices)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if (array[i] == value) indices.Add(i);
            }
        }

        private void ShowArrays(DataGridView arrayView, int countToAdd, List<double> arrayA, List<double> arrayB)
        {
            arrayView.Rows.Add(countToAdd);
            ShowArray(arrayView, arrayA, 0);
            ShowArray(arrayView, arrayB, 1);
        }

        private void ShowArray(DataGridView output, List<double> array, int columnIndex)
        {
            

            for (int i = 0; i < array.Count; i++)
            {
                output.Rows[i].Cells[columnIndex].Value = array[i];
            }
        }

        private void ReplaceMaxItems(double newValue, params List<double>[] arrays)
        {
            foreach (var array in arrays)
            {
                double maxValue = array.Max();
                for (int i = 0; i < array.Count; i++)
                {
                    if (array[i] == maxValue) array[i] = newValue;
                }
            }
        }

        private double FindAverage(List<double> arrayA, List<double> arrayB, List<int> indicesA, List<int> indicesB)
        {
            double average = double.NegativeInfinity;
            if (indicesA.Max() > indicesB.Max())
                average = FindAverageOfNextItems(arrayB, indicesB);
            else
                average = FindAverageOfNextItems(arrayA, indicesA);
            return average;
        }

        private double FindAverageOfNextItems(List<double> array, List<int> indices)
        {
            double sumOfNextItems = 0;
            foreach (var index in indices)
            {
                if (index + 1 < array.Count)
                {
                    sumOfNextItems += array[index + 1];
                }
            }
            return sumOfNextItems / indices.Count;
        }

        private void RemoveRowWithMaxDiagonalItem() // Main
        {
            try
            {
                int n = int.Parse(N.Text);
                double[,] matrix1 = GenerateMatrix(n, n, 10, 99);
                double[,] matrix2 = GenerateMatrix(n, n, 10, 99);
                ShowMatrices(Matrix5, Matrix6, matrix1, matrix2);

                int indexOfRow1 = FindRowWithMaxDiagonalItem(matrix1);
                int indexOfRow2 = FindRowWithMaxDiagonalItem(matrix2);
                RemoveRowInMatrix(ref matrix1, indexOfRow1);
                RemoveRowInMatrix(ref matrix2, indexOfRow2);

                ShowMatrices(Matrix7, Matrix8, matrix1, matrix2);
            }
            catch { }
        }

        private int FindRowWithMaxDiagonalItem(double[,] matrix)
        {
            double maxValue = double.NegativeInfinity;
            int indexOfRow = -1;
            for (int i = 0; i <= matrix.GetUpperBound(1); i++)
            {
                if (matrix[i, i] > maxValue)
                {
                    maxValue = matrix[i, i];
                    indexOfRow = i;
                }
            }
            return indexOfRow;
        }

        private void RemoveRowInMatrix(ref double[,] matrix, int rowIndex)
        {
            double[,] newMatrix = new double[matrix.GetUpperBound(0) + 1, matrix.GetUpperBound(1)];

            int indexOfRow = 0;
            for (int row = 0; row <= matrix.GetUpperBound(1); row++)
            {
                if (row != rowIndex)
                {
                    for (int column = 0; column <= matrix.GetUpperBound(0); column++)
                    {
                        newMatrix[column, indexOfRow] = matrix[column, row];
                    }
                    indexOfRow++;
                }
            }

            matrix = newMatrix;
        }

        private void ExchangeRowsWithMaxDiagonalItem() // Main
        {
            try
            {
                int n = int.Parse(N.Text);
                double[,] matrix1 = GenerateMatrix(n, n, 10, 99);
                double[,] matrix2 = GenerateMatrix(n, n, 10, 99);
                ShowMatrices(Matrix5, Matrix6, matrix1, matrix2);

                int indexOfRow1 = FindRowWithMaxDiagonalItem(matrix1);
                int indexOfRow2 = FindRowWithMaxDiagonalItem(matrix2);
                ExchangeRows(matrix1, matrix2, indexOfRow1, indexOfRow2);

                ShowMatrices(Matrix7, Matrix8, matrix1, matrix2);
            }
            catch { }
        }

        private void ExchangeRows(double[,] source, double[,] destination, int rowIndexA, int rowIndexB)
        {
            for (int columnIndex = 0; columnIndex <= source.GetUpperBound(0); columnIndex++)
            {
                var tempKey = source[columnIndex, rowIndexA];
                source[columnIndex, rowIndexA] = destination[columnIndex, rowIndexB];
                destination[columnIndex, rowIndexB] = tempKey;
            }
        }

        private void ExchangeMatrixRows() // Main
        {
            try
            {
                int columns = int.Parse(Columns.Text);
                int rowsA = int.Parse(RowsA.Text);
                int rowsB = int.Parse(RowsB.Text);

                double[,] matrix1 = GenerateMatrix(rowsA, columns, 10, 99);
                double[,] matrix2 = GenerateMatrix(rowsB, columns, 10, 99);
                ShowMatrices(Matrix1, Matrix2, matrix1, matrix2);

                int indexOfMaxItemA = -1, indexOfMaxItemB = -1;
                FindMaxItemInColumn(matrix1, 0, ref indexOfMaxItemA);
                FindMaxItemInColumn(matrix2, 0, ref indexOfMaxItemB);

                ExchangeRows(matrix1, matrix2, indexOfMaxItemA, indexOfMaxItemB);
                ShowMatrices(Matrix3, Matrix4, matrix1, matrix2);
            }
            catch { }
        }

        private int FindMaxItemInColumn(double[,] matrix ,int columnIndex, ref int indexOfMaxItem)
        {
            double max = double.NegativeInfinity;

            for (int rowIndex = 0; rowIndex <= matrix.GetUpperBound(1); rowIndex++)
            {
                if (matrix[columnIndex, rowIndex] > max)
                {
                    max = matrix[columnIndex, rowIndex];
                    indexOfMaxItem = rowIndex;
                }
            }

            return indexOfMaxItem;
        }

        private void CombineArraysWithoutMaxItems() // Main
        {
            try
            {
                List<double> arrayA; List<double> arrayB;
                CreateNewArray(ArrayACount, out arrayA, 10, 99);
                CreateNewArray(ArrayBCount, out arrayB, 10, 99);
                int maxCount = Math.Max(arrayA.Count, arrayB.Count);
                ShowArrays(Arrays1, maxCount - 1, arrayA, arrayB);

                RemoveMaxItems(arrayA); RemoveMaxItems(arrayB);
                arrayA.AddRange(arrayB);
                Array.Rows.Add(arrayA.Count - 1);
                ShowArray(Array, arrayA, 0);
            }
            catch { }
        }

        private void RemoveMaxItems(List<double> arrayA)
        {
            double max = arrayA.Max();
            for (int i = 0; i < arrayA.Count; i++)
            {
                if (arrayA[i] == max)
                {
                    arrayA.RemoveAt(i);
                    i--;
                }
            }
        }

        private void InsertColumnAsRow() // Main
        {
            try
            {
                int colARowB = int.Parse(ColARowB.Text);
                int rowA = int.Parse(RowA.Text);
                int colB = int.Parse(ColB.Text);

                double[,] matrix1 = GenerateMatrix(rowA, colARowB, -9, 9);
                double[,] matrix2 = GenerateMatrix(colARowB, colB, -9, 9);
                ShowMatrices(MatrixA1, MatrixB1, matrix1, matrix2);

                int indexOfRow = FindRowWithMaxCountOfPositiveNumbers(matrix1);
                int indexOfColumn = FindColumnWithMaxCountOfPositiveNumbers(matrix2);

                double[] column = GetColumn(matrix2, indexOfColumn);
                AddRowInMatrix(ref matrix1, column, indexOfRow);
                ShowMatrix(MatrixC, matrix1);
            }
            catch { }
        } 

        private int FindRowWithMaxCountOfPositiveNumbers(double[,] matrix)
        {
            List<int> countOfPositiveNumbers = new List<int>();
            int count = 0;

            for (int row = 0; row <= matrix.GetUpperBound(1); row++)
            {
                for (int column = 0; column <= matrix.GetUpperBound(0); column++)
                {
                    if (matrix[column, row] >= 0) count++;
                }
                countOfPositiveNumbers.Add(count);
                count = 0;
            }

            return countOfPositiveNumbers.IndexOf(countOfPositiveNumbers.Max());
        }

        private int FindColumnWithMaxCountOfPositiveNumbers(double[,] matrix)
        {
            List<int> countOfPositiveNumbers = new List<int>();
            int count = 0;

            for (int column = 0; column <= matrix.GetUpperBound(0); column++)
            {
                for (int row = 0; row <= matrix.GetUpperBound(1); row++)
                {
                    if (matrix[column, row] >= 0) count++;
                }
                countOfPositiveNumbers.Add(count);
                count = 0;
            }
            
            return countOfPositiveNumbers.IndexOf(countOfPositiveNumbers.Max());
        }

        private static double[] GetColumn(double[,] matrix, int columnIndex)
        {
            double[] column = new double[matrix.GetUpperBound(0)];
            for (int i = 0; i <= matrix.GetUpperBound(1); i++)
            {
                column[i] = matrix[columnIndex, i];
            }

            return column;
        }

        private void AddRowInMatrix(ref double[,] matrix, double[] rowArray, int rowIndex)
        {
            double[,] newMatrix = new double[matrix.GetUpperBound(0) + 1, matrix.GetUpperBound(1) + 2];

            int indexOfRow = 0;
            for (int row = 0; row <= matrix.GetUpperBound(1); row++)
            {
                if (row != rowIndex || row != indexOfRow)
                {
                    for (int column = 0; column <= matrix.GetUpperBound(0); column++)
                    {
                        newMatrix[column, indexOfRow] = matrix[column, row];
                    }
                }
                else
                {
                    for (int i = 0; i < rowArray.Length; i++)
                    {
                        newMatrix[i, indexOfRow] = rowArray[i];
                    }
                    row--;
                }
                indexOfRow++;
            }

            matrix = newMatrix;
        }

        private void SortArrays() // Main
        {
            try
            {
                List<double> arrayA; CreateNewArray(CountA, out arrayA, 10, 99);
                List<double> arrayB; CreateNewArray(CountB, out arrayB, 10, 99);
                int maxCount = Math.Max(arrayA.Count, arrayB.Count);
                ShowArrays(ArraysBefore, maxCount - 1, arrayA, arrayB);

                TailRecursiveQuickSort(arrayA, 0, arrayA.Count - 1);
                TailRecursiveQuickSort(arrayB, 0, arrayB.Count - 1);
                ShowArrays(ArraysAfter, maxCount - 1, arrayA, arrayB);
            }
            catch { }
        }

        protected void TailRecursiveQuickSort(List<double> array, int firstIndex, int secondIndex)
        {
            while (firstIndex < secondIndex)
            {
                int partitionIndex = Partition(array, firstIndex, secondIndex);
                TailRecursiveQuickSort(array, firstIndex, partitionIndex - 1);
                firstIndex++;
            }
        }

        private int Partition(List<double> array,int firstIndex, int secondIndex)
        {
            var key = array[secondIndex];
            int previousIndex = firstIndex - 1;

            for (int i = firstIndex; i <= secondIndex - 1; i++)
            {
                if (array[i].CompareTo(key) <= 0)
                {
                    previousIndex++;
                    ChangeItems(array, previousIndex, i);
                }
            }
            ChangeItems(array, previousIndex + 1, secondIndex);
            return previousIndex + 1;
        }

        private void ChangeItems(List<double> array, int firstIndex, int secondIndex)
        {
            var key = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = key;
        }

        private void CreateArrayFromSumOfColumns() // Main
        {
            try
            {
                int rowsA = int.Parse(ArrayACountM.Text);
                int columnsA = int.Parse(ArrayACountN.Text);
                int rowsB = int.Parse(ArrayBCountM.Text);
                int columnsB = int.Parse(ArrayBCountN.Text);

                double[,] matrix1 = GenerateMatrix(rowsA, columnsA, -10, 10);
                double[,] matrix2 = GenerateMatrix(rowsB, columnsB, -10, 10);
                ShowMatrices(MatrixA, MatrixB, matrix1, matrix2);

                List<double> sumArrayA, sumArrayB;
                ArrayOfSumsOfItemsInColumns(matrix1, out sumArrayA);
                ArrayOfSumsOfItemsInColumns(matrix2, out sumArrayB);

                ShowArrayInTextBox(SumA, sumArrayA);
                ShowArrayInTextBox(SumB, sumArrayB);
                sumArrayA.AddRange(sumArrayB);
                ShowArrayInTextBox(ResultArray, sumArrayA);
            }
            catch { }
        }

        private void ArrayOfSumsOfItemsInColumns(double[,] matrix, out List<double> array)
        {
            List<double> result = new List<double>();
            double sum = 0;

            for (int column = 0; column <= matrix.GetUpperBound(0); column++)
            {
                sum = 0;
                for (int row = 0; row <= matrix.GetUpperBound(1); row++)
                {
                    if (matrix[column, row] > 0) sum += matrix[column, row];
                }
                result.Add(sum);
            }

            array = result;
        }

        private void ShowArrayInTextBox(TextBox output, List<double> array)
        {
            output.Clear();
            for (int i = 0; i < array.Count; i++)
            {
                output.Text += array[i] + " ";
            }
        }

        private void FindSumsOfFunctions() // Main
        {
            Sum1.Text = Math.Round(FindSumOfFormule1(), 2).ToString();
            Sum2.Text = Math.Round(FindSumOfFormule2(), 2).ToString();
        }

        private double FindSumOfFormule1()
        {
            double sum = 1;
            double x = 0.1;
            int i = 0;

            while (x <= 1)
            {
                sum += Math.Cos(i * x) / Factorial(i);
                x += 0.1;
                i++;
            }

            return sum;
        }

        private double FindSumOfFormule2()
        {
            double sum = 0;
            double x = Math.PI / 5;
            int i = 0;

            while (x <= Math.PI)
            {
                sum += Math.Pow(-1,i) * Math.Cos(i * x) / Math.Pow(i,2);
                x += Math.PI / 25;
                i++;
            }

            return sum;
        }

        private void InterviewPeople() // Main
        {
            try
            {
                int numberOfRespondents = int.Parse(NumberOfRespondents.Text);
                List<Animals> firstAnswers = new List<Animals>();
                List<Characteristics> secondAnswers = new List<Characteristics>();
                List<Subject> thirdAnswers = new List<Subject>();

                Answer(ref firstAnswers, numberOfRespondents);
                Answer(ref secondAnswers, numberOfRespondents);
                Answer(ref thirdAnswers, numberOfRespondents);

                ShowStatistic(Answer1, firstAnswers, firstAnswers.Count);
                ShowStatistic(Answer2, secondAnswers, secondAnswers.Count);
                ShowStatistic(Answer3, thirdAnswers, thirdAnswers.Count);
            }
            catch { }
        }

        private void Answer<T>(ref List<T> answers, int numberOfRespondents)
        {
            Array values = Enum.GetValues(typeof(T));
            int n = rnd.Next(numberOfRespondents / 2, numberOfRespondents);

            for (int i = 0; i < n; i++)
            {
                T randomAnswer = (T)values.GetValue(rnd.Next(values.Length));
                answers.Add(randomAnswer);
            }
        }

        private void ShowStatistic<T>(TextBox textBox, List<T> answers, int count)
        {
            Array values = Enum.GetValues(typeof(T));
            Dictionary<T, int> info = new Dictionary<T, int>();

            foreach (var answer in answers)
            {
                int currentCount = GetItemCountInArray(answers, answer);
                info[answer] = currentCount;
            }

            textBox.Clear();
            for (int i = 0; i < 5; i++)
            {
                SendMaxItemToForm(textBox, info, count);
            }
        }

        private int GetItemCountInArray<T>(List<T> answer, T item)
        {
            int count = 0;
            for (int i = 0; i < answer.Count; i++)
            {
                if (answer[i].Equals(item)) count++;
            }
            return count;
        }

        private void SendMaxItemToForm<U>(TextBox output, Dictionary<U, int> dict, int count)
        {
            foreach (var item in dict)
            {
                if (dict.Values.Max().Equals(item.Value))
                {
                    int percentage = (int)((double)item.Value / (double)count * 100);
                    output.Text += $"{item.Key} - {item.Value} ({percentage}%) \r\n";
                    dict.Remove(item.Key);
                    break;
                } 
            }
        }

        private void ExchangeRowsWithMaxNegativeNumbers() // Main
        {
            try
            {
                int columns = int.Parse(Columns.Text);
                int rowsA = int.Parse(RowsA.Text);
                int rowsB = int.Parse(RowsB.Text);

                double[,] matrix1 = GenerateMatrix(rowsA, columns, -15, 15);
                double[,] matrix2 = GenerateMatrix(rowsB, columns, -15, 15);
                ShowMatrices(Matrix1, Matrix2, matrix1, matrix2);

                int indexOfMaxNegativeNumbersA = FindRowWithMaxCountOfNegativeNumbers(matrix1);
                int indexOfMaxNegativeNumbersB = FindRowWithMaxCountOfNegativeNumbers(matrix2);

                ExchangeRows(matrix1, matrix2, indexOfMaxNegativeNumbersA, indexOfMaxNegativeNumbersB);
                ShowMatrices(Matrix3, Matrix4, matrix1, matrix2);
            }
            catch { }
        }

        private int FindRowWithMaxCountOfNegativeNumbers(double[,] matrix)
        {
            List<int> countOfPositiveNumbers = new List<int>();
            int count = 0;

            for (int row = 0; row <= matrix.GetUpperBound(1); row++)
            {
                for (int column = 0; column <= matrix.GetUpperBound(0); column++)
                {
                    if (matrix[column, row] <= 0) count++;
                }
                countOfPositiveNumbers.Add(count);
                count = 0;
            }

            return countOfPositiveNumbers.IndexOf(countOfPositiveNumbers.Max());
        }
    }
}
