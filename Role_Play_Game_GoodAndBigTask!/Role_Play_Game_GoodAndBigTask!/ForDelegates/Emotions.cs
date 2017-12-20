using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_Play_Game_GoodAndBigTask_.ForDelegates
{


    delegate void RunEmotion();
    delegate void CountIt(int end);

    
    delegate void EventHandler();

    class HandlerEvent
    {
        static public event EventHandler Event;
        static public void OnHandlerEvent()
        {
            // Event?.Invoke(); // аналог  if(Event != null) Event()

            try
            {
                Event += Handler;
                Event();
                Event -= Handler;
            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
            }
            finally
            {
                Console.WriteLine("Event was called.");
            }
        }
        static void Handler() { Console.WriteLine("Event occurred!"); }
    }



    static class Emotions
    {

        static public int count = 0;
        static public int exp = 0;
                                                    // подсчет пользуемых эмоций + опыт за их использование
        static CountIt countit = delegate (int exp) // анонимного метода, принимающего аргумент
        {
            Emotions.exp += exp;
            count++;
        };
        static CountIt countitTwiceExp = (int exp) => // лямбда-выражение
        {
            Emotions.exp += exp*2;
            count++;
        };



        static private RunEmotion runEmotion;


        static public void Emote(int choice) // "1 - Боевой Клич, 2 - Разозлиться, 3 - танцевать."
        {
            if (choice == 3)         
                countitTwiceExp(choice);
            else
                countit(choice);

            switch (choice)
            {
                case 1:  runEmotion = new RunEmotion(BattleCry);    runEmotion();  break;
                case 2:  runEmotion = new RunEmotion(BecomeAngry);  runEmotion();  break;
                case 3:  runEmotion = new RunEmotion(Dance);        runEmotion();  break;

                default: runEmotion = new RunEmotion(Inactivity); break; // Бездействие
            }
            
            HandlerEvent.OnHandlerEvent(); 
        }



        




        static private void BattleCry()
        {
            Console.WriteLine("For the Horde!!");
        }
        static private void BecomeAngry()
        {
            Console.WriteLine("Agrhhh!!");
        }
        static private void Dance()
        {
            Console.WriteLine("Boom-boom Batch processing");
        }

        static private void Inactivity() // Бездействие
        {
            Console.WriteLine("...");
        }

    }

}
