using PatchToolService.Classes;
using PatchToolService.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatchToolService.Interfaces
{
    public interface IVersionSelectionHelper
    {
        public ReleaseTypeEnum ReleaseType { get; set; }

        void StartVersionSelectionPrompt();
        void InputCheck(string input);
    }
}
