using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeiXin.Core.Instruction
{
    internal class ComparerInstructionBaseByType : IEqualityComparer<InstructionBase>
    {

        public bool Equals(InstructionBase x, InstructionBase y)
        {
            return x.GetType().Equals(y.GetType());
        }

        public int GetHashCode(InstructionBase obj)
        {
            return obj.GetType().GetHashCode();
        }
    }
}
