
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.interfaces
{
    public interface IUserRepository
    {
        User InsertUser(User user);
        User GetUserByUsername(string username);
        IEnumerable GetUsers();
        void Save();

        /*  IEnumerable<User> GetChannels();
          Channel GetChannelByID(int channelId);
          Channel GetChannelByName(string name);
          Channel InsertChannel(Channel channel);
          Channel DeleteChannel(int channelId);
          Channel UpdateChannel(Channel channel);
          Channel ToObject(Channel channel);
          void Save();*/
    }
}
