using System;
using System.Collections.Generic;
using System.Text;

namespace atFrameWork2.TestEntities
{
    class Bitrix24Task
    {
#pragma warning disable CS8618 // свойство "Description", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        public Bitrix24Task(string title)
#pragma warning restore CS8618 // свойство "Description", не допускающий значения NULL, должен содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить свойство как допускающий значения NULL.
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}
