﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization.ClassOfAnimals
{
    [Serializable]
    class Birds:Animals
    {
        public string ColorOfPlumage{get;set;}

        public Birds(string weight, string growth, string typeOfFood, string colorOfEyes, string colorOfPlumage): base(weight, growth, typeOfFood, colorOfEyes)
        {
            ColorOfPlumage = colorOfPlumage;
        }

        public override List<string> GetInfo()
        {
            List<string> info = new List<string>();
            info.Add(Weight);
            info.Add(Growth);
            info.Add(TypeOfFood);
            info.Add(ColorOfEyes);
            info.Add(ColorOfPlumage);
            return info;
        }

        public override void Change(List<string> items)
        {
            Weight = items[0];
            Growth = items[1];
            TypeOfFood = items[2];
            ColorOfEyes = items[3];
            ColorOfPlumage = items[4];
        }
    }
}
