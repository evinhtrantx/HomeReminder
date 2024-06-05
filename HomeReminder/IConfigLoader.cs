using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder
{
    public interface IConfigLoader
    {
        public IList<Config> GetConfigs();
        public void LoadConfig();
    }
}
