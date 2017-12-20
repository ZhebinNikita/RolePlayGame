using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Role_Play_Game_GoodAndBigTask_
{


    public class Artifact
    {
        string kind;          // вид Артефакта
        bool isRenewable;     // Возобновляемый артефакт или нет

        public string Kind
        {
            get
            {
                return this.kind;
            }
            set
            {
                this.kind = value;
            }
        }
        public bool IsRenewable
        {
            get
            {
                return this.isRenewable;
            }
            set
            {
                this.isRenewable = value;
            }
        }


        public void Use()
        {

        }


    }



}
