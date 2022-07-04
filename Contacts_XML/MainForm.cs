using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Contacts_XML
{
    public partial class MainForm : Form
    {
        Person oldPerson = null;
        public MainForm()
        {
            InitializeComponent();
        }
        public class Person
        {
            public int Age { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public void CreatePerson(int age, string firstName, string lastName)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("people.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            XmlElement personElem = xDoc.CreateElement("person");
            XmlElement ageElem = xDoc.CreateElement("age");
            XmlElement firstNameElem = xDoc.CreateElement("firstName");
            XmlElement lastNameElem = xDoc.CreateElement("lastName");
            XmlText ageText = xDoc.CreateTextNode(age.ToString());
            XmlText firstNameText = xDoc.CreateTextNode(firstName);
            XmlText lastNameText = xDoc.CreateTextNode(lastName);
            ageElem.AppendChild(ageText);
            firstNameElem.AppendChild(firstNameText);
            lastNameElem.AppendChild(lastNameText);
            personElem.AppendChild(ageElem);
            personElem.AppendChild(firstNameElem);
            personElem.AppendChild(lastNameElem);
            xRoot?.AppendChild(personElem);
            xDoc.Save("people.xml");
        }
        public IEnumerable<Person> GetAll()
        {
            XDocument xml = XDocument.Load("people.xml");

            var persons = xml.Element("persons")
                             .Elements("person")
                             .Select(p => new Person
                             {
                                 Age = int.Parse(p.Element("age").Value),
                                 FirstName = p.Element("firstName").Value,
                                 LastName = p.Element("lastName").Value
                             });
            return persons;
        }
        public IEnumerable<Person> Get(int age, string firstName, string lastName)
        {
            XDocument xml = XDocument.Load("people.xml");

            var person = xml.Element("persons")
                            .Elements("person")
                            .Where(a => int.Parse(a.Element("age").Value) == age)
                            .Where(fn => fn.Element("firstName").Value == firstName)
                            .Where(ln => ln.Element("lastName").Value == lastName)
                            .Select(p => new Person
                            {
                                Age = int.Parse(p.Element("age").Value),
                                FirstName = p.Element("firstName").Value,
                                LastName = p.Element("lastName").Value
                            });
            return person;
        }
        public void Delete(int age, string firstName, string lastName)
        {
            XDocument xml = XDocument.Load("people.xml");

            var person = xml.Element("persons")
                            .Elements("person")
                            .Where(a => int.Parse(a.Element("age").Value) == age)
                            .Where(fn => fn.Element("firstName").Value == firstName)
                            .Where(ln => ln.Element("lastName").Value == lastName)
                            .Select(p => p)
                            .FirstOrDefault();
            if (person != null)
            {
                person.Remove();
                xml.Save("people.xml");
            }
        }
        public void Update(int age, string firstName, string lastName,
                           int newAge, string newFirstName, string newLastName)
        {
            XDocument xml = XDocument.Load("people.xml");

            var person = xml.Element("persons")
                            .Elements("person")
                            .Where(a => int.Parse(a.Element("age").Value) == age)
                            .Where(fn => fn.Element("firstName").Value == firstName)
                            .Where(ln => ln.Element("lastName").Value == lastName)
                            .Select(p => p)
                            .FirstOrDefault();
            if (person != null)
            {
                var updatedAge = person.Element("age").Value = newAge.ToString();
                var updatedFirstName = person.Element("firstName").Value = newFirstName.ToString();
                var updatedLastName = person.Element("lastName").Value = newLastName.ToString();
                xml.Save("people.xml");
            }
        }
        public Person SavePerson(int age, string firstName, string lastName)
        {
            var person = new Person()
            {
                Age = age,
                FirstName = firstName,
                LastName = lastName
            };
            return person;
        }
        public void DataGridViewUpdate(IEnumerable<Person> persons)
        {
            dGVContacts.DataSource = null;
            dGVContacts.DataSource = persons.ToList();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataGridViewUpdate(GetAll());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if ((tBAge.Text != "") && (tBFirstName.Text != "") && (tBLastName.Text != ""))
                CreatePerson(int.Parse(tBAge.Text), tBFirstName.Text, tBLastName.Text);
            DataGridViewUpdate(GetAll());
            tBAge.Text = null;
            tBFirstName.Text = null;
            tBLastName.Text = null;
        }

        private void dGVContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Person person = Get(int.Parse(dGVContacts.Rows[dGVContacts.SelectedCells[0].RowIndex].Cells[0].Value.ToString()),
                dGVContacts.Rows[dGVContacts.SelectedCells[0].RowIndex].Cells[1].Value.ToString(),
                dGVContacts.Rows[dGVContacts.SelectedCells[0].RowIndex].Cells[2].Value.ToString()).ToList().First();
            tBAge.Text = person.Age.ToString();
            tBFirstName.Text = person.FirstName.ToString();
            tBLastName.Text = person.LastName.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if ((tBAge.Text != "") && (tBFirstName.Text != "") && (tBLastName.Text != ""))
                Delete(int.Parse(tBAge.Text), tBFirstName.Text, tBLastName.Text);
            DataGridViewUpdate(GetAll());
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (oldPerson != null)
                Update(oldPerson.Age, oldPerson.FirstName, oldPerson.LastName,
                           int.Parse(tBAge.Text), tBFirstName.Text, tBLastName.Text);
            DataGridViewUpdate(GetAll());
        }
        private void tB_Click(object sender, EventArgs e)
        {
            if ((tBAge.Text != "") && (tBFirstName.Text != "") && (tBLastName.Text != ""))
                oldPerson = SavePerson(int.Parse(tBAge.Text), tBFirstName.Text, tBLastName.Text);
        }
    }
}
