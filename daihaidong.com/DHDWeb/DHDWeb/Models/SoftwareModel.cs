using System;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace DHDWeb.Models
{
    public class SoftwareModel:ModelBase
    {
        public SoftwareModel()
        {
        }

        [Required(ErrorMessage ="名称是必须的！")]
        [Display(Name="名称")]
        //[RegularExpression(@"\s\S{1,}", ErrorMessage ="必须填写内容")]
        public String Name { get; set; } = String.Empty;

        [Display(Name="作者")]
        public String Author { get; set; } = String.Empty;

        [Display(Name="描述")]
        public String Description { get; set; } = String.Empty;

    }
}
