﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachine
    {
        Random random;
        private int _numberOfSlots;
        public int NumberOfSlots {
            get
            {
                return _numberOfSlots;
            }
            set
            {
                _numberOfSlots = value;
                icons = new int[_numberOfSlots];
            }
        }

        public int IconsPerSlot { get; set; }
        public int MinimumBet { get; set; }
        public int MaximumBet { get; set; }
        public double WinPercentage = 0;

        private int _currentBet;
        public int CurrentBet
        {
            get
            {
                return _currentBet;
            }
            set
            {
                _currentBet = value;
                if (_currentBet < MinimumBet)
                {
                    _currentBet = MinimumBet;
                }
                if (_currentBet > MaximumBet)
                {
                    _currentBet = MaximumBet;
                }
            }
        }

        /// <summary>
        /// An array of integers that is as long as the number of slots,
        /// with each element of the array representing a different slot
        /// </summary>
        private int[] icons;


        public SlotMachine()
        {
            NumberOfSlots = 3;
            IconsPerSlot = 5;
            MinimumBet = 1;
            MaximumBet = 100;

            random = new Random();
        }

        /// <summary>
        /// Randomizes the contents of the icons
        /// </summary>
        public void PullLever()
        {
            for (int i = 0; i < icons.Length; i++)
            {
                icons[i] = random.Next(1, IconsPerSlot + 1);
            }
        }

        /// <summary>
        /// Return the results from the slots
        /// </summary>
        /// <returns>an int[] with each slot as an element of the array</returns>
        public int[] GetResults()
        {
            return icons;
        }

        /// <summary>
        /// Examine the contents of the slots and determine the appropriate payout
        /// based upon the CurrentBet.
        /// </summary>
        /// <returns>number of pennies to pay out</returns>
        public int GetPayout()
        {
            // TODO
            int firstSlot = icons[0];
            bool WinOut = Array.TrueForAll(icons, y => y == firstSlot);

            if (WinOut)
            {
                return CurrentBet * 2;
            }
            return 0;
        }

        public double GetWinPrecentage(double WinCounter, double GameCounter)
        {
            WinPercentage = WinCounter / GameCounter;
            return WinPercentage;
        }


    }
}
