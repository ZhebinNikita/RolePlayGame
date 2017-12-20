using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_Play_Game_GoodAndBigTask_
{

    

    class Program
    {
        static void Main(string[] args)
        {


            Wizard wizardOne = new Wizard("Кирунтулус", "Эльф", "Мужской");

            IncreaseHealth spell = new IncreaseHealth();
            spell.MakeMagicalActionTo(ref wizardOne, 100);



            ///////////////////////////////////////////////////////////////////////



            Character personOne = new Character("Кристина", "Человек", "Женский");

            personOne.Age = 23;
            personOne.CanMoveCurTime = false;
            personOne.CanSpeakCurTime = false;
            personOne.Experience += 20;        // Опыт за создание персонажа



            ///////////////////////////////////////////////////////////////////////



            Console.ReadKey();
        }
    }


}
