using System.Configuration;
using System.Reflection;
using MessageBird;
using Newtonsoft.Json;
using RestSharp;
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
            //MessageBox.Show("Hello");
            ////Create a Document instance
            //Document doc = new Document();
            ////Add a section
            //Section section = doc.AddSection();
            ////Add a paragraph
            //Paragraph para = section.AddParagraph();
            ////Append text to the paragraph
            //para.AppendText("Hello World Joachim");
            ////Save the result document
            //doc.SaveToFile(@"G:\Output.docx", FileFormat.Docx2013);

            //Assembly assembly = Assembly.GetExecutingAssembly();
            //var lovResourceStream = assembly.GetManifestResourceStream("ToetsenGenerator.6ITN-namenlijst.txt");
            //StreamReader lovReader = new StreamReader(lovResourceStream);
            //MessageBox.Show(lovReader.ReadToEnd());

            //string YourAccessKey = ConfigurationManager.AppSettings.Get("API_KEY_MESSAGE_BIRD");
            //Client client = Client.CreateDefault(YourAccessKey);
            //const long Msisdn = +32477069583; // your phone number here

            //var lovHello = ConfigurationManager.AppSettings.Get("Key0");

            //MessageBird.Objects.Message message =
            //client.SendMessage("TestMessage", "Tjirp_yOO", new[] { Msisdn });

            var client = new RestClient("https://api.haltelink.be");
            var request = new RestRequest("/trips/BE.NMBS.008891009", Method.Get);
            var queryResult = client.ExecuteAsync(request);
            var lovResult = queryResult.Result;
            //MessageBox.Show(format_json(lovResult.Content));

            dynamic array = JsonConvert.DeserializeObject(lovResult.Content);

            foreach (var itemx in array["trips"])
            {
                //MessageBox.Show(itemx.ToString());
            }
            dynamic array2 = JsonConvert.DeserializeObject(lovResult.Content);

            var lovList = array2["trips"];
        }

        private static string format_json(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }
    }
}