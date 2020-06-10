using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface ITaskHandler
    {
        object Execute(object[] args);
    }
}
