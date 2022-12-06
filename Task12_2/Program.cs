using System;
using System.IO;
using System.Linq;

namespace Task12_2
{
	class Program
	{
		static void Main(string[] args)
		{
			const int array_quantity = 10;

			//////////////////////////////////////////////////////////////////////////////////////////////////////////

			Console.WriteLine("д) Обычный вариант: ");
			int[] array_d_1 = new int[array_quantity] {1,  10, 24,    3, 17,   6, 5, 0,  9,  11};
			int[] array_d_2 = new int[array_quantity] {25, 101, 8, 1337, 45, 36, 78, 0, 97, 100};
			
			for (int i = 0; i < array_quantity; i++)
			{
				if (array_d_1[i] % 5 == 0)
				{
					for (int j = 0; j < array_quantity; j++)
					{
						if (array_d_2[j] % 5 == 0)
							Console.Write($"[{array_d_1[i]} {array_d_2[j]}] ");
					} 
				}
			}

			Console.WriteLine("\n");

			Console.WriteLine("д) Вариант через Linq: "); 				// Здесь не сделяль
			var digit_pairs = from number in array_d_1
					  select number;
			
			foreach (var number in digit_pairs)
				Console.Write($"{number}");

			Console.WriteLine("\n");			
			
			//////////////////////////////////////////////////////////////////////////////////////////////////////////

			Console.WriteLine("e) Обычный вариант: ");
			string[] array_e = new string[array_quantity] {"ХвОст", "МОтор", "МоЧаЛка", "СоПЛя", "кот", "РЫБА", "ГиДРоЭлеКтРОстанЦИя", "КрУг", "ДеЛЬфин", "оТВАР"};

			var result_e = new List<string>();

			foreach (string word in array_e)
			{
				if (word.Contains("от") || word.Contains("оТ") || word.Contains("От") || word.Contains("ОТ"))
					result_e.Add(word);
			}
			result_e.Sort();

			foreach (string word in result_e)
				Console.Write($"{word} ");

			Console.WriteLine("\n");

			Console.WriteLine("e) Вариант через Linq: ");
			var ordered_words = from word in array_e
					    where word.ToLower().Contains("от")
					    orderby word
					    select word;

 			foreach (var word in ordered_words)
				Console.Write($"{word} ");

			Console.WriteLine("\n");
	
			//////////////////////////////////////////////////////////////////////////////////////////////////////////

			Console.WriteLine("ж) Обычный вариант: ");
			string s1 = "солим одракир";
			string s2 = "рикардо милос";
			
			if (s1.Length != s2.Length)
				Console.WriteLine("Строки не обратны друг другу.");
			else
			{
				bool flag = true;
				for (int i = 0; i < s1.Length; i++)
				{
					if (s1[i] != s2[s2.Length - i - 1])
           	 			{
                				flag = false;
                				break;
            				}
				}

				if (flag)
					Console.WriteLine("Строки обратны друг другу.");
			}
			Console.WriteLine("\n");

			Console.WriteLine("ж) Вариант через Linq: ");		// Здесь не сделяль

			// ...
			
			Console.WriteLine("\n");

			//////////////////////////////////////////////////////////////////////////////////////////////////////////

			Console.WriteLine("з) Обычный вариант: ");
			int[] array_z = new int[array_quantity] {54, 323, 6412, 66, 2, 9889, 55, 90, 43, 0};
			
			int index = 0;
			for (int i = 0; i < array_quantity; i++)	/* Группировка чётных чисел в левую часть массива, нечетных - в правую. */
			{
				if (array_z[i] % 2 == 0)
				{
					int t = array_z[i];
					array_z[i] = array_z[index];
					array_z[index] = t;
					index++;
				}	
			}

			for (int i = 0; i < index; i++)			/* Сортировка чётных чисел. */
			{
				for (int j = i + 1; j < index; j++)
				{
					if (array_z[i] > array_z[j])
					{
						int t = array_z[i];
						array_z[i] = array_z[j];
						array_z[j] = t;
					}
				} 
			}
			
			for (int i = index; i < array_quantity; i++)	/* Сортировка нечётных чисел. */
			{
				for (int j = i + 1; j < array_quantity; j++)
				{
					if (array_z[i] > array_z[j])
					{
						int t = array_z[i];
						array_z[i] = array_z[j];
						array_z[j] = t;
					}
				}
			}
			
			for (int i = 0; i < array_quantity; i++)	/* Вывод отсортированного массива. */
				Console.Write($"{array_z[i]} ");

			Console.WriteLine("\n");

			Console.WriteLine("з) Вариант через Linq: ");
			
			var ordered_array = from digit in array_z			// Здесь не сделаль	
					    		where digit % 2 == 0
					    		orderby digit
					    		select digit;
				
			foreach (var digit in ordered_array)
				Console.Write($"{digit} ");

			Console.WriteLine("\n");
			//////////////////////////////////////////////////////////////////////////////////////////////////////////
			return;
		}
	}
}
