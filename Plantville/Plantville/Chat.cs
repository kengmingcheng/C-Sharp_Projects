using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantville
{
    class Chat
    {
        public int pk { get; }

        public string name { get; set; }

        public string message { get; set; }

        public Chat(int pk, string name, string message)
        {
            this.pk = pk;
            this.name = name;
            this.message = message;
        }

        public override string ToString()
        {
            return name + " : " + message;
        }
    }
}
