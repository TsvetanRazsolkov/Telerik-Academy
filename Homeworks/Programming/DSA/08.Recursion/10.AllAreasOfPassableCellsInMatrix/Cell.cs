namespace _10.AllAreasOfPassableCellsInMatrix
{
    public class Cell
    {
        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override string ToString()
        {
            return string.Format("({0} {1})", this.Row, this.Col);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Cell;

            return this.Row.CompareTo(other.Row) == 0 && this.Col.CompareTo(other.Col) == 0;
        }
    }
}
