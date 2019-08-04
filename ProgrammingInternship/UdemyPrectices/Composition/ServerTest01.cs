using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Composition
{
    class ServerTest01
    {
        private Migrator _migrator = new Migrator(new Logger());
        private Installer _installer = new Installer(new Logger());

        public void ServerSetup()
        {
            _migrator.Migrate();
            _installer.Install();
        }
    }
}
