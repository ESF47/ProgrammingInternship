using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Composition
{
    class Migrator
    {
        private readonly Logger _logger;

        public Migrator(Logger logger)
        {
            _logger = logger;
        }

        public void Migrate()
        {
            _logger.LogNotification("Server is getting migrated, please be patient...");
        }
    }
}
