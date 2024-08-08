using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Interfaces
{
    public interface IApplication
    {
        public bool TestMode { get; set; }
        void Start();
    }

}
