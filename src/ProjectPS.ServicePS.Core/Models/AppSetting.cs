﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectPS.ServicePS.Core.Models
{
    /// <summary>
    /// This class is responsible for storing the domain settings.
    /// </summary>
    public class AppSetting : EntityBase
    {
        public AppSetting() : base()
        {

        }
        
        /// <summary>
        /// Key Setting
        /// </summary>
        [Key]
        [Required]
        public string Key { get; set; }

        /// <summary>
        /// Value Setting
        /// </summary>
        [Required]
        public string Value { get; set; }

        /// <summary>
        /// If it is read-only, it is a system variable
        /// </summary>
        public bool IsReadOnly { get; set; }

        public static class Factory
        {
            /// <summary>
            /// Factory to create the initial instace.
            /// </summary>
            /// <param name="key">App Setting Key</param>
            /// <param name="value">App Setting Value</param>
            /// <param name="isReadOnly">Is ReadOnly</param>
            /// <param name="createdBy">Created By</param>
            /// <returns></returns>
            public static AppSetting Create(
                string key, 
                string value, 
                bool isReadOnly, 
                string createdBy)
            {
                var entity = new AppSetting()
                {
                    Key = key,
                    Value = value,
                    IsReadOnly = isReadOnly,
                    CreatedBy = createdBy
                };

                return entity;
            }

        }
    }
}
