using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization.ClassOfAnimals
{
    [Serializable]
    class Reptiles:Animals
    {
        public string Sex { get; set; }

        public Reptiles(string weight, string growth, string typeOfFood, string colorOfEyes, string sex)
            : base(weight, growth,typeOfFood, colorOfEyes)
        {
            Sex = sex;
        }

        public override List<string> GetInfo()
        {
            List<string> info = new List<string>();
            info.Add(Weight);
            info.Add(Growth);
            info.Add(TypeOfFood);
            info.Add(ColorOfEyes);
            info.Add(Sex);
            return info;
        }

        public override void Change(List<string> items)
        {
            Weight = items[0];
            Growth = items[1];
            TypeOfFood = items[2];
            ColorOfEyes = items[3];
            Sex = items[4];
        }
    }
}
