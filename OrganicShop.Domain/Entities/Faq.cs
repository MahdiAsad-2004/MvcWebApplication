using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Entities
{
    [DisplayName("سوال متداول")]
    public class Faq : EntityId<byte>
    {
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
}
