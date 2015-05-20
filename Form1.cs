using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Informatikos_projektas
{
    public partial class Form1 : Form
    {
        static char[] globalhand;
        static char[] globalBoard = new char[7];
        static int pts;
        MainClass load = new MainClass();
        List<string> wordList = new List<string>();

        
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                dispBoard(globalhand[0]);
                pictureBox1.Image = null;
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                dispBoard(globalhand[1]);
                pictureBox2.Image = null;
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image != null)
            {
                dispBoard(globalhand[2]);
                pictureBox3.Image = null;
            }
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (pictureBox4.Image != null)
            {
                dispBoard(globalhand[3]);
                pictureBox4.Image = null;
            } 
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (pictureBox5.Image != null)
            {
                dispBoard(globalhand[4]);
                pictureBox5.Image = null;
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (pictureBox6.Image != null)
            {
                dispBoard(globalhand[5]);
                pictureBox6.Image = null;
            }
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (pictureBox7.Image != null)
            {
                dispBoard(globalhand[6]);
                pictureBox7.Image = null;
            } 
        }

        private void boardPic1_Click(object sender, EventArgs e) 
        {
            if (boardPic1.Image != null)
            {
                dispHand(globalBoard[0]);
                boardPic1.Image = null;
                globalBoard[0] = (char)0;
            } 
        }

        private void boardPic2_Click(object sender, EventArgs e)
        {
            if (boardPic2.Image != null)
            {
                dispHand(globalBoard[1]);
                boardPic2.Image = null;
                globalBoard[1] = (char)0;
            }
        }

        private void boardPic3_Click(object sender, EventArgs e)
        {
            if (boardPic3.Image != null)
            {
                dispHand(globalBoard[2]);
                boardPic3.Image = null;
                globalBoard[2] = (char)0;
            }
        }

        private void boardPic4_Click(object sender, EventArgs e)
        {
            if (boardPic4.Image != null)
            {
                dispHand(globalBoard[3]);
                boardPic4.Image = null;
                globalBoard[3] = (char)0;
            }
        }

        private void boardPic5_Click(object sender, EventArgs e)
        {
            if (boardPic5.Image != null)
            {
                dispHand(globalBoard[4]);
                boardPic5.Image = null;
                globalBoard[4] = (char)0;
            }
        }

        private void boardPic6_Click(object sender, EventArgs e)
        {
            if (boardPic6.Image != null)
            {
                dispHand(globalBoard[5]);
                boardPic6.Image = null;
                globalBoard[5] = (char)0;
            }
        }

        private void boardPic7_Click(object sender, EventArgs e)
        {
            if (boardPic7.Image != null)
            {
                dispHand(globalBoard[6]);
                boardPic7.Image = null;
                globalBoard[6] = (char)0;
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            String word;
            word = "";

            for (int i=0; i < 7; i++)
            {
                if (globalBoard[i] != (char)0) word += globalBoard[i];
            }
            load.loadWords(wordList);
            bool isValid = load.isValidWord(word, null, wordList);

            if (isValid)
            {
                
                MessageBox.Show("Congratulations! You guessed word correctly!", "Success",
                    MessageBoxButtons.OK);
                clearBoard();
                getPoints(word);
            }
            else
            {
                MessageBox.Show("Oops, there is a mistake! Check your spelling.", "Please try again.",
                    MessageBoxButtons.OK);
            }
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            clearBoard();
            
            string hand = "";  
            int n = 7;
            MainClass play = new MainClass();
            MainClass deal = new MainClass();
            hand = deal.dealHand(n);
            globalhand = hand.ToCharArray();
            dispPics(hand.ToCharArray());
            musicPlayer();
           

            
        }



        private void dispHand(char letter)
        {
            if (pictureBox1.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                pictureBox1.Image = paveiksl;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                globalhand[0] = letter;
            }

            else if (pictureBox2.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                pictureBox2.Image = paveiksl;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                globalhand[1] = letter;
            }

            else if (pictureBox3.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                pictureBox3.Image = paveiksl;
                pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
                globalhand[2] = letter;
            }

            else if (pictureBox4.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                pictureBox4.Image = paveiksl;
                pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
                globalhand[3] = letter;
            }

            else if (pictureBox5.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                pictureBox5.Image = paveiksl;
                pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
                globalhand[4] = letter;
            }

            else if (pictureBox6.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                pictureBox6.Image = paveiksl;
                pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
                globalhand[5] = letter;
            }

            else if (pictureBox7.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                pictureBox7.Image = paveiksl;
                pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
                globalhand[6] = letter;
            }

        }


        private void dispBoard(char letter)
        {
            if (boardPic1.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                boardPic1.Image = paveiksl;
                boardPic1.SizeMode = PictureBoxSizeMode.Zoom;
                globalBoard[0] = letter;
            }
            else if (boardPic2.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                boardPic2.Image = paveiksl;
                boardPic2.SizeMode = PictureBoxSizeMode.Zoom;
                globalBoard[1] = letter;
            }
            else if (boardPic3.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                boardPic3.Image = paveiksl;
                boardPic3.SizeMode = PictureBoxSizeMode.Zoom;
                globalBoard[2] = letter;
            }
            else if (boardPic4.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                boardPic4.Image = paveiksl;
                boardPic4.SizeMode = PictureBoxSizeMode.Zoom;
                globalBoard[3] = letter;
            }
            else if (boardPic5.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                boardPic5.Image = paveiksl;
                boardPic5.SizeMode = PictureBoxSizeMode.Zoom;
                globalBoard[4] = letter;
            }
            else if (boardPic6.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                boardPic6.Image = paveiksl;
                boardPic6.SizeMode = PictureBoxSizeMode.Zoom;
                globalBoard[5] = letter;
            }
            else if (boardPic7.Image == null)
            {
                String path = Environment.CurrentDirectory;
                path = path + "\\Letters\\" + letter + ".png";
                Image paveiksl = Image.FromFile(path);
                boardPic7.Image = paveiksl;
                boardPic7.SizeMode = PictureBoxSizeMode.Zoom;
                globalBoard[6] = letter;
            }
        }



        private void dispPics(Char[] hand)
        {

            String path = Environment.CurrentDirectory;
            path = path + "\\Letters\\" + hand[0] + ".png";
            Image paveiksl = Image.FromFile(path);
            pictureBox1.Image = paveiksl;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            path = Environment.CurrentDirectory;
            path = path + "\\Letters\\" + hand[1] + ".png";
            paveiksl = Image.FromFile(path);
            pictureBox2.Image = paveiksl;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;

            path = Environment.CurrentDirectory;
            path = path + "\\Letters\\" + hand[2] + ".png";
            paveiksl = Image.FromFile(path);
            pictureBox3.Image = paveiksl;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;

            path = Environment.CurrentDirectory;
            path = path + "\\Letters\\" + hand[3] + ".png";
            paveiksl = Image.FromFile(path);
            pictureBox4.Image = paveiksl;
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;

            path = Environment.CurrentDirectory;
            path = path + "\\Letters\\" + hand[4] + ".png";
            paveiksl = Image.FromFile(path);
            pictureBox5.Image = paveiksl;
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;

            path = Environment.CurrentDirectory;
            path = path + "\\Letters\\" + hand[5] + ".png";
            paveiksl = Image.FromFile(path);
            pictureBox6.Image = paveiksl;
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;

            path = Environment.CurrentDirectory;
            path = path + "\\Letters\\" + hand[6] + ".png";
            paveiksl = Image.FromFile(path);
            pictureBox7.Image = paveiksl;
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;

        }

        private void clearBoard()
        {
            boardPic1.Image = null;
            boardPic2.Image = null;
            boardPic3.Image = null;
            boardPic4.Image = null;
            boardPic5.Image = null;
            boardPic6.Image = null;
            boardPic7.Image = null;

            for (int i = 0; i<7; i++)
            {
                globalBoard[i] = (char)0;
            }
        }

        private void getPoints(string word)
        {
            int ans =+ load.getWordScore(word, 7);
            pts = pts+ ans;
            label1.Text = pts.ToString();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        
        private void restart_Click(object sender, EventArgs e)
        {
            clearBoard();
            string hand = "";
            int n = 7;
            MainClass play = new MainClass();
            MainClass deal = new MainClass();
            hand = deal.dealHand(n);
            globalhand = hand.ToCharArray();
            dispPics(hand.ToCharArray());
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
        }
            
        public void musicPlayer()
        {


            String musicPath;
            musicPath = Environment.CurrentDirectory + "\\music.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(musicPath);
            player.PlayLooping();

     
            
            
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
