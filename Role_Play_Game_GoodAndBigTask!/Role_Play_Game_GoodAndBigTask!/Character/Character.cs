using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_Play_Game_GoodAndBigTask_
{


    class Character : IComparable<Character>
    {
        ////////////////////// Звездочкой помечены поля, не изменяющиеся после создания персонажа!
        static int iterID = -1;

        int id;      // (*);
        string name; // (*);


        string condition; // состояние (здоров, ослаблен, болен, отравлен, парализован, мёртв)
        public static string NORMAL = "здоров", WEAKEN = "ослаблен", 
                     SICK = "болен", POISONED = "отравлен", PARALIZED = "парализован", DEAD = "мёртв";


        bool canSpeakCurTime; // возможность разговаривать в текущий момент времени;
        bool canMoveCurTime; // возможность двигаться в текущий момент времени; 

        
        string race; // раса (человек, гном, эльф, орк, гоблин) (*);
        string gender; // пол (*);
        int age; // возраст


        int currentHealth; // текущее значение здоровья персонажа(неотрицательная величина)
        int maxHealth; // максимальное значение для здоровья персонажа; 


        double experience; // количество опыта, набранное персонажем






        // конструктор, задающий значения неизменяемых полей 
        // и обеспечивающий уникальность идентификатора для нового объекта

        public Character(string name, string race, string gender)
        {
            iterID++;
            this.id = iterID;

            this.name = name;
            this.race = race;
            this.gender = gender;
        }







        // свойства для всех полей (доступ к полям может быть реализован только при помощи свойств)

        public int ID
        {
            get
            {
                return this.id;
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
        }


        public string Condition
        {
            get
            {
                return this.condition;
            }
            set
            {
                this.condition = value;
            }
        }


        public bool CanSpeakCurTime
        {
            get
            {
                return this.canSpeakCurTime;
            }
            set
            {
                this.canSpeakCurTime = value;
            }
        }
        public bool CanMoveCurTime
        {
            get
            {
                return this.canMoveCurTime;
            }
            set
            {
                this.canMoveCurTime = value;
            }
        }


        public string Race
        {
            get
            {
                return this.race;
            }
        }
        public string Gender
        {
            get
            {
                return this.gender;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }


        public int CurrentHealth
        {
            get
            {
                return this.currentHealth;
            }
            set
            {
                this.currentHealth = value;
            }
        }
        public int MaxHealth
        {
            get
            {
                return this.maxHealth;
            }
            set
            {
                this.maxHealth = value;
            }
        }


        public double Experience
        {
            get
            {
                return this.experience;
            }
            set
            {
                this.experience = value;
            }
        }





        // сравнение персонажей по опыту через реализацию интерфейса IComparable

        public int CompareTo(Character other) // 0 - equal, -1 - not equal, 1 - greater, 2 - less
        {
            if (this.experience == other.Experience) return 0;
            else if (this.experience > other.Experience) return 1;
            else if (this.experience < other.Experience) return 2;

            return -1; 
        }





        // если процент здоровья персонажа (отношение текущего здоровья персонажа к максимальному количеству здоровья) 
        // становится менее 10, персонаж автоматически переходит из состояния «здоров» в состояние «ослаблен». 
        // Если процент здоровья персонажа становится большим или равным 10, 
        // персонаж автоматически переходит из состояния «ослаблен» в состояние  «здоров». 
        // Если текущее значение здоровья равно 0, 
        // персонаж автоматически переходит из любого состояния в состояние «мертв».  

        private void SetCondition()
        {
            if(this.currentHealth < (this.maxHealth / 10))
            {
                this.condition = WEAKEN;
            }
            else if(this.currentHealth >= (this.maxHealth / 10))
            {
                this.condition = NORMAL;
            }
            else if(this.currentHealth == 0)
            {
                this.condition = DEAD;
            }

        }





        // вывод информации о персонаже в строку(через метод ToString). 

        public override string ToString()
        {
            string info = "ID = "+ id + " | Name = " + name + " | Condition = " + condition + " | Race = " 
                + race + " | Gender = " + gender + " | Age = " + age + " \n\n" +

                "MaxHealth = " + maxHealth + " | CurrentHealth = " + currentHealth 
                + " | Experience = " + experience + " \n\n" +

                "Can Character speak right now? - " + canSpeakCurTime 
                + "  |  Can Character move right now? - " + canMoveCurTime;


            return info;
        }





        ////////////////////////////////////////////////////  Inventory

        static public class Inventory<Artif> where Artif : Artifact
        {
            static private List<Artif> ListArtif = new List<Artif>();

            public static void AddArtifact(Artif artifact)
            {
                if (CheckKind(artifact.Kind) == false)
                {
                    AddKind(artifact.Kind); 
                    ListArtif.Add(artifact);
                }
                else
                {
                    // Артефакт такого вида уже имеется или же 
                    // достигнуто максимально возможное кол-во артефактов
                }
            }
            public static Artif GetArtifact(int index)
            {
                return ListArtif.ToArray()[index];
            }





            static private int AmountKinds = 10;
            static private string[] Kinds = new string[AmountKinds]; // максимум 10 видов Артефактов

            static private void AddKind(string kind)
            {
                for(int i = 0; i < AmountKinds; i++)
                {
                    if(Kinds[i] == "" || Kinds[i] == null)
                    {
                        Kinds[i] = kind;
                        break;
                    }
                }
            }
            static private bool CheckKind(string kind)
            {
                return true;
            }





            static private void UseArtifact(string kind)
            {
                // Можно использовать только те артефакты, которые имеются в мешке.
                // ищем в списке артефакт данного вида 
                for (int i = 0; i < ListArtif.ToArray().Length; i++)
                {
                    if (ListArtif.ToArray()[i].Kind == kind) // если находим, то используем
                    {
                        ListArtif.ToArray()[i].Use();

                        if(ListArtif.ToArray()[i].IsRenewable != true) // Если артефакт невознобляемый
                            ListArtif.RemoveAt(i);

                        break;
                    }
                }
            }
            





        }

    }


}
