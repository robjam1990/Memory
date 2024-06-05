using System;
[Guid("4D05C8B1-85E7-4EE4-B062-57A66EEEF0CA")]
class TuringMachine3D
{
    private const int Size = 10;
    private char[,,] space = new char[Size, Size, Size];
    private int x = Size / 2, y = Size / 2, z = Size / 2;
    private int zoomLevel = 1;

    public void MoveX(int delta) => x = Math.Clamp(x + delta, 0, Size - 1);
    public void MoveY(int delta) => y = Math.Clamp(y + delta, 0, Size - 1);
    public void MoveZ(int delta) => z = Math.Clamp(z + delta, 0, Size - 1);
    public char Read() => space[x, y, z];
    public void Write(char c) => space[x, y, z] = c;
    public void Erase() => space[x, y, z] = default;
    public void Zoom(int delta) => zoomLevel = Math.Max(1, zoomLevel + delta);

    public void Display()
    {
        for (int i = 0; i < space.GetLength(0); i++)
        {
            for (int j = 0; j < space.GetLength(1); j++)
            {
                for (int k = 0; k < space.GetLength(2); k++)
                {
                    Console.Write(space[i, j, k] == default ? '.' : space[i, j, k]);
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        TuringMachine3D tm = new TuringMachine3D();
        tm.Write('∀');
        tm.Display();
        tm.MoveX(1);
        tm.MoveY(1);
        tm.MoveZ(1);
        tm.Write('X');
        tm.Display();
        tm.Zoom(1);
        Console.WriteLine($"Zoom Level: {tm.zoomLevel}");
    }
}

public static class MathExtensions
{
    public static int Clamp(int value, int min, int max)
    {
        return (value < min) ? min : (value > max) ? max : value;
    }
}