using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;


namespace Informatikos_projektas
{
	class MainClass
	{

		public void loadWords (List <string> wordList)
		{
			Console.WriteLine("Loading word list from file...");
			const string f = "words.txt";
			try{
				using (StreamReader sr = new StreamReader(f))
				{
					String line;
				while ((line = sr.ReadLine ()) != null)
				{
					//line.ToLower();
					wordList.Add (line.ToLower());
				}
				wordList = wordList.ConvertAll(low => low.ToLowerInvariant());
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The file could not be read:");
				Console.WriteLine(e.Message);
			}
		}
		//------------------------------------------------//
		public string dealHand(int n)
		{
			string Vowels = "aeiou";
			char[] AllLetters = {'b','c','d','f','g','h','j','k','l','m','n','p','q','r','s','t','v','w','x','y','z','a','e','i','o','u'
			};
			char[] VowelsArray = Vowels.ToCharArray();
			char [] handArray = new char[n]; 
			string hand="";
			Random numGenerator = new Random ();
			for (int i = 0; i < 3; i++)
				handArray [i] = Vowels [numGenerator.Next (0, 5)];
			for (int j = 3; j < n; j++)
				handArray [j] = AllLetters [numGenerator.Next (0, 26)];
			hand =  new string(handArray);	
			return hand;
			}
		//------------------------------------------------//
		public void displayHand (string hand)
		{
			char[] sym = hand.ToCharArray();
			for (int i = 0; i < sym.Length; i++) 
			{
				Console.Write (sym [i]);
				Console.Write (" ");
			}
			Console.Write ("\n");
		}
		//------------------------------------------------//
		public int getWordScore (string input, int n)
		{
			char[] sym = input.ToCharArray();
				int ans = 0;
			for (int i=0; i<input.Length; i++)
			{
				switch (sym[i]) {
				case'a': ans += 1; break;
				case'e': ans += 1; break;
				case'i': ans += 1; break;
				case'o': ans += 1; break;
				case'r': ans += 1; break;
				case's': ans += 1; break;
				case't': ans += 1; break;
				case'u': ans += 1; break;
				case'n': ans += 1; break;
				case'd': ans += 2; break;
				case'g': ans += 2; break;
				case'b': ans += 3; break;
				case'c': ans += 3; break;
				case'm': ans += 3; break;
				case'p': ans += 3; break;
				case'f': ans += 4; break;
				case'h': ans += 4; break;
				case'v': ans += 4; break;
				case'w': ans += 4; break;
				case'y': ans += 4; break;
				case'k': ans += 5; break;
                case'l': ans += 5; break;
				case'j': ans += 8; break;
				case'x': ans += 8; break;
				case'q': ans += 10; break;
				case'z': ans += 10; break;
				}
				}
			if (input.Length == n)
					ans += 50;
				return ans;
		}
		//------------------------------------------------//
		/*patikrina ar sarase ira ivestas zodis*/
		public bool isValidWord (string input, string hand,  List <string> wordList)
		{
			bool check = false;
			for (int i = 0; i < wordList.Count; i++)
				if(wordList[i] == input){
					check = true;
				}
			return check;
		}
		//------------------------------------------------//
		/*Tikrina ar visos ivestos raides yra rankoj, galutinej versijoj tikriausiai nebebus eikalinga*/  /* Taip, del to ir nepridedu :) M. */
		public bool genueLetters (string input, string hand)
		{
			bool check1;
			for (int i = 0; i < input.Length; i++)
			{
				check1=false;
				for (int j = 0; j < hand.Length; j++)
				{
					if (input [i] == hand [j]) {
						check1 = true;
						break;
					}
				}
				if (check1 == false)
						return false;
			}
			return true;
		}
		//------------------------------------------------//
		/*Apskaiciuoja kiek rankoje yra raidziu*/
		public int  calculateHandlen (string hand)
		{
			int len = 0;
			for (int i = 0; i < hand.Length; i++) 
			{
				char[] sym = hand.ToCharArray ();
				if (hand [i] == Convert.ToChar(" ")) // skaiciuoja kiek rankoj yra simboliu iki pirmo tarpo
					return len;
				else
				len++;
			}
			return len;
		}
		//------------------------------------------------//
		/*Pasalina panaudotas raides*/
		public string deleteUsed (string hand, int n, string input)
		{
			char[] symh = hand.ToCharArray();
			char[] symi = input.ToCharArray();
			for (int i = 0; i < symi.Length; i++) 
				for (int j = 0; j < symh.Length; j++)
				{
					if (symh [j] == symi [i]) {
						for (int l = j; l < symh.Length - 1; l++)
							symh [l] = symh [l + 1];                             //Is rankos pasalina panaudotas raides, perstumiant reiksmes su didesniu indeksu i ju vieta
						symh [symh.Length - 1] = Convert.ToChar (" ");           //Paskutini simboli pakeicia tarpu, kad nebutu daug vienodu simboliu po perstumimo
						break;
					}    
				}
			hand =  new string(symh);
			return hand;
		}
		//------------------------------------------------//
		public void playHand (string hand, List <string> wordList, int n)
		{
			int score, sumScore=0;
			string input, handnew=hand;
			bool match;
			Console.WriteLine ("your letters:");
			displayHand (handnew);
			while (calculateHandlen(hand)>= 0) //vygdo cikla kol rankoje yra raidziu
				{
					Start:
					Console.WriteLine ("Enter word, or . to end the hand");
					input = Convert.ToString (Console.ReadLine ());
					if (input == ".")
					break; // Jei ivedamas . iseina is ciklo
				if (genueLetters (input, handnew) == false) 
				{
					Console.WriteLine ("You entered a letter witch is not in your hand, try again.");
					goto Start;  //Jei ivedama neturima raide, gryzta i ciklo pradzia
				}
					match = isValidWord (input, handnew, wordList);
					if (match == false)
					{
						Console.WriteLine("Ops, there is a mistake! Check your spelling.");
						goto Start; // jei sarase nera ivesto zodzio grizta i ciklo pradzia
					}
					score = getWordScore (input, n);
					Console.WriteLine("Score of word that you entered: "+score);
					handnew = deleteUsed (handnew, n, input);
				Console.WriteLine ("Remaining letters");
				deleteUsed (handnew, n, input);
				displayHand (handnew);
					sumScore += score;
				}
			Console.WriteLine ("The end of this hand");
			Console.WriteLine ("Your total score of this hand: " + sumScore + " points");
		}
		//------------------------------------------------//

       
		public static void Main (string[] args)
			{

            //```````````````````````````//
         

            Form1 Langas = new Form1();
            Langas.ShowDialog();
            //``````````````gui``````````````//
           

            /*
			MainClass load = new MainClass ();
			List<string> wordList = new List <string> ();
			load.loadWords(wordList);
			string hand = "";  //raides is kuriu deliojami zodziai (cia reikalingos tik patikrinimui)
			int n = 7;
			MainClass play = new MainClass ();
			MainClass deal = new MainClass ();
			string x = "n";
			while (x != "e")
			{
				if (x == "n")
				{
					hand = deal.dealHand(n);
					x = "r";
				}
				if (x == "r")
				{
					Console.WriteLine("Zaidimas pradedamas");
					play.playHand(hand, wordList, n);
				}
				else 
					Console.WriteLine("Your input was invalid");
				Console.WriteLine("-------------------------------");
				Console.WriteLine("---|Start new  game press n|---");
				Console.WriteLine("-------------------------------");
				Console.WriteLine("---|Start last game press r|---");
				Console.WriteLine("-------------------------------");
				Console.WriteLine("---|Exit  the  game press e|---");
				Console.WriteLine("-------------------------------");
				string a = Convert.ToString(Console.ReadLine());
				x = a;
             
			}
            */
		}
	}
}

