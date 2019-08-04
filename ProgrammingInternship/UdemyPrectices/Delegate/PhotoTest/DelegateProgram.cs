using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingInternship.UdemyPrectices.Delegate
{
    class DelegateProgram
    {
        PhotoProcessor processor = new PhotoProcessor();
        PhotoFilters filters = new PhotoFilters();

        public void Program()
        {
            PhotoProcessor.PhotoFilterHandler filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += filters.ApplyResize;

            processor.Process("Photo", filterHandler);
        }
    }
}
