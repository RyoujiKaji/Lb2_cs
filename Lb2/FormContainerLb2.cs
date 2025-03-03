using System.Data;
using System.Windows.Forms;

namespace Lb2
{
    public partial class FormContainerLb2 : Form
    {
        public FormContainerLb2()
        {
            InitializeComponent();
        }

        private void showAllButton_Click(object sender, EventArgs e)
        {
            // Привязка DataTable к DataGridView
            //dataGridView.DataSource = dataTable;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            testingTable.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);
            testingTable.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
            testingTable.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                create_err.Text = "";
                string person_name = name.Text;
                string person_surname = surname.Text;
                string person_gender = (man.Checked) ? "мужской" : "женский";
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

                //people.Add(newPerson);
                create_err.Text = "Готово!";

                name.Text = "";
                surname.Text = "";
                year_of_birth.Text = "2000";
                city.Text = "";
                country.Text = "";
                height.Text = "";
            }
            catch (MyOverflowException ex)
            {
                Win32.MessageBox(0, ex.Message + "\n" + ex.TimeOfExeption.ToString(), "Перенаселение", 0);
            }
            catch (PersonArgumentExeption ex)
            {
                create_err.Text = ex.Message + "\n" + ex.TimeOfExeption.ToString();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }
    }
}
