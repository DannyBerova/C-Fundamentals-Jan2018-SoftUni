using System;

public class ArrayCreator
{
    
    public static T[] Create<T>(int length, T item)
    {
        T[] arr = new T[length];

        for (int index = 0; index < length; index++)
        {
            arr[index] = item;
        }

        return arr;
    }
}

