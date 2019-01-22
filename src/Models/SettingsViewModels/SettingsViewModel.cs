﻿using Aiursoft.Blog.Models.SharedViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aiursoft.Blog.Models.SettingsViewModels
{
    public class SettingsViewModel : LayoutViewModel
    {
        public int SubActivePanel { get; set; }
        public SettingsViewModel()
        {
            ActivePanel = 0;
        }
    }
}
