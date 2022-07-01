using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Contacts_XML
{
    public partial class MainForm : Form
    {
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
        public void DataGridViewUpdate()
        {
            dGVContacts.DataSource = null;
            dGVContacts.DataSource = GetAll().ToList();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            DataGridViewUpdate();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreatePerson(int.Parse(tBAge.Text), tBFirstName.Text, tBLastName.Text);
            DataGridViewUpdate();
        }
    }
}
