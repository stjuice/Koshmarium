using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApp8
{
    public class Card
    {
        public ImageBrush img { get; set; }
        public string color { get; }
        public string type { get; }
        public string part { get; }

        public Card(ImageBrush img, string color, string type, string part) {
            this.img = new ImageBrush();
            this.img = img;

            this.color = color;
            this.type = type;
            this.part = part;
        }

        //checkColor
        //checkType
        //checkPart
        //makeBrush

    }

    public class Deck
    {
        List<Card> cards = new List<Card>();

        //shuffle
        //remove

    }


    public class Hand
    {
        List<Card> my_cards;
        Card temp;

        //take
        //give


    }
  //  public class 

    public partial class MainWindow : Window
    {   List<Card> cards = new List<Card>();//не делать глобальных переменных

        public MainWindow()
        {
            InitializeComponent();
           // MessageBox.Show((Directory.GetCurrentDirectory()+("\\images\\")).ToString());
            addCards();
            
        }

        public void addCards()
        {
            

            string[] a = Directory.GetFiles(Directory.GetCurrentDirectory()+("\\images\\"));
            //cards.AddRange(a);
           
            foreach (string name in a)
            {
                if (name.Contains("back"))
                {  ImageBrush tm = new ImageBrush();
                    tm.ImageSource = new BitmapImage(new Uri(name, UriKind.Absolute));
                    deck.Fill = tm;
                    
                }
                else
                {


                    ImageBrush br = new ImageBrush();
                    br.ImageSource = new BitmapImage(new Uri(name, UriKind.Absolute));//img

                    string color = findColor(name);
                    string type = findType(name);
                    string part = findPart(name);


                    cards.Add(new Card(br, color, type, part));
                }

            }



        }

        public void view(Card card)
        {

            //ImageBrush br = new ImageBrush();
            //br.ImageSource = new BitmapImage(new Uri(card, UriKind.Absolute));
            //System.Threading.Thread.Sleep(1000);
            // MessageBox.Show(br.ImageSource.ToString());



            //box1.Fill = card.img;
            int i = 0;
            foreach (UIElement c in Hand.Children)
            {
                //MessageBox.Show("0");
                if (i==0)
                {
                    //MessageBox.Show("1");
                    if (((Rectangle)c).Fill == null)
                    {
                       // MessageBox.Show("2");
                        ((Rectangle)c).Fill = card.img;
                        i++;
                    }
                }
               
            }
            if (i == 0) { MessageBox.Show("Deck is full"); }
            // MessageBox.Show(card.color + '\n' + card.part + '\n' + card.type);
            /* MessageBox.Show(box1.Fill.ToString());
             box1.Fill = null;
             if (box1.Fill is null)
             {
                 MessageBox.Show("2");
             }
             */
        }
        private void box_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
        }
        private void box_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //ImageBrush card = cards[cards.Count - 1].img;
            view(cards[cards.Count - 1]);
            cards.RemoveAt(cards.Count - 1);
        }

        private string findColor(string name)
        {
            string color = "";

            if (name.Contains("blue")) { color = "blue"; }
            else if (name.Contains("green")) { color = "green"; }
            else if (name.Contains("bronze")) { color = "bronze"; }
            else if (name.Contains("pink")) { color = "pink"; }

            return color;
        }

        private string findType(string name)
        {
            string type = "non";

            if (name.Contains("bones")) { type = "bones"; }
            else if (name.Contains("plakalshchik")) { type = "plakalshchik"; }
            else if (name.Contains("vampir")) { type = "vampir"; }
            else if (name.Contains("peresmeshnik")) { type = "peresmeshnik"; }
            else if (name.Contains("volk")) { type = "volk"; }
            else if (name.Contains("palach")) { type = "palach"; }

            return type;
        }

        private string findPart(string name)
        {
            string part = "";

            if (name.Contains("head")) { part += "head"; }
            else if (name.Contains("body")) { part += "body"; }
            else if (name.Contains("legs")) { part += "legs"; }

            return part;
        }

    }

}
