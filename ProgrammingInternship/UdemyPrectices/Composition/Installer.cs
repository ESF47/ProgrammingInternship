using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Composition
{
    class Installer
    {
        private readonly Logger _logger;

        public Installer (Logger logger)
        {
            _logger = logger;
        }

        public void Install()
        {
            _logger.LogNotification("Server is getting installed, please be patient...");
        }
    }
}
