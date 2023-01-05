// See https://aka.ms/new-console-template for more information
using static System.Console;

int[,] arr = new int[8, 8];
int[] row = new int[64];
int[] col = new int[64];
int[] ktmov = { -2, -1, 1, 2, 2, 1, -1, -2 };
int[] ktmov2 = { 1, 2, 2, 1, -1, -2, -2, -1 };
int i = 0, j = 0, move_num = 0, d = 0;
WriteLine("Выберите Задание \"1-Ход конём, 2-Сортировка, 0-Выход\"");
int value = Int32.Parse(ReadLine());
switch (value)
{
    case 0:
        break;
    case 1:
        addknight();
        break;
    case 2:
        Sorting();
        break;
}
void addknight()
{
    
        int a, b, e;
        arr[i, j] = 1;
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
    for (a = 0; a <= 63; a++)
    {
        SetCursorPosition(col[a] * 3 + 1, 12 + row[a]);
        Write(a + 1);
        ReadKey();
        
    }

}
 void Sorting()
{
    //метод для обмена элементов массива
    static void Swap(ref int x, ref int y)
    {
        var t = x;
        x = y;
        y = t;
    }

    //метод возвращающий индекс опорного элемента
    static int Partition(int[] array, int minIndex, int maxIndex)
    {
        var pivot = minIndex - 1;
        for (var i = minIndex; i < maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                Swap(ref array[pivot], ref array[i]);
            }
        }

        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);
        return pivot;
    }

    //быстрая сортировка
    static int[] QuickSort(int[] array, int minIndex, int maxIndex)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }

        var pivotIndex = Partition(array, minIndex, maxIndex);
        QuickSort(array, minIndex, pivotIndex - 1);
        QuickSort(array, pivotIndex + 1, maxIndex);

        return array;
    }

    static int[] QuickSort1(int[] array)
    {
        return QuickSort(array, 0, array.Length - 1);
    }
    Clear();
    Write("Размерность массива = ");
    var len = Convert.ToInt32(ReadLine());
    var a = new int[len];
    for (var i = 0; i < a.Length; ++i)
    {
        Write("a[{0}] = ", i);
        a[i] = Convert.ToInt32(ReadLine());
    }

    WriteLine("Упорядоченный массив: {0}", string.Join(", ", QuickSort1(a)));

    ReadLine();
    
}
