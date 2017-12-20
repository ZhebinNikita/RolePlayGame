using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_Play_Game_GoodAndBigTask_
{


    // Создать класс-потомок «персонаж, владеющий магией».  

    class Wizard : Character
    {

        int currentMagic; // текущее значение магической энергии (маны) (неотрицательная величина)
        int maxMagic; // максимальное значение маны


        public Wizard(string name, string race, string gender) : base(name, race, gender) {}




        // свойства
        public int CurrentMagic
        {
            get
            {
                return this.currentMagic;
            }
            set
            {
                this.currentMagic = value;
            }
        }
        public int MaxMagic
        {
            get
            {
                return this.maxMagic;
            }
            set
            {
                this.maxMagic = value;
            }
        }





        // Мана расходуется на произнесение заклинаний. 
        // Если текущее значение маны меньше того количества, 
        // которое требуется для произнесения какого-либо заклинания, 
        // заклинание не может быть произнесено, а количество маны остается неизменным. 
        //
        // Некоторые заклинания обладают силой, причем сила заклинания задается 
        // волшебником в момент его произнесения. Расход маны в этом случае пропорционален 
        // силе заклинания. Сила заклинания ограничивается текущим значением маны. 







        // Реализовать заклинание «добавление здоровья». 
        // Суть этого заклинания – увеличить текущее значение здоровья какого-либо персонажа 
        // (в том числе и себя) до максимального или до предела, задаваемого текущим значением маны. 
        // На единицу добавленного здоровья расходуется две единицы маны.

        public void IncreaseHealth(Character character)
        {
            while(this.currentMagic > 0)
            {
                if (character.CurrentHealth == character.MaxHealth) break;

                character.CurrentHealth += 1;
                this.currentMagic -= 2;
            }
        }







        ///////////// методы заклинаний, используя классы 

        public void IncreaseHealthMyself(int strenght) // «Добавить здоровье» себе 
        {
            IncreaseHealth spell = new IncreaseHealth();
            //spell.MakeMagicalActionTo(ref this, strenght);
        }
        public void IncreaseHealthTo() // «Добавить здоровье» кому-то
        {

        }










        // Персонаж, владеющий магией, может изучить различные заклинания. 
        // После изучения заклинания могут быть реализованы. 
        // Можно реализовывать только изученные заклинания. 

        public void LearnSpell()
        {

        }


    }


}
