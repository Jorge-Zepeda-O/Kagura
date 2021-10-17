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
using System.Windows.Threading;

namespace Kagura
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void RateSongs(object sender, RoutedEventArgs e)
		{
			string songsPath = SongsPath.Text;// "A:\\Games\\StepMania 5.0.12\\Testing\\";
			bool debug = BtnDebug.IsChecked.Value;
			bool write = BtnWrite.IsChecked.Value;
			bool stats = BtnStats.IsChecked.Value;
			List<string> tofile = new List<string>();
			
			// Get Packs //
			string[] packs = Directory.GetDirectories(songsPath);
			for(int p = 0; p < packs.Length; p++)
			{   // Get Songs //
				string pack = packs[p];
				string[] songs = Directory.GetDirectories(pack);
				PacksDone.Text = "Pack #" + (p + 1) + "/" + packs.Length;
				PacksDone.Refresh();

				for (int s = 0; s < songs.Length; s++)
				{   // Check if the appropriate files exist //
					string song = songs[s];
					string[] files = Directory.GetFiles(song);
					string[] smfiles = Directory.GetFiles(song, "*.sm");

					if (smfiles.Length > 0)
					{   // We found what we're looking for //
						try
						{
							string content = File.ReadAllText(smfiles[0]);
							string[] sections = content.Split(new char[] { ';' });

							// Create a new Song object //
							Song thissong = new Song(song, smfiles[0], sections, write);
							if (debug)
							{
								if (thissong.Title.Contains("TWO"))
									Output.Text += thissong.Debug[4];
							}
							else
							{
								for (int n = 0; n < 6; n++)
								{
									if (thissong.Meter[n] == 0) continue;
									tofile.Add(thissong.Meter[n].ToString("F1") + "," + (thissong.Level[n] / 10.0).ToString("F1"));								}

								string ratinginfo = "\t--- " + thissong.Title + " (" + thissong.Error.ToString("F2") + ") ---\n Diff: ";
								string[] diffs = { "Noob", "Easy", "Med", "Hard", "Xprt", "Edit" };
								for (int n = 0; n < 6; n++)
									if (thissong.Meter[n] > 0)
										ratinginfo += diffs[n] + "\t";
								ratinginfo += "\n  DDR: \t";
								for (int n = 0; n < 6; n++)
									if (thissong.Meter[n] > 0)
										ratinginfo += thissong.Meter[n] + "\t";
								ratinginfo += "\nKagura:\t";
								for (int n = 0; n < 6; n++)
									if (thissong.Meter[n] > 0)
										ratinginfo += (thissong.Level[n] / 10.0).ToString("F1") + "\t";

								Output.Text = ratinginfo + "\n\n" + Output.Text;
							}
						}
						catch(Exception)
						{
							Output.Text = "An error occurred here:\n" +	song + "\n\n" + Output.Text;
						}
						
					}
					else if(files.Length > 0)
					{	// We didn't find any .sm files, but we found something else //

					}
					else
					{	// We didn't find anything! //

					}

					Progress.Value = 100 * (s + 1) / (double)songs.Length;
					Progress.Refresh();
					Output.Refresh();
				}
			}
			//*/
			if(stats)
				File.WriteAllLines(songsPath + "ratings.csv", tofile);
			
			// Binary Search //
			/*
			byte minskill = 55;
			byte maxskill = 55;
			byte skill = (byte)((maxskill + minskill) / 2);
			int iter = (int)Math.Ceiling(Math.Log(maxskill) / Math.Log(2)) + 1;

			var watch = new System.Diagnostics.Stopwatch();
			watch.Start();

			// Chart Generation //
			Arrow[] chart = new Arrow[6];
			Random rng = new Random(0);
			chart[0] = new Arrow("2222".ToCharArray(), time: 1);
			chart[1] = new Arrow("0000".ToCharArray(), time: 2);
			chart[2] = new Arrow("0003".ToCharArray(), time: 3);
			chart[3] = new Arrow("003M".ToCharArray(), time: 4);
			chart[4] = new Arrow("03M0".ToCharArray(), time: 5);
			chart[5] = new Arrow("3M00".ToCharArray(), time: 6);

			Player p1 = new Player(65);
			string res = p1.Play(chart);
			*/
			/*
			for (int n = 0; n < chart.Length; n++)
			{
				char[] line = new char[4] { '0', '0', '0', '0' };

				int val = rng.Next(3) - 1;//rng.Next(5);
				int k = 0;
				//int[] idx = { 0, 1, 3, 2 };
				while (val > 0)
				{
					val -= 5 - k;
					line[rng.Next(4)] = '1';
				}

				chart[n] = new Arrow(line, time: (n+1) / 8.0);
			}
			

			string res = "";
			for (int i = 0; i < iter; i++)
			{
				// Create a new player //
				Player p1 = new Player(skill);
				bool alive = true;

				// Play through the Chart //
				int lastarrow = 0;
				for(int n = 0; n < chart.Length; n++)
				{
					if(!chart[n].IsEmpty())
						alive = p1.Update(chart[n]);
					if (!alive)
					{
						lastarrow = n;
						break;
					}
				}

				// Evaluate and update //
				res += skill + " " + (alive ? chart.Length : lastarrow) + " " + p1.Energy.ToString("F0") + "\n";
				if (alive)	maxskill = skill;
				else		minskill = skill;

				if (maxskill - minskill < 2)
				{
					if (alive)
					{
						res += maxskill + " <<< " + p1.UsedDistance.ToString("F0") + " " + p1.UsedEnergy.ToString("F0") + " " + p1.UsedTime.ToString("F0") + " " + p1.Life;
						break;
					}
					else
						skill++;
				}
				else
					skill = (byte)((maxskill + minskill) / 2);
			}
			watch.Stop();
			*/
			//output.Text = res + "\n" + watch.ElapsedMilliseconds + " ms";
			//*/
		}
	}

	// For refreshing the UI //
	// Thanks Mr. Javaman: https://social.msdn.microsoft.com/Forums/vstudio/en-US/878ea631-c76e-49e8-9e25-81e76a3c4fe3/refresh-the-gui-in-a-wpf-application?forum=wpf //
	public static class ExtensionMethods
	{
		private static Action EmptyDelegate = delegate () { };
		public static void Refresh(this UIElement uiElement)
		{
			uiElement.Dispatcher.Invoke(DispatcherPriority.Background, EmptyDelegate);
		}
	}
}
