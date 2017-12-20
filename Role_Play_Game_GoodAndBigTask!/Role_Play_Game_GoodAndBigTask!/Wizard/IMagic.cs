using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_Play_Game_GoodAndBigTask_
{

    interface IMagic
    {

        void MakeMagicalActionTo(ref Wizard caster, ref Character character, int strenght = 0);
        void MakeMagicalActionTo(ref Wizard caster, int strenght = 0); // сам на себя

    }

}
