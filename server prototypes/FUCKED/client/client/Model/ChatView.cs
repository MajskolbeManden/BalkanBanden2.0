using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.Model
{
    public class ChatView
    {
        public static ObservableCollection<Message> ChatList = new ObservableCollection<Message>
        {
            new Message{ LineOne = "yo"},
            new Message{ LineOne = "grete"},
            new Message{ LineOne = "safdo"},
            new Message{ LineOne = "yo"},
            new Message{ LineOne = "yo"},
        };
    }
}
