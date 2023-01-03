// See https://aka.ms/new-console-template for more information
using static System.Console;
int[,] arr = new int[8, 8];
int[] row = new int[64];
int[] col = new int[64];
int[] ktmov = { -2, -1, 1, 2, 2, 1, -1, -2 };
int[] ktmov2 = { 1, 2, 2, 1, -1, -2, -2, -1 };
int i =0, j = 0, move_num = 0, d;
addknight();
void addknight()
{
    int a, b, e;
    arr[i,j] = 1;
    row[move_num] = i; 
    col[move_num] = j;
    move_num++;

    for (a = 0; a <= 7; a++)
    {
        if (move_num >= 64)
        {
            writeboard();
        }
        b = i + ktmov[a];
        e = j + ktmov2[a];

        if (b < 0 || b > 7 || e < 0 || e > 7)
        { continue; }

        if (arr[b, e] == 1)
        { continue; }
        i = b; j = e;
        addknight();
    }

    move_num--;
    arr[row[move_num], col[move_num]] = 0;
    move_num--;
    i = row[move_num]; j = col[move_num];
    move_num++;
}
void writeboard()
{
    int a;

    Clear();
    SetCursorPosition(1, 10);
    Write("Hit any key for next move ");
    SetCursorPosition(1, 11);
    for (a = 0; a <= 63; a++)
    {
        if (a % 8 == 0)
        {
            WriteLine();
        }
        Write(" # ");
    }
    for (a = 0; a <= 63 ; a++ ) 
    {
        SetCursorPosition(col[a] * 3 + 1, 12 + row[a]);
        Write( a + 1);
        ReadKey();
    }   
}