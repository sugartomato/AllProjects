using Microsoft.VisualStudio.TestTools.UnitTesting;
using KK.WX.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace KK.WX.Messages.Tests
{
    [TestClass()]
    public class TemplateMessageTests
    {
        [TestMethod()]
        public void GenerateDataJsonTest()
        {
            String xx = TemplateMessage.GenerateDataJson(
                new TemplateMessage.DataValue() { Value = "会议提醒：", Color = ColorTranslator.ToHtml(Color.Red) },
            new TemplateMessage.DataValue() { Value = "请准时参加！", Color = ColorTranslator.ToHtml(Color.Blue), },

            new TemplateMessage.DataValue() { Value = "东坝663项目例会！", Color = ColorTranslator.ToHtml(Color.Blue), },

            new TemplateMessage.DataValue() { Value = "周兵！", Color = ColorTranslator.ToHtml(Color.Blue), }

            );
            Console.WriteLine(xx);
        }

        [TestMethod()]
        public void SendTest()
        {
            String xx = TemplateMessage.GenerateDataJson(
                new TemplateMessage.DataValue() { Value = "东坝663项目例会", Color = ColorTranslator.ToHtml(Color.Red) },
            new TemplateMessage.DataValue() { Value = "会议由【周兵】主持，请准时参加！", Color = ColorTranslator.ToHtml(Color.Blue) },

            new TemplateMessage.DataValue() { Value = "2018-2-6", Color = ColorTranslator.ToHtml(Color.Blue) },

            new TemplateMessage.DataValue() { Value = "206会议室", Color = ColorTranslator.ToHtml(Color.Blue) }

            );

            TemplateMessage obj = new TemplateMessage()
            {
                Data = xx,
                MiniProgram = TemplateMessage.GenerateMiniProgramJson("",""),
                TemplateID = TemplateMessage.TemplateID_HYTZ,
                ToUser= "oUBwK1KM-t1iGW-4A97Z3vrIc7UQ",
                
            };

            String errMsg = String.Empty;
            TemplateMessage.Send(obj, ref errMsg);
            Console.WriteLine(errMsg);

        }
    }
}