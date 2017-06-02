using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization.ClassOfAnimals
{
    [Serializable]
    class Mammals:Animals
    {
        public string Hairline { get; set; }

        public Mammals(string weight, string growth, string typeOfFood, string colorOfEyes, string hairline)
            : base(weight, growth, typeOfFood, colorOfEyes)
        {
            Hairline = hairline;
        }

        public override List<string> GetInfo()
        {
            List<string> info = new List<string>();
            info.Add(Weight);
            info.Add(Growth);
            info.Add(TypeOfFood);
            info.Add(ColorOfEyes);
            info.Add(Hairline);
            return info;
        }

        public override void Change(List<string> items)
        {
            Weight = items[0];
            Growth = items[1];
            TypeOfFood = items[2];
            ColorOfEyes = items[3];
            Hairline = items[4];
        }
    }
}
