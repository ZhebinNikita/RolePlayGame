using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_Play_Game_GoodAndBigTask_
{

    abstract class Spell : IMagic
    {

        abstract public int CostMagic // минимальное значение маны, требуемое для выполнения заклинания (может быть 0)
        {
            get;
        }
        abstract public bool SpeakSpell // наличие вербальной компоненты (заклинание нужно произносить)
        {
            get;
        }
        abstract public bool ActBeforeSpell // наличие моторной компоненты (необходимо выполнять какие-то движения)
        {
            get;
        }



        abstract public void MakeMagicalActionTo(ref Wizard caster, ref Character character, int strenght = 0);
        abstract public void MakeMagicalActionTo(ref Wizard caster, int strenght = 0);
    }








    ///////////////////////////////////////////////////////////////////  классы заклинаний

    //  Суть этого заклинания – увеличить текущее значение здоровья 
    // какого-либо персонажа на заданную величину или до предела, 
    // задаваемого текущим значением маны. 
    // На единицу добавленного здоровья расходуется две единицы маны. 

    class IncreaseHealth : Spell // «Добавить здоровье». 
    {
        public override int CostMagic => 2;
        public override bool SpeakSpell => true;
        public override bool ActBeforeSpell => true;


        public override void MakeMagicalActionTo(ref Wizard caster, ref Character character, int strenght = 0)
        {
            while (caster.CurrentMagic > 0)
            {
                if (character.CurrentHealth == character.MaxHealth) break;

                character.CurrentHealth += (1 + strenght);
                caster.CurrentMagic -= CostMagic;
            }
        }
        public override void MakeMagicalActionTo(ref Wizard caster, int strenght = 0) // сам на себя
        {
            while (caster.CurrentMagic > 0)
            {
                if (caster.CurrentHealth == caster.MaxHealth) break;

                caster.CurrentHealth += (1 + strenght);
                caster.CurrentMagic -= CostMagic;
            }
        }

    }



    // Суть этого заклинания – перевести какого-либо персонажа 
    // из состояния «болен» в состояние «здоров или ослаблен». 
    // Текущая величина здоровья не изменяется. Заклинание требует 20 единиц маны.

    class Cure : Spell // «Вылечить»
    {
        public override int CostMagic => 20;
        public override bool SpeakSpell => false;
        public override bool ActBeforeSpell => true;


        public override void MakeMagicalActionTo(ref Wizard caster, ref Character character, int strenght = 0)
        {
            if (character.Condition == Character.SICK)
            {
                if (caster.CurrentMagic >= CostMagic)
                {
                    caster.CurrentMagic -= CostMagic;

                    if (character.CurrentHealth < (character.MaxHealth / 10))
                        character.Condition = Character.WEAKEN;
                    else
                        character.Condition = Character.NORMAL;
                }
            }
        }
        public override void MakeMagicalActionTo(ref Wizard caster, int strenght = 0) // сам на себя
        {
            if (caster.Condition == Character.SICK)
            {
                if (caster.CurrentMagic >= CostMagic)
                {
                    caster.CurrentMagic -= CostMagic;

                    if (caster.CurrentHealth < (caster.MaxHealth / 10))
                        caster.Condition = Character.WEAKEN;
                    else
                        caster.Condition = Character.NORMAL;
                }
            }
        }

    }



    //  Суть этого заклинания – перевести какого-либо персонажа из 
    // состояния «отравлен» в состояние «здоров или ослаблен». 
    // Текущая величина здоровья не изменяется. 
    // Заклинание требует 30 единиц маны. 

    class Antidote : Spell // «Противоядие»
    {
        public override int CostMagic => 30;
        public override bool SpeakSpell => true;
        public override bool ActBeforeSpell => true;


        public override void MakeMagicalActionTo(ref Wizard caster, ref Character character, int strenght = 0)
        {
            if (character.Condition == Character.POISONED)
            {
                if (caster.CurrentMagic >= CostMagic)
                {
                    caster.CurrentMagic -= CostMagic;

                    if (character.CurrentHealth < (character.MaxHealth / 10))
                        character.Condition = Character.WEAKEN;
                    else
                        character.Condition = Character.NORMAL;
                }
            }
        }
        public override void MakeMagicalActionTo(ref Wizard caster, int strenght = 0) // сам на себя
        {
            if (caster.Condition == Character.POISONED)
            {
                if (caster.CurrentMagic >= CostMagic)
                {
                    caster.CurrentMagic -= CostMagic;

                    if (caster.CurrentHealth < (caster.MaxHealth / 10))
                        caster.Condition = Character.WEAKEN;
                    else
                        caster.Condition = Character.NORMAL;
                }
            }
        }

    }



    // Суть этого заклинания – перевести какого-либо персонажа из 
    // состояния «мертв» в состояние «здоров или ослаблен». 
    // Текущая величина здоровья становится равной 1. Заклинание требует 150 единиц маны. 

    class Reanimate : Spell // «Оживить». 
    {
        public override int CostMagic => 150;
        public override bool SpeakSpell => true;
        public override bool ActBeforeSpell => true;


        public override void MakeMagicalActionTo(ref Wizard caster, ref Character character, int strenght = 0)
        {
            if (character.Condition == Character.DEAD)
            {
                if (caster.CurrentMagic >= CostMagic)
                {
                    caster.CurrentMagic -= CostMagic;

                    if (character.CurrentHealth < (character.MaxHealth / 10))
                        character.Condition = Character.WEAKEN;
                    else
                        character.Condition = Character.NORMAL;
                }
            }
        }
        public override void MakeMagicalActionTo(ref Wizard caster, int strenght = 0) // сам на себя
        {
            if (caster.Condition == Character.DEAD)
            {
                if (caster.CurrentMagic >= CostMagic)
                {
                    caster.CurrentMagic -= CostMagic;

                    if (caster.CurrentHealth < (caster.MaxHealth / 10))
                        caster.Condition = Character.WEAKEN;
                    else
                        caster.Condition = Character.NORMAL;
                }
            }
        }

    }



    // «Броня». Персонаж, на которого обращено заклинание, становится 
    // неуязвимым в течение некоторого промежутка времени, определяемого силой заклинания. 
    // Заклинание требует 50 единиц маны на единицу времени. 

    class DivineShield : Spell // «Броня»
    {
        public override int CostMagic => 50;
        public override bool SpeakSpell => false;
        public override bool ActBeforeSpell => false;

        int time = 0;


        public override void MakeMagicalActionTo(ref Wizard caster, ref Character character, int strenght = 0)
        {
            time = caster.CurrentMagic / 50; // 50 единиц маны на единицу времени
            if (time > 0)
            {
                int blockedHealth = character.CurrentHealth;

                // реализовать по времени
                character.CurrentHealth = blockedHealth;
            }
        }
        public override void MakeMagicalActionTo(ref Wizard caster, int strenght = 0) // сам на себя
        {
            time = caster.CurrentMagic / 50; // 50 единиц маны на единицу времени
            if (time > 0)
            {
                int blockedHealth = caster.CurrentHealth;

                // реализовать по времени
                caster.CurrentHealth = blockedHealth;
            }
        }

    }



    // «Отомри!» Суть этого заклинания – перевести какого-либо персонажа из 
    // состояния «парализован» в состояние «здоров или ослаблен». 
    // Текущая величина здоровья становится равной 1. Заклинание требует 85 единиц маны

    class HealNumb : Spell // «Отомри»
    {
        public override int CostMagic => 85;
        public override bool SpeakSpell => false;
        public override bool ActBeforeSpell => true;


        public override void MakeMagicalActionTo(ref Wizard caster, ref Character character, int strenght = 0)
        {
            if (character.Condition == Character.PARALIZED)
            {
                if (caster.CurrentMagic >= CostMagic)
                {
                    caster.CurrentMagic -= CostMagic;

                    if (character.CurrentHealth < (character.MaxHealth / 10))
                        character.Condition = Character.WEAKEN;
                    else
                        character.Condition = Character.NORMAL;

                    character.CurrentHealth = 1;
                }
            }
        }
        public override void MakeMagicalActionTo(ref Wizard caster, int strenght = 0) // сам на себя
        {
            if (caster.Condition == Character.PARALIZED)
            {
                if (caster.CurrentMagic >= CostMagic)
                {
                    caster.CurrentMagic -= CostMagic;

                    if (caster.CurrentHealth < (caster.MaxHealth / 10))
                        caster.Condition = Character.WEAKEN;
                    else
                        caster.Condition = Character.NORMAL;

                    caster.CurrentHealth = 1;
                }
            }
        }

    }


}
