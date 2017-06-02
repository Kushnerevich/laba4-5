using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization.ClassOfAnimals
{
    [Serializable]
    abstract public class Animals
    {
        protected string Weight;
        protected string Growth;
        protected string TypeOfFood;
        protected string ColorOfEyes;
       
        public Animals(string weight, string growth, string typeOfFood, string colorOfEyes)
        {
            Weight = weight;
            Growth = growth;
            ColorOfEyes = colorOfEyes;
            TypeOfFood = typeOfFood;
        }

        public virtual List<string> GetInfo()
        {
            List<string> info = new List<string>();
            return info;    
        }

        public virtual void Change(List<string> items)
        {

        }
    }

}
