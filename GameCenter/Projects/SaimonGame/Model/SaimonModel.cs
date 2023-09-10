using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;
using System.Windows.Media.Media3D;
using System.Windows;

namespace GameCenter.Projects.SaimonGame.Model
{
    internal class SaimonModel
    {
      public List<double> CurrentSequence;
      public int scoreCount;
      public int record;
      public bool talk;
        public SaimonModel()
        {
            CurrentSequence = new List<double>();
            scoreCount = 0;
            record = 0;
            talk = false;
        }

        public bool Verify_play(int button_pressed)
        {
            if (talk == false && CurrentSequence.Count > 0)
            {
                {
                    if (scoreCount >= CurrentSequence.Count)
                    {
                        return false;
                    }
                    else
                        if (button_pressed == CurrentSequence[scoreCount])
                    {
                        scoreCount++;

                        if (scoreCount > record)
                        {
                            record = scoreCount;   
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public bool If_To_Play_Again()
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Game Over! Would you like to play again?", "Game Over", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    scoreCount = 0;
                    CurrentSequence.Clear();
                    return true;

                }
                if (result == MessageBoxResult.No)
                {
                    return false;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            return false;
        }
            
    }
}
