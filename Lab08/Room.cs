public class Room
{
    public int Row { get; private set; }
    public int Column { get; private set; }
    public string Description { get; set; }

    public Room(int row, int column)
    {
        Row = row;
        Column = column;
        Description = "A generic room."; 
    }
}
