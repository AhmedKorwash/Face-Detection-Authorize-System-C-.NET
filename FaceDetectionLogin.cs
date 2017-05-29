using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Pattern
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.IO;
using MySql.Data.MySqlClient;
using System.Drawing.Imaging;
namespace Social_Processor
{
    public partial class FaceDetectionLogin : Form
    {
        Image<Bgr, Byte> currentFrame;
        Capture grabber;
        HaarCascade face;
        List<string> JustTrained;
       // HaarCascade eye;
        MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
        Image<Gray, byte> result, TrainedFace = null;
        Image<Gray, byte> gray = null;
        List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        List<string> labels = new List<string>();
        List<string> NamePersons = new List<string>();
        int ContTrain, NumLabels, t;
        string name, names = null;
        private RunMainPage loginEvent;
        public FaceDetectionLogin(RunMainPage login)
        {
            this.loginEvent = login;
            InitializeComponent();
            face = new HaarCascade("haarcascade_frontalface_default.xml");
        }
        void FrameGrabber(object sender, EventArgs e)
        {
            label3.Text = "0";
            //label4.Text = "";
            NamePersons.Add("");
            //Get the current frame form capture device
            currentFrame = grabber.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            //Convert it to Grayscale
            gray = currentFrame.Convert<Gray, Byte>();
            //Face Detector
            MCvAvgComp[][] facesDetected = gray.DetectHaarCascade(
          face,
          1.2,
          10,
          Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
          new Size(20, 20));

            //Action for each element detected
            foreach (MCvAvgComp f in facesDetected[0])
            {
                t = t + 1;
                result = currentFrame.Copy(f.rect).Convert<Gray, byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                //draw the face detected in the 0th (gray) channel with blue color
                currentFrame.Draw(f.rect, new Bgr(Color.Red), 2);
                if (trainingImages.ToArray().Length != 0)
                {
                    //TermCriteria for face recognition with numbers of trained images like maxIteration
                    MCvTermCriteria termCrit = new MCvTermCriteria(ContTrain, 0.001);

                    //Eigen face recognizer
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(
                       trainingImages.ToArray(),
                       labels.ToArray(),
                       3000,
                       ref termCrit);

                    name = recognizer.Recognize(result);
                    if(name != null)
                        if(name != string.Empty)
                    JustTrained.Add(name);
                    //Draw the label for each face detected and recognized
                    currentFrame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.LightGreen));
                }
                NamePersons[t - 1] = name;
                NamePersons.Add("");
                //Set the number of faces detected on the scene
                label3.Text = facesDetected[0].Length.ToString();
                if (facesDetected[0].Length > 1)
                {
                    MessageBox.Show("I Have See More than Face Please Ask another Person gone for a seconed..","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            t = 0;
            //Names concatenation of persons recognized
            if(JustTrained.Count > 5)
            if(JustTrained[0] != null)
                if (JustTrained[0] != string.Empty)
                {
                    loginEvent.Invoke();
                    FunctionsTools.FillLoginAuth(JustTrained[0]);
                    grabber.Dispose();
                    this.Close();
                }
            //Show the faces procesed and recognized
            imageBoxFrameGrabber.Image = currentFrame;
            label4.Text = names;
            names = "";
            //Clear the list(vector) of names
            NamePersons.Clear();
        }
        private void FaceDetectionLogin_Load(object sender, EventArgs e)
        {
            JustTrained = new List<string>();
            grabber = new Capture();
            grabber.QueryFrame();
            //Initialize the FrameGraber event
            Application.Idle += new EventHandler(FrameGrabber);
            RunChecker();
        }
        private static Image stringToImage(string inputString)
        {
            byte[] imageBytes = Encoding.Unicode.GetBytes(inputString);


            Image image = Image.FromFile(inputString);

            return image;
        }
        private void RunChecker()
        {
            MySqlDataReader reader = null;
            
                try
                {
                    string query = "SELECT * FROM UserImage";
                    if (Program.conn1.State == ConnectionState.Closed)
                    {
                        Program.conn1.Open();
                    }
                    MySqlCommand cmd = new MySqlCommand(query, Program.conn1);
                    labels = new List<string>();
                    trainingImages = new List<Image<Gray, byte>>();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {   
                        labels.Add(reader["name"].ToString());
                        string image = reader["image"].ToString();
                        var bytes = Convert.FromBase64String(image);
                        using (var imageFile = new FileStream("myfile"+labels.Count+".bmp", FileMode.Create))
                        {
                            imageFile.Write(bytes, 0, bytes.Length);
                            imageFile.Flush();
                        }
                        string path = Application.StartupPath + "/myfile" + labels.Count + ".bmp";
                        trainingImages.Add(new Image<Gray, byte>(path).Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC));
                        NumLabels++;
                        File.Delete(path);
                    }
                    //Load of previus trainned faces and labels for each image
                    ContTrain = NumLabels;
                    reader.Close();
                }
                catch (Exception x)
                {
                    //MessageBox.Show(e.ToString());
                    MessageBox.Show("Nothing in binary database, please add at least a face(Simply train the prototype with the Add Face Button).", "Triained faces load", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    reader.Close();
                }
            }
        }
        
    }

