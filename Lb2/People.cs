using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lb2
{
    /// <summary>
    /// Класс, содержащий коллекцию людей
    /// </summary>
    public class People
    {
        /// <summary>
        /// Типизированный стек людей
        /// </summary>
        private Stack<Person> peopleStack;

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public People()
        {
            peopleStack = new Stack<Person>();
        }

        delegate void ItemAdded(Person person);
        delegate void ItemPopped();

        /// <summary>
        /// Добавляет людей в начало коллекции и вызывает событие
        /// </summary>
        /// <param name="person">Человек, которого нужно добавить в коллекцию</param>
        public void Add (Person person) => peopleStack.Push(person);

        /// <summary>
        /// Удаляет человека из начала коллекции и вызывает событие
        /// </summary>
        public void Pop() => peopleStack.Pop();

        /// <summary>
        /// Создает объект, содержащий данные всех людей для вывода в таблицу
        /// </summary>
        /// <returns>Таблица с данными людей</returns>
        public DataTable GenerateData()
        {
            DataTable dataTable = new DataTable();

            int counter = 0;
            // Добавление строк
            foreach (Person person in peopleStack)
            {
                dataTable.Rows.Add(counter++, person.name, person.surname, person.Gender, person.Year_of_birth,
                    person.City, person.Country, person.Height);
            }

            return dataTable;
        }
    }
}
