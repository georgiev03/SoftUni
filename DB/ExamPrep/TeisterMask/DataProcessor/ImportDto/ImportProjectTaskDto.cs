using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using TeisterMask.Common;
using TeisterMask.Data.Models.Enums;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Task")]
    public class ImportProjectTaskDto
    { 
        [XmlElement("Name")]
        [Required]
        [MinLength(GlobalConstants.TASK_NAME_MIN_LENGTH)]
        [MaxLength(GlobalConstants.TASK_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlElement("ExecutionType")]
        [Range(GlobalConstants.TASK_EXEC_MIN_VALUE,
            GlobalConstants.TASK_EXEC_MAX_VALUE)]
        public int ExecutionType { get; set; }

        [XmlElement("LabelType")]
        [Range(GlobalConstants.TASK_LABEL_MIN_VALUE,
            GlobalConstants.TASK_LABEL_MAX_VALUE)]
        public int LabelType { get; set; }
    }
}
