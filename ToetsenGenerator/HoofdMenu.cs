using System.Reflection;
using MessageBird;
using Spire.Doc;
using Spire.Doc.Documents;

namespace ToetsenGenerator
{
    public partial class HoofdMenu : Form
    {
        public HoofdMenu()
        {
            InitializeComponent();
        }

        private void ToetsenGenereerKnop_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
            //Create a Document instance
            Document doc = new Document();
            //Add a section
            Section section = doc.AddSection();
            //Add a paragraph
            Paragraph para = section.AddParagraph();
            //Append text to the paragraph
            para.AppendText("Hello World Joachim");
            //Save the result document
            doc.SaveToFile(@"G:\Output.docx", FileFormat.Docx2013);

            Assembly assembly = Assembly.GetExecutingAssembly();
            var lovResourceStream = assembly.GetManifestResourceStream("ToetsenGenerator.6ITN-namenlijst.txt");
            StreamReader lovReader = new StreamReader(lovResourceStream);
            MessageBox.Show(lovReader.ReadToEnd());

            const string YourAccessKey = "TtZDSAE3VOLEbb85ZdtqnnvEh"; // your access key here
            Client client = Client.CreateDefault(YourAccessKey);
            const long Msisdn = +32477069583; // your phone number here

            MessageBird.Objects.Message message =
            client.SendMessage("TestMessage", "Tjirp", new[] { Msisdn });
        }
    }
}