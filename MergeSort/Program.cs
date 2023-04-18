namespace MergeSort 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] myArray = { 1, 2, 33, 567, 231, 2, 5, 6 };
            ArrayPrint(myArray);
            MergeSort(myArray);
            Console.WriteLine();
            ArrayPrint(myArray);
        }
        
        private static void BubleSort_INCRIMENTAL(int[] myArr) // сортировка пузырьком
        {
            var len = myArr.Length;
            for (int i = len - 1; i > 0; i--)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i == j) break;

                    if (myArr[j] > myArr[j + 1])
                    {
                        int temp = myArr[j];
                        myArr[j] = myArr[j + 1];
                        myArr[j + 1] = temp;
                    }
                }
            }
        }

        private static void SelectionSort(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }
                Swap(array, largestAt,partIndex);
            }
        }
        private static void InsertionSort(int[] array) // сортировка вставками
        {
            for (int partIndex = 1; partIndex < array.Length; partIndex++)
            {
                int curUnsosorted = array[partIndex];
                int i = 0;
                for ( i = partIndex; i > 0 && array [i - 1] > curUnsosorted; i--)
                {
                    array[i] = array[i - 1];
                }
                array[i] = curUnsosorted;
            }
        }

        private static void ShellSort(int[] array) // сортировка Шелла (усовершенствованный сорт. вставсками)
        {
            int gap = 1;
            
            while (gap < array.Length/3)
                gap = 3 * gap + 1;  //в gap будет записанно максимальное значение с которого начинаем
            
            while (gap >= 1)
            {
                for (int i = gap; i < array.Length; i++)
                {
                    for (int j = i; j >= gap && array[j] < array[j - gap]; j -= gap)
                    {
                        Swap(array,j,j - gap);
                    }
                }
                
                gap /= 3;
            }
            
        }
        private static void SelectSort(int[] myArr) // сортировка выборкой
        {
            for (int partIndex = myArr.Length - 1; partIndex > 0; partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (myArr[i] > myArr[largestAt])
                        largestAt = i;
                }
                Swap(myArr, largestAt, partIndex);
            }
        }
        public static void MergeSort(int[] array) // сортировка слиянием
        {
            int[] aux = new int[array.Length];
            Sort(0, array.Length - 1);

            void Sort(int low, int high)
            {
                if (high <= low)
                    return;
                int mid = (high + low) / 2;
                Sort(low, mid);
                Sort(mid+1,high);
                Merge(low,mid,high);
            }
            
            void Merge(int low, int mid, int high)
            {
                if(array[mid] <= array [mid + 1]) return;
                
                int i = low;
                int j = mid + 1;
                
                Array.Copy(array, low, aux,
                    low,high - low + 1);
                
                for (int k = low; k <=high; k++)
                {
                    if (i > mid) array[k] = aux[j++];
                    else if (j > high) array[k] = aux[i++];
                    else if (aux[j] < aux[i])
                        array[k] = aux[j++];
                    else array[k] = aux[i++];
                }
            }
        }
        private static void ArrayPrint(int[] myArr)
        {
            for (int i = 0; i < myArr.Length; i++)
                Console.Write($"{myArr[i]}, ");
        }
        private static void Swap(int[] array, int i, int j)
        {
            if (i == j) return;
            int temp = array[j];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}



