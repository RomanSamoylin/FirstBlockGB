string ReadString(string message)
{
    Console.WriteLine(message);
    string result = Console.ReadLine();
    while (result == String.Empty)
    {
        Console.WriteLine("Строка пустая! Попробуйте ещё раз:");
        result = Console.ReadLine();
    }
    return result;
}

string RemoveExcessSplittersAndSpaces(string input, char splitter)
{
    input = input.Trim(' ');
    for (int i = 0; i < input.Length; i++)
        if (input[i] == ' ' && input[i + 1] == ' ')
        {
            input = input.Remove(i, 1);
            i--;
        }
    input = input.Trim(splitter);
    for (int i = 0; i < input.Length; i++)
        if (input[i] == splitter && input[i + 1] == splitter)
        {
            input = input.Remove(i, 1);
            i--;
        }
    input = input.Trim(' ');
    return input;
}

int CountSplitters(string splitable, char splitter)
{
    int counter = 0;
    for (int i = 0; i < splitable.Length; i++)
    {
        if (splitable[i] == splitter)
            counter++;
    }
    return counter + 1;
}

void TrimElements(string[] array)
{
    for (int i = 0; i < array.Length; i++)
        array[i] = array[i].Trim(' ');
}

void PrintArray(string[] array)
{
    for (int i = 0; i < array.Length; i++)
        Console.Write($"|{array[i]}| ");
    Console.WriteLine();
}

string[] GetArray(string input)
{
    input = RemoveExcessSplittersAndSpaces(input, ',');
    int size = CountSplitters(input, ',');
    string[] result = input.Split(',', size);
    TrimElements(result);
    return result;
}

int[] GetNewLengthes(string[] array)
{
    int[] result = new int[array.Length];
    for (int i = 0; i < result.Length; i++)
        if (array[i].Length < 3)
            result[i] = new Random().Next(0, array[i].Length);
        else
            result[i] = new Random().Next(0, 4);
    return result;
}

void PrintIntArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
        Console.Write($"{array[i]} ");
    Console.WriteLine();
}


string[] TransformArray(string[] initialArray, int[] newLengthes)
{
    string[] result = new string[initialArray.Length];
    for (int i = 0; i < result.Length; i++)
    {
        if (newLengthes[i] == 0)
            result[i] = String.Empty;
        else
        {
            int startIndex = new Random().Next
                    (0, initialArray[i].Length - newLengthes[i]);
            result[i] = initialArray[i].Substring(startIndex, newLengthes[i]);
        }
    }
    return result;
}

/*------------------MAIN-----------------------------*/
Console.Clear();


string input = ReadString("Введите элементы массива через запятую: ");
string[] inputArray = GetArray(input);
PrintArray(inputArray);
int[] newLengthes = GetNewLengthes(inputArray);
PrintIntArray(newLengthes);
PrintArray(
            TransformArray(inputArray, newLengthes));