namespace Lb2
{
    public partial class FormContainerLb2 : Form
    {
        /// <summary>
        /// ������ ������ People, ������ ���� ��������� �����
        /// </summary>
        People people = new People();
        /// <summary>
        /// ���������� �������, ������� ������ ���� �����
        /// </summary>
        void changeTable() => showAllButton_Click(null, null);
        public FormContainerLb2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ������� ������ ���� ����� � �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showAllButton_Click(object sender, EventArgs e)
        {
            Array all = people.getAll().ToArray();
            showTable.Rows.Clear();
            showTable.Refresh();
            int count = 0;
            foreach (Person curr in all)
            {
                showTable.Rows.Add();
                showTable.Rows[count].Cells[0].Value = count + 1;
                showTable.Rows[count].Cells[1].Value = curr.name;
                showTable.Rows[count].Cells[2].Value = curr.surname;
                showTable.Rows[count].Cells[3].Value = curr.Gender;
                showTable.Rows[count].Cells[4].Value = curr.Year_of_birth;
                showTable.Rows[count].Cells[5].Value = curr.City;
                showTable.Rows[count].Cells[6].Value = curr.Country;
                showTable.Rows[count].Cells[7].Value = curr.Height;
                count++;
            }
        }

        /// <summary>
        /// �������, ������������� ��� �������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            testingTable.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            testingTable.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
            testingTable.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        /// <summary>
        /// �������, ����������� ����� ������ Person
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                create_err.Text = "";
                string person_name = name.Text;
                string person_surname = surname.Text;
                string person_gender = (man.Checked) ? "�������" : "�������";
                string person_year_of_birth = year_of_birth.Text;
                string person_city = city.Text;
                string person_country = country.Text;
                string person_height = height.Text;
                Person newPerson;

                if (person_name == "")
                {
                    newPerson = new Person();
                }
                else if (person_surname == "")
                {
                    newPerson = new Person(person_name);
                }
                else if (person_city == "" || person_country == "" || height.Text == "")
                {
                    newPerson = new Person(person_name, person_surname);
                }
                else
                {
                    newPerson = new Person(person_name, person_surname,
                            person_gender, person_year_of_birth, person_city,
                            person_country, person_height);
                }
                people.NotifyAdd += changeTable;
                people.Add(newPerson);
                create_err.Text = "������!";

                name.Text = "";
                surname.Text = "";
                year_of_birth.Text = "2000";
                city.Text = "";
                country.Text = "";
                height.Text = "";
            }
            catch (MyOverflowException ex)
            {
                Win32.MessageBox(0, ex.Message + "\n" + ex.TimeOfExeption.ToString(), "�������������", 0);
            }
            catch (PersonArgumentExeption ex)
            {
                create_err.Text = ex.Message + "\n" + ex.TimeOfExeption.ToString();
            }
        }

        /// <summary>
        /// ������� ��� �������� ������� �� ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            int val = (int)number.Value;
            people.NotifyRemove += changeTable;
            people.Remove(val);
        }

        /// <summary>
        /// ������� ��� ������ ������������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startTestingButton_Click(object sender, EventArgs e)
        {
            int n = 10000;
            Person[] array = new Person[n];
            testingTable.Items.Clear();
            Stack<Person> stack = new Stack<Person>();
            int create_array = 0, create_stack = 0;
            int StartTime = Environment.TickCount;
            for (int i = 0; i < n; i++)
            {
                array[i] = new Person();
            }
            create_array = Environment.TickCount - StartTime;
            StartTime = Environment.TickCount;
            for (int i = 0; i < n; i++)
            {
                stack.Push(new Person());
            }
            create_stack = Environment.TickCount - StartTime;

            int ordered_array = 0, ordered_stack = 0;
            StartTime = Environment.TickCount;
            foreach (Person p in array) ;
            ordered_array = Environment.TickCount - StartTime;
            StartTime = Environment.TickCount;
            foreach (Person p in stack) ;
            ordered_stack = Environment.TickCount - StartTime;

            int random_array = 0, random_stack = 0;
            Random rnd = new Random();
            StartTime = Environment.TickCount;
            for (int i = 0; i < n; i++)
            {
                int curr = rnd.Next(1, n);
                Person curr_value = array[curr-1];
            }
            random_array = Environment.TickCount - StartTime;
            Stack <Person> helpStack = new Stack<Person>();
            StartTime = Environment.TickCount;
            for (int i = 0; i < n; i++)
            {
                int curr = rnd.Next(1, n); 
                curr--;
                for (int j = 0; j != n; j++) helpStack.Push(stack.Pop());
                while (helpStack.Count > 0)
                {
                    stack.Push(helpStack.Pop());
                }
            }
            random_stack = Environment.TickCount - StartTime;

            ListViewItem lvi = new ListViewItem();
            lvi.Text = "������: " + Convert.ToString(create_array);
            lvi.SubItems.Add(Convert.ToString(ordered_array));
            lvi.SubItems.Add(Convert.ToString(random_array));
            testingTable.Items.Add(lvi);

            ListViewItem lvi2 = new ListViewItem();
            lvi2.Text = "����: " + Convert.ToString(create_stack);
            lvi2.SubItems.Add(Convert.ToString(ordered_stack));
            lvi2.SubItems.Add(Convert.ToString(random_stack));
            testingTable.Items.Add(lvi2);
        }
    }
}
