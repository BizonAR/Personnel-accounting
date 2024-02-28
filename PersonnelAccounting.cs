using System;
using System.Linq.Expressions;

namespace PersonnelAccounting
{
	internal class PersonnelAccounting
	{
		static void Main(string[] args)
		{
			const string CommandAddDosier = "1";
			const string CommandDisplayAllDosier = "2";
			const string CommandRemoveDosier = "3";
			const string ComandSearchByLastName = "4";
			const string CommandExit = "5";

			string[] fullNames = Array.Empty<string>();
			string[] positions = Array.Empty<string>();

			bool isProgramActive = true;

			while (isProgramActive)
			{
				Console.WriteLine("Список команд:\n" +
						$"{CommandAddDosier} - добавить досье\n" +
						$"{CommandDisplayAllDosier} - вывести все досье\n" +
						$"{CommandRemoveDosier} - удалить досье\n" +
						$"{ComandSearchByLastName} - поиск по фамилии\n" +
						$"{CommandExit} - выход из программы");
				Console.Write("Введите команду: ");
				string input = Console.ReadLine();

				switch (input)
				{
					case CommandAddDosier:
						AddDosier(ref fullNames, ref positions);
						break;

					case CommandDisplayAllDosier:
						DisplayAllDosier(fullNames, positions);
						break;

					case CommandRemoveDosier:
						RemoveDosier(ref fullNames, ref positions);
						break;

					case ComandSearchByLastName:
						SearchByLastName(fullNames, positions);
						break;

					case CommandExit:
						isProgramActive = false;
						break;

					default:
						Console.WriteLine("Неизвестная команда!");
						break;
				}
			}
		}

		private static void AddDosier(ref string[] fullNames, ref string[] positions)
		{
			Console.Write("Введите ФИО сотрудника: ");
			string name = Console.ReadLine();
			Console.Write("Введите должность сотрудника: ");
			string jobTitle = Console.ReadLine();

			fullNames = IncreaseArray(fullNames, name);
			positions = IncreaseArray(positions, jobTitle);
		}

		private static string[] IncreaseArray(string[] array, string newEmployee)
		{
			string[] increasingArray = new string[array.Length + 1];

			for (int i = 0; i < array.Length; i++)
			{
				increasingArray[i] = array[i];
			}

			increasingArray[increasingArray.Length - 1] = newEmployee;
			return increasingArray;
		}

		private static void DisplayAllDosier(string[] fullNames, string[] positions)
		{
			if (fullNames.Length > 0)
			{
				int index = 1;

				for (int i = 0; i < fullNames.Length; i++)
				{
					Console.WriteLine($"{index}. {fullNames[i]} - {positions[i]}");
					index++;
				}
			}
			else
			{
				Console.WriteLine("Список досье пусть");
			}
		}

		private static void RemoveDosier(ref string[] fullNames, ref string[] positions)
		{
			if (fullNames.Length > 0)
			{
				Console.Write("Введите индекс сотрудника, которого вы хотите удалить: ");
				int dossierNumber;
				int.TryParse(Console.ReadLine(), out dossierNumber);

				if (dossierNumber > 0 && dossierNumber <= fullNames.Length)
				{
					int index = dossierNumber - 1;
					fullNames = ReductionArray(fullNames, index);
					positions = ReductionArray(positions, index);
				}
				else
				{
					Console.WriteLine("Нет досье с таким порядковым номером!");
				}
			}
			else
			{
				Console.WriteLine("Список досье пусть");
			}
		}

		private static string[] ReductionArray(string[] array, int index)
		{
			string[] reducingArray = new string[array.Length - 1];

			for (int i = 0; i < index; i++)
				reducingArray[i] = array[i];

			for (int i = index; i < reducingArray.Length; i++)
				reducingArray[i] = array[i + 1];

			return reducingArray;
		}

		private static void SearchByLastName(string[] fullNames, string[] positions)
		{
			if (fullNames.Length > 0)
			{
				Console.Write("Введите фамилию сотрудника: ");
				string lastName = Console.ReadLine();
				bool dossierFound = false;

				char spaceCharacter = ' ';

				for (int i = 0; i < fullNames.Length; i++)
				{
					string[] subStrings = fullNames[i].Split(spaceCharacter);
					if (subStrings[0].ToLower() == lastName.ToLower())
					{
						Console.WriteLine($"{i + 1}. {fullNames[i]} - {positions[i]}");
						dossierFound = true;
					}
				}

				if (dossierFound == false)
					Console.WriteLine($"Досье на сотрудника с фамилией {lastName} не найдено");
			}
			else
			{
				Console.WriteLine("Список досье пусть");
			}
		}
	}
}
